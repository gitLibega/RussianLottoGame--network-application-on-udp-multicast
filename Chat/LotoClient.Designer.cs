namespace Chat
{
    partial class LotoClient
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LotoClient));
			this.ticketTwo = new System.Windows.Forms.DataGridView();
			this.ticketOne = new System.Windows.Forms.DataGridView();
			this.digit = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.manualMode = new System.Windows.Forms.CheckBox();
			this.add = new System.Windows.Forms.Button();
			this.time = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lsbxChat = new System.Windows.Forms.ListBox();
			this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
			((System.ComponentModel.ISupportInitialize)(this.ticketTwo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ticketOne)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
			this.SuspendLayout();
			// 
			// ticketTwo
			// 
			this.ticketTwo.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			this.ticketTwo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ticketTwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ticketTwo.GridColor = System.Drawing.Color.Orange;
			this.ticketTwo.Location = new System.Drawing.Point(18, 427);
			this.ticketTwo.Name = "ticketTwo";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ticketTwo.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.ticketTwo.RowHeadersWidth = 51;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
			this.ticketTwo.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.ticketTwo.RowTemplate.Height = 24;
			this.ticketTwo.Size = new System.Drawing.Size(491, 114);
			this.ticketTwo.TabIndex = 12;
			this.ticketTwo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ticketTwo_CellClick);
			// 
			// ticketOne
			// 
			this.ticketOne.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
			this.ticketOne.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ticketOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ticketOne.GridColor = System.Drawing.Color.Orange;
			this.ticketOne.Location = new System.Drawing.Point(18, 300);
			this.ticketOne.Name = "ticketOne";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ticketOne.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.ticketOne.RowHeadersWidth = 51;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
			this.ticketOne.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.ticketOne.RowTemplate.Height = 24;
			this.ticketOne.Size = new System.Drawing.Size(491, 119);
			this.ticketOne.TabIndex = 15;
			this.ticketOne.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ticketOne_CellClick);
			// 
			// digit
			// 
			this.digit.AutoSize = true;
			this.digit.BackColor = System.Drawing.Color.Transparent;
			this.digit.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.digit.Location = new System.Drawing.Point(33, 42);
			this.digit.Name = "digit";
			this.digit.Size = new System.Drawing.Size(56, 41);
			this.digit.TabIndex = 20;
			this.digit.Text = "91";
			this.digit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.BackgroundImage = global::Chat.Properties.Resources.Снимок;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.digit);
			this.panel1.Location = new System.Drawing.Point(186, 31);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(120, 118);
			this.panel1.TabIndex = 21;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 22);
			this.label1.TabIndex = 21;
			this.label1.Text = "Tour:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.BackgroundImage = global::Chat.Properties.Resources.iCZLIV3KN;
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(18, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(503, 551);
			this.groupBox1.TabIndex = 23;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Готовность";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.manualMode);
			this.groupBox2.Controls.Add(this.add);
			this.groupBox2.Controls.Add(this.time);
			this.groupBox2.Location = new System.Drawing.Point(50, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(397, 357);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(17, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(195, 18);
			this.label2.TabIndex = 7;
			this.label2.Text = "Розыгрыш скоро начнется";
			// 
			// manualMode
			// 
			this.manualMode.AutoSize = true;
			this.manualMode.BackColor = System.Drawing.Color.DarkOrange;
			this.manualMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.manualMode.Location = new System.Drawing.Point(105, 261);
			this.manualMode.Name = "manualMode";
			this.manualMode.Size = new System.Drawing.Size(171, 29);
			this.manualMode.TabIndex = 26;
			this.manualMode.Text = "Ручной режим";
			this.manualMode.UseVisualStyleBackColor = false;
			this.manualMode.CheckedChanged += new System.EventHandler(this.manualMode_CheckedChanged);
			// 
			// add
			// 
			this.add.BackColor = System.Drawing.Color.Red;
			this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.add.ForeColor = System.Drawing.Color.Black;
			this.add.Location = new System.Drawing.Point(73, 160);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(275, 95);
			this.add.TabIndex = 1;
			this.add.Text = "Присоедениться ";
			this.add.UseVisualStyleBackColor = false;
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// time
			// 
			this.time.AutoSize = true;
			this.time.BackColor = System.Drawing.Color.Transparent;
			this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.time.Location = new System.Drawing.Point(168, 18);
			this.time.Name = "time";
			this.time.Size = new System.Drawing.Size(62, 44);
			this.time.TabIndex = 0;
			this.time.Text = "20";
			this.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Modern No. 20", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(15, 544);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 16);
			this.label3.TabIndex = 25;
			this.label3.Text = "Ticket №:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lsbxChat
			// 
			this.lsbxChat.BackColor = System.Drawing.Color.Orange;
			this.lsbxChat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lsbxChat.FormattingEnabled = true;
			this.lsbxChat.ItemHeight = 23;
			this.lsbxChat.Location = new System.Drawing.Point(18, 174);
			this.lsbxChat.Margin = new System.Windows.Forms.Padding(4);
			this.lsbxChat.Name = "lsbxChat";
			this.lsbxChat.Size = new System.Drawing.Size(491, 119);
			this.lsbxChat.TabIndex = 27;
			// 
			// axWindowsMediaPlayer1
			// 
			this.axWindowsMediaPlayer1.Enabled = true;
			this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(349, 174);
			this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
			this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
			this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(160, 120);
			this.axWindowsMediaPlayer1.TabIndex = 28;
			// 
			// LotoClient
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.BackgroundImage = global::Chat.Properties.Resources.iCZLIV3KN;
			this.ClientSize = new System.Drawing.Size(533, 565);
			this.Controls.Add(this.axWindowsMediaPlayer1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ticketTwo);
			this.Controls.Add(this.ticketOne);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lsbxChat);
			this.Controls.Add(this.label1);
			this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LotoClient";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Лото";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing_1);
			((System.ComponentModel.ISupportInitialize)(this.ticketTwo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ticketOne)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.DataGridView ticketTwo;
		private System.Windows.Forms.DataGridView ticketOne;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label digit;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button add;
		private System.Windows.Forms.Label time;
		public System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox manualMode;
		private System.Windows.Forms.ListBox lsbxChat;
		private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
	}
}

