using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace LotoServer
{
    public class pairsDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {
        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
                this[key].Add(value);
            
            else
                Add(key, new List<TValue> { value });
        }
        
    }

    internal class Program
    { public static string ip = "";

       public static int n = 0;
        public static Dictionary<string, string> clients = new Dictionary<string, string>();
        public static List<int> uniqueNumbers = new List<int>();

        public static UdpClient udpclient = new UdpClient();
      public static   UdpClient receiver = new UdpClient(25555);

        public static IPAddress multicastaddress = IPAddress.Parse("239.0.0.222");
        public static Byte[] buffer = null;
        public static int roundwinner = 1; //счетчик раундов


        public static pairsDictionary<string, string> winners = new LotoServer.pairsDictionary<string, string>();




        private static void Main(string[] args)
        {
            
            

            foreach (IPAddress v in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                ip = v.ToString();

            }


            NumbersList(uniqueNumbers);

            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start();


            Console.WriteLine("Нажмите любую клавишу чтобы разрешить подключение игроков");
            Console.ReadLine();
     
            GoLottery();
            Console.WriteLine("Игроки подключены,нажмите любую клавишу чтобы запустить розыгрыш лотереи");
            Console.ReadLine();
            checkWinner();


        }



        public static void checkWinner()
        {
            
            for (int i = 0; i < 90; i++)
            {
                sendMessage(uniqueNumbers[i].ToString());
                if (roundwinner==1)
                { 
            

                    //sendMessage(uniqueNumbers[i].ToString());
                    //uniqueNumbers.Remove(uniqueNumbers[i]);
                    n++;
                    Console.WriteLine("Number " +n);
                    Thread.Sleep(300);
                    if (winners.ContainsKey("round1Winner"))
                    {
                        foreach (var v in winners["round1Winner"])
                        {
                            sendMessage("Билет номер: " + v + " Выйграл первый раунд");
                            break;
                        }
                        roundwinner = 2;
                        Thread.Sleep(10000);
                        sendMessage("Начинается раунд 2");
                        //checkWinner();

                    }
                }


                if (roundwinner == 2)
                {

                    //sendMessage(uniqueNumbers[i].ToString());
                    //uniqueNumbers.Remove(uniqueNumbers[i]);
                    n++;
                    Console.WriteLine("Number " + n);
                    Thread.Sleep(300);
                    if (winners.ContainsKey("round2Winner"))
                    {
                        foreach (var v in winners["round2Winner"])
                        {
                            sendMessage("Билет номер: " + v + " Выйграл второй раунд");
                            break;
                        }
                     
                        roundwinner = 3;
                        Thread.Sleep(10000);
                        sendMessage("Начинается раунд 3");
                        //checkWinner();
                    }
                    if (winners.ContainsKey("jeckpot"))
                    {
                        foreach (var v in winners["jeckpot"])
                        {
                            sendMessage(v + " Выйграл второй раунд и джекпот в миллиард триллионов рублей");
                            break;
                        }
                        roundwinner = 3;
                        Thread.Sleep(10000);
                        sendMessage("Начинается раунд 3");
                        //checkWinner();
                    }
                }



                if (roundwinner == 3)
                {

                    //sendMessage(uniqueNumbers[i].ToString());
                    //uniqueNumbers.Remove(uniqueNumbers[i]);
                    n++;
                    Console.WriteLine("Number " + n);
                    Thread.Sleep(300);
                    if (winners.ContainsKey("round3Winner"))
                    {

                        foreach (var v in winners["round3Winner"])
                        {
                            sendMessage( "Билет номер: "+v + " Выйграл третий раунд");
                            break;
                        }
                        roundwinner = 0;
                        sendMessage("stop");
                        udpclient.Close();
                        receiver.Close();




                    }
                }

            }
        }
    
        
        private static void GoLottery()
        {
            sendMessage("go game? "+ip);

            Thread.Sleep(20000);
            if(clients.Count<1)
            {
                clients.Clear();
                sendMessage(clients.Count.ToString());
                Thread.Sleep(60000);
                GoLottery();
            }
            else
            {
              
                sendMessage("start");
            }
            
        }
        private static void sendMessage(string message )
        {
            IPEndPoint remoteep = new IPEndPoint(multicastaddress, 2222);

            buffer = Encoding.Unicode.GetBytes(message);
            udpclient.Send(buffer, buffer.Length, remoteep);
            Console.WriteLine(message);
           
            

        }
        private static void NumbersList(List<int> list)
        {
            var rnd = new Random();
            for (int i = 1; i < 91; i++)
            {
                list.Add(i);
            }
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }
        }
        //private static void SendMessage(string message, string remoteAddress, int remotePort)
        //{
        //    UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
        //    try
        //    {
        //        while (true)
        //        {
                   
        //            byte[] data = Encoding.Unicode.GetBytes(message);
        //            sender.Send(data, data.Length, remoteAddress, remotePort); // отправка
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        sender.Close();
        //    }
        //}

        private static void ReceiveMessage()
        {
            string[] messageArr;
            
           // UdpClient для получения данных
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {

                    byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                    string message = Encoding.Unicode.GetString(data);
                    messageArr = message.Split(' ');
                    if (messageArr[0] == "data")
                    {

                        clients.Add(messageArr[1], messageArr[2]);
                        Thread.Sleep(100);
                        sendMessage("count " + clients.Count.ToString());

                    }
                    if (messageArr[0] == "winTour1" && roundwinner == 1)
                    {

                        winners.Add("round1Winner", messageArr[1]);

                    }
                    if (messageArr[0] == "jeckpot" && roundwinner == 2)
                    {

                        winners.Add("jeckpot", messageArr[1]);
                    }
                    if (messageArr[0] == "winTour2" && roundwinner == 2)
                    {

                        winners.Add("round2Winner", messageArr[1]);
                    }
                    if (messageArr[0] == "winTour3" && roundwinner == 3)
                    {

                        winners.Add("round3Winner", messageArr[1]);

                    }
                    if (messageArr[0] == "exit")
                    {
                        clients.Remove(messageArr[1]);
                        if (clients.Count == 0)
                        {
                            udpclient.DropMulticastGroup(multicastaddress);

                                

                      
                            receiver.Close();
                            Console.WriteLine("Розыгрыш прекращен, все игроки вышли из игры");
                        }
                    }
                    Console.WriteLine(message);
                }
            }
         
            finally
            {
                receiver.Close();
            }
        }
    } 
}
     
      

     
      
   
    
