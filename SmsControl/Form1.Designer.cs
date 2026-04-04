namespace SmsControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txbxNumber1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbxNumber2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbxNumber3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbxNumber4 = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txbxDebug = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbxStatus = new System.Windows.Forms.TextBox();
            this.txbxSignal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbModemBusy = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbModemInit = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbxNumber1
            // 
            this.txbxNumber1.Location = new System.Drawing.Point(112, 29);
            this.txbxNumber1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbxNumber1.Name = "txbxNumber1";
            this.txbxNumber1.ReadOnly = true;
            this.txbxNumber1.Size = new System.Drawing.Size(277, 26);
            this.txbxNumber1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operator 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Operator 2";
            // 
            // txbxNumber2
            // 
            this.txbxNumber2.Location = new System.Drawing.Point(112, 65);
            this.txbxNumber2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbxNumber2.Name = "txbxNumber2";
            this.txbxNumber2.ReadOnly = true;
            this.txbxNumber2.Size = new System.Drawing.Size(277, 26);
            this.txbxNumber2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Operator 3";
            // 
            // txbxNumber3
            // 
            this.txbxNumber3.Location = new System.Drawing.Point(112, 101);
            this.txbxNumber3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbxNumber3.Name = "txbxNumber3";
            this.txbxNumber3.ReadOnly = true;
            this.txbxNumber3.Size = new System.Drawing.Size(277, 26);
            this.txbxNumber3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Operator 4";
            // 
            // txbxNumber4
            // 
            this.txbxNumber4.Location = new System.Drawing.Point(112, 137);
            this.txbxNumber4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbxNumber4.Name = "txbxNumber4";
            this.txbxNumber4.ReadOnly = true;
            this.txbxNumber4.Size = new System.Drawing.Size(277, 26);
            this.txbxNumber4.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(49, 173);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(166, 34);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbxNumber4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbxNumber3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbxNumber2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbxNumber1);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(537, 235);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Number Control";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(397, 29);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(111, 178);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(223, 173);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(166, 34);
            this.btnDisconnect.TabIndex = 13;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txbxDebug
            // 
            this.txbxDebug.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txbxDebug.Location = new System.Drawing.Point(561, 20);
            this.txbxDebug.Multiline = true;
            this.txbxDebug.Name = "txbxDebug";
            this.txbxDebug.ReadOnly = true;
            this.txbxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbxDebug.Size = new System.Drawing.Size(220, 384);
            this.txbxDebug.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbModemInit);
            this.groupBox2.Controls.Add(this.lbModemBusy);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txbxStatus);
            this.groupBox2.Controls.Add(this.txbxSignal);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnInit);
            this.groupBox2.Controls.Add(this.btnTest);
            this.groupBox2.Location = new System.Drawing.Point(18, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 194);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modem Control";
            // 
            // txbxStatus
            // 
            this.txbxStatus.Location = new System.Drawing.Point(73, 114);
            this.txbxStatus.Name = "txbxStatus";
            this.txbxStatus.ReadOnly = true;
            this.txbxStatus.Size = new System.Drawing.Size(116, 26);
            this.txbxStatus.TabIndex = 19;
            // 
            // txbxSignal
            // 
            this.txbxSignal.Location = new System.Drawing.Point(73, 75);
            this.txbxSignal.Name = "txbxSignal";
            this.txbxSignal.ReadOnly = true;
            this.txbxSignal.Size = new System.Drawing.Size(116, 26);
            this.txbxSignal.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Signal";
            // 
            // btnInit
            // 
            this.btnInit.Enabled = false;
            this.btnInit.Location = new System.Drawing.Point(301, 78);
            this.btnInit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(166, 34);
            this.btnInit.TabIndex = 16;
            this.btnInit.Text = "Initialise";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(301, 122);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(166, 34);
            this.btnTest.TabIndex = 15;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "SI185";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 30);
            this.label7.TabIndex = 21;
            this.label7.Text = "MI99";
            // 
            // lbModemBusy
            // 
            this.lbModemBusy.AutoSize = true;
            this.lbModemBusy.Location = new System.Drawing.Point(327, 52);
            this.lbModemBusy.Name = "lbModemBusy";
            this.lbModemBusy.Size = new System.Drawing.Size(101, 20);
            this.lbModemBusy.TabIndex = 22;
            this.lbModemBusy.Text = "Modem Busy";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(561, 412);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(220, 34);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbModemInit
            // 
            this.lbModemInit.AutoSize = true;
            this.lbModemInit.Location = new System.Drawing.Point(327, 22);
            this.lbModemInit.Name = "lbModemInit";
            this.lbModemInit.Size = new System.Drawing.Size(141, 30);
            this.lbModemInit.TabIndex = 23;
            this.lbModemInit.Text = "SMS Config";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 464);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txbxDebug);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "WSL SMS";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbxNumber1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbxNumber2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbxNumber3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbxNumber4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbxDebug;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txbxSignal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbxStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbModemBusy;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbModemInit;
    }
}

