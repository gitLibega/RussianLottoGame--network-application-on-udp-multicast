using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;




namespace Chat
{
    public partial class LotoClient : Form
    {

        public static int tour = 1;
        public int money = 0;
        private static Random ran = new Random();
        private List<int> digits = new List<int>();
        private static List<int> alldigits = new List<int>(30);
        public static List<int> barrels = new List<int>();
        private static bool flagStart = false;
        private static bool flagManualMode = false;
        private static int[] tic1 = new int[15];
        private static int[] tic2 = new int[15];

        public static IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 2222);
        public static IPAddress multicastaddress = IPAddress.Parse("239.0.0.222");
        public static UdpClient client1 = new UdpClient();

        public static string ip = "";
        public static List<int> first15Digits = new List<int>();
        public static List<int> markDigit = new List<int>();



        public LotoClient()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.Visible = false;
            manualMode.Checked = true;
            add.Enabled = false;
            int digit = 1;
            while (digit < 90)
            {

                digits.Add(digit);
                digit++;
            }
            generateTicket(ticketOne, alldigits);
            generateTicket(ticketTwo, alldigits);

            for (int i = 0; i < 1; i++)
            {

                if (i < 15)
                {
                    tic1[i] = alldigits[i];
                }

                else
                {
                    tic2[i - 15] = alldigits[i];
                }
            }

            var recChat = new Thread(new ThreadStart(ReceiveMessages));
            recChat.Start();

        }
        // метод приема сообщений
        private void ReceiveMessages()
        {
            try
            {


                client1.ExclusiveAddressUse = false;
                client1.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client1.ExclusiveAddressUse = false;

                client1.Client.Bind(localEp);


                client1.JoinMulticastGroup(multicastaddress);



                while (true)
                {

                    int k;
                    Byte[] data = client1.Receive(ref localEp);
                    string strData = Encoding.Unicode.GetString(data);
                    string[] arrData = strData.Split(' ');
                    if (!int.TryParse(strData, out k))
                    {
                        if (strData.Contains("go"))
                        {
                            ip = arrData[2];
                            add.Invoke((MethodInvoker)(() => add.BackColor = Color.Green));
                            add.Invoke((MethodInvoker)(() => add.ForeColor = Color.White));
                            add.Invoke((MethodInvoker)(() => add.Enabled = true));
                            var n = 0;
                            while (n < 20)
                            {
                                n++;

                                time.Invoke((MethodInvoker)(() => time.Text = (20 - n).ToString()));
                                Thread.Sleep(1000);
                                if (n == 20)
                                {
                                    add.Invoke((MethodInvoker)(() => add.BackColor = Color.Red));
                                    add.Invoke((MethodInvoker)(() => add.ForeColor = Color.Black));
                                    add.Invoke((MethodInvoker)(() => add.Enabled = false));
                                }
                            }
                        }
                        if (strData.Contains("start"))
                        {

                            groupBox2.Invoke((MethodInvoker)(() => groupBox2.Dispose()));
                            this.Invoke((MethodInvoker)(() => this.Controls.Remove(groupBox1)));
                            digit.Invoke((MethodInvoker)(() => digit.Text = "91"));
                            flagStart = true;
                        }
                        if (arrData[0] == "count")
                        {
                            label2.Invoke((MethodInvoker)(() => label2.Text += arrData[1]));
                            if (arrData[1] == "2" || arrData[1] == "1")
                            {
                                label2.Invoke((MethodInvoker)(() => label2.Text += arrData[1]));
                            }
                        }
                        lsbxChat.Invoke((MethodInvoker)(() => lsbxChat.Items.Add(strData)));
                        if (strData.Contains("Начинается раунд"))
                        {
                            tour = int.Parse(arrData[2]);
                            label1.Invoke((MethodInvoker)(() => label1.Text = "Tour:" + (arrData[2])));
                        }
                        if (arrData.Contains("первый") && arrData.Contains(Program.ip))
                        {
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Visible = true));
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Dock = DockStyle.Top));
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.URL = "Prize.mp4"));
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Ctlcontrols.play()));
                            Thread.Sleep(2900);
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Visible = false));
                        }
                        if (arrData.Contains("второй") && arrData.Contains(Program.ip))
                        {
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Visible = true));
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Dock = DockStyle.Top));
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.URL = "Победитель.mp4"));
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Ctlcontrols.play()));
                            Thread.Sleep(2900);
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Visible = false));
                        }
                        if (arrData.Contains("третий") && arrData.Contains(Program.ip))
                        {
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Visible = true));
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Dock = DockStyle.Top));
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.URL = "Победитель.mp4"));
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Ctlcontrols.play()));
                            Thread.Sleep(2900);
                            axWindowsMediaPlayer1.Invoke((MethodInvoker)(() => axWindowsMediaPlayer1.Visible = false));
                        }


                        if (strData == "stop")
                        {


                            MessageBox.Show("Розыгрыш закончен!");
                            Application.Restart();
                            //client1.DropMulticastGroup(multicastaddress);


                        }
                    }
                    else
                    {

                        digit.Invoke((MethodInvoker)(() => digit.Text = strData));
                        barrels.Add(int.Parse(strData));

                        if (barrels.Count == 15)
                        {
                            first15Digits.AddRange(barrels);
                        }
                        if (flagStart && !flagManualMode)
                        {
                            checkNumber(ticketOne, barrels, strData);
                            checkNumber(ticketTwo, barrels, strData);
                            checkTour(ticketOne);
                            checkTour(ticketTwo);
                            checkTour2Jackpot(ticketOne, barrels, tic1);
                            checkTour2Jackpot(ticketTwo, barrels, tic2);
                            checkTour23(barrels, markDigit,ticketOne,ticketTwo);

                        }


                    }

                }
            }

            catch
            {

            }
        }




        public static int countDigitsinRow(DataGridView dgv, int r)
        {
            int count = 0;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv[i, r].Value != null &&
                    dgv[i, r].Value.ToString() != String.Empty)
                    count++;
            }
            return count;
        }
        private void goTicket(DataGridView dgv, List<int> list)
        {
            List<int> columnCount = new List<int>();
            int random = 1;
            var r = 1;
            var n = 0;




            for (int i = 0; i < 3; i++)
            {

                random = 0;


                while (random < 9)
                {
                    columnCount.Add(random);
                    random++;
                }
                while (countDigitsinRow(dgv, i) < 5 && columnCount.Count != 0)
                {


                    var x = columnCount[ran.Next(0, columnCount.Count)];
                    random = digits[ran.Next(1, digits.Count)];
                    r = random;
                    random = random / 10 % 10;
                    if (random == 0)
                    {
                        dgv[0, i].Value = r;

                        dgv.Rows[i].Cells[0].Style.BackColor = Color.BurlyWood;
                        dgv.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        digits.RemoveAt(digits.IndexOf(r));

                        columnCount.RemoveAt(columnCount.IndexOf(x));


                    }
                    else if (r == 90)
                    {
                        dgv[8, i].Value = r;

                        dgv.Rows[i].Cells[8].Style.BackColor = Color.BurlyWood;
                        dgv.Rows[i].Cells[8].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        digits.RemoveAt(digits.IndexOf(r));

                        columnCount.RemoveAt(columnCount.IndexOf(x));


                    }
                    else
                    {
                        while (random != x)
                        {
                            random = digits[ran.Next(1, digits.Count)];
                            r = random;
                            random = random / 10 % 10;
                        }

                        dgv[x, i].Value = r;

                        dgv.Rows[i].Cells[x].Style.BackColor = Color.BurlyWood;
                        dgv.Rows[i].Cells[x].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        digits.RemoveAt(digits.IndexOf(r));

                        columnCount.RemoveAt(columnCount.IndexOf(x));



                    }
                    list.Add(r);
                    n++;




                }
                columnCount.Clear();


            }
            alldigits.Clear();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                for (int j = 0; j < dgv.Rows.Count; j++)
                {

                    if (dgv[i, j].Value != null)
                    {
                        alldigits.Add(int.Parse(dgv[i, j].Value.ToString()));
                    }
                }
            }

        }



        public static void checkNumber(DataGridView dgv, List<int> Barrels, string digitBarrel)
        {
            for (int i = 0; i < Barrels.Count; i++)
            {
                for (int a = 0; a < dgv.Rows.Count; a++)
                {
                    for (int b = 0; b < dgv.Columns.Count; b++)
                    {
                        if (Convert.ToInt32(dgv[b, a].Value) == Convert.ToInt32(digitBarrel))
                        {
                            dgv[b, a].Style.BackColor = Color.Crimson;
                            if (!markDigit.Contains(int.Parse(dgv[b, a].Value.ToString())))
                            {
                                markDigit.Add(int.Parse(dgv[b, a].Value.ToString()));
                            }
                        }
                    }
                }
            }
        }
        public static void checkTour(DataGridView dgv)
        {
            if (tour == 1)

            {
                int tour1 = 0;

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv[i, 0].Style.BackColor == Color.Crimson)
                    {
                        tour1++;
                        if (tour1 == 5)
                        {
                            SendToServer("winTour1 " + Program.ip); ;

                        }

                    }
                }

                tour1 = 0;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv[i, 1].Style.BackColor == Color.Crimson)
                    {
                        tour1++;
                        if (tour1 == 5)
                        {

                            SendToServer("winTour1 " + Program.ip); ;
                        }

                    }
                }
                tour1 = 0;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv[i, 2].Style.BackColor == Color.Crimson)
                    {
                        tour1++;
                        if (tour1 == 5)
                        {
                            SendToServer("winTour1 " + Program.ip);

                        }

                    }
                }
            }

        }
        private static void checkTour2Jackpot(DataGridView dgv, List<int> Barrels, int[] ar)
        {
            int n = 0;
            if (tour == 2)
            {
                //jackpot
                if (Barrels.Count >= 15)
                {


                    for (int k = 0; k < 15; k++)
                    {
                        if (first15Digits.Contains(ar[k]))
                            n++;
                    }

                }

            }
            if (n == 15)
            {
                SendToServer("jeckpot " + Program.ip);
            }
            else
            {
                n = 0;
            }
        }


        //проверка на победу во втором и третьем туре(не джекпот)
        private static void checkTour23(List<int> barrels, List<int> list, DataGridView dgv, DataGridView dgv1)
        {

            int secondTour = 0;
            if (tour == 2)
            {

                if (barrels.Count() >= 15)
                {

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (!flagManualMode)
                        {
                            if (barrels.Contains(list[i]))
                            {
                                secondTour++;
                                if (secondTour == 15)
                                {
                                    SendToServer("winTour2 " + Program.ip);
                                }
                            }
                        }
                        else
                        {
                            for (int o = 0; i < dgv.RowCount; i++)
                            {
                                for (int j = 0; j < dgv.ColumnCount; j++)
                                {
                                    if (dgv[o, j].Style.BackColor == Color.Crimson)
                                    {
                                        secondTour++;
                                        if (dgv1[o, j].Style.BackColor == Color.Crimson)
                                        {
                                            secondTour++;
                                            if (secondTour == 15)
                                            {
                                                SendToServer("winTour2 " + Program.ip);
                                            }
                                        }
                                    }
                                }

                            }

                        }
                    }




                    if (tour == 3)
                    {
                        if (barrels.Count() >= 30)
                        {

                            for (int i = 0; i < list.Count; i++)
                            {
                                if (!flagManualMode)
                                {
                                    if (barrels.Contains(list[i]))
                                    {
                                        secondTour++;
                                        if (secondTour == 30)
                                        {
                                            SendToServer("winTour3 " + Program.ip);
                                        }
                                    }
                                }
                                else
                                {
                                    for (int a = 0; i < dgv.RowCount; i++)
                                    {
                                        for (int j = 0; j < dgv.ColumnCount; j++)
                                        {
                                            if (dgv[a, j].Style.BackColor == Color.Crimson)
                                            {
                                                secondTour++;
                                                if (dgv1[i, j].Style.BackColor == Color.Crimson)
                                                {
                                                    secondTour++;
                                                    if (secondTour == 30)
                                                    {
                                                        SendToServer("winTour3 " + Program.ip);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
               
            
        
    
                        

                    






        private void generateTicket(DataGridView dgv, List<int> list)
        {
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgv.BackgroundColor =
            dgv.DefaultCellStyle.BackColor = Color.Tan;
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.ScrollBars = ScrollBars.None;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;
            dgv.ReadOnly=true;

            dgv.Rows.Clear();
            dgv.Columns.Clear();

            dgv.RowCount = 3;
            dgv.ColumnCount = 9;


            goTicket(dgv, list);


        }





        private static void SendToServer(string message)
        {
            IPAddress ipp = IPAddress.Parse(ip);
            IPEndPoint remoteep = new IPEndPoint(ipp, 25555);
            UdpClient udpclient = new UdpClient(); // создаем UdpClient для отправки сообщений
            byte[] buffer = Encoding.Unicode.GetBytes(message);
            udpclient.Send(buffer, buffer.Length, remoteep);


        }

      

        private void digit_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            var port = ran.Next(11111,25444) ;
           
           
            
            foreach (IPAddress v in Dns.GetHostAddresses(Dns.GetHostName()))
            {
               Program.ip= v.ToString();

            }
            Program.ip += ":" + port.ToString();
            label3.Text += Program.ip;
           
            string data = "data " +Program.ip + " " + Dns.GetHostName();
            SendToServer(data);
            add.BackColor = Color.Red;
            add.ForeColor = Color.Black;
            add.Enabled = false;
            label2.Text = "Ожидайте подключения...";
        }

        private void fMain_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (flagStart)
            {
                SendToServer("exit " + Program.ip);
                client1.Close();
                Application.Exit();
            }
            else
            {
                client1.Close();
                Application.Exit();
            }
        }

        private void manualMode_CheckedChanged(object sender, EventArgs e)
        {
            if(manualMode.Checked)
            {
                flagManualMode = true;
                
            }
            else
            {
                flagManualMode = false;
            }
        }

        private void ticketOne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkTicket(ticketOne, tic1);
        }
         private void ticketTwo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkTicket(ticketTwo, tic2);
        }
        public void checkTicket(DataGridView dgv,int[] ar)
        {
            if (flagManualMode && dgv.CurrentCell.Value != null)
                {
                    try
                    {
                        if (barrels.Contains(int.Parse(dgv.CurrentCell.Value.ToString())))
                    { 
                            dgv.CurrentCell.Style.BackColor = Color.Crimson;

                        
                            checkTour(dgv);
                            checkTour2Jackpot(dgv, barrels, ar);
                            checkTour23(barrels, markDigit,ticketOne,ticketTwo);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            
        }
    }




