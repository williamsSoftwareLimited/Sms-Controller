namespace Com_Drive_Net___Example
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
            this.Connect = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.Init = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.Disconnect = new System.Windows.Forms.Button();
            this.plcInformation = new System.Windows.Forms.GroupBox();
            this.txtPlcName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtFactoryBoot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBinLib = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReadAsynch = new System.Windows.Forms.Button();
            this.txtMI2 = new System.Windows.Forms.TextBox();
            this.txtMI1 = new System.Windows.Forms.TextBox();
            this.txtMI0 = new System.Windows.Forms.TextBox();
            this.Write = new System.Windows.Forms.Button();
            this.Read = new System.Windows.Forms.Button();
            this.LongPeriodRead = new System.Windows.Forms.Button();
            this.Abort = new System.Windows.Forms.Button();
            this.plcInformation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(12, 12);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(113, 22);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Connect to PLC";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(12, 40);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(113, 22);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset PLC";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Init
            // 
            this.Init.Location = new System.Drawing.Point(12, 68);
            this.Init.Name = "Init";
            this.Init.Size = new System.Drawing.Size(113, 22);
            this.Init.TabIndex = 2;
            this.Init.Text = "Init PLC";
            this.Init.UseVisualStyleBackColor = true;
            this.Init.Click += new System.EventHandler(this.Init_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(12, 96);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(113, 22);
            this.Stop.TabIndex = 3;
            this.Stop.Text = "Stop PLC";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(12, 124);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(113, 22);
            this.Run.TabIndex = 4;
            this.Run.Text = "Run PLC";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Disconnect
            // 
            this.Disconnect.Location = new System.Drawing.Point(12, 152);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(113, 22);
            this.Disconnect.TabIndex = 5;
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // plcInformation
            // 
            this.plcInformation.Controls.Add(this.txtPlcName);
            this.plcInformation.Controls.Add(this.label7);
            this.plcInformation.Controls.Add(this.txtModel);
            this.plcInformation.Controls.Add(this.txtFactoryBoot);
            this.plcInformation.Controls.Add(this.label6);
            this.plcInformation.Controls.Add(this.txtBinLib);
            this.plcInformation.Controls.Add(this.label5);
            this.plcInformation.Controls.Add(this.txtBoot);
            this.plcInformation.Controls.Add(this.label4);
            this.plcInformation.Controls.Add(this.txtOS);
            this.plcInformation.Controls.Add(this.label3);
            this.plcInformation.Controls.Add(this.txtHW);
            this.plcInformation.Controls.Add(this.label2);
            this.plcInformation.Controls.Add(this.label1);
            this.plcInformation.Location = new System.Drawing.Point(143, 12);
            this.plcInformation.Name = "plcInformation";
            this.plcInformation.Size = new System.Drawing.Size(246, 197);
            this.plcInformation.TabIndex = 18;
            this.plcInformation.TabStop = false;
            this.plcInformation.Text = "PLC Information";
            // 
            // txtPlcName
            // 
            this.txtPlcName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPlcName.Location = new System.Drawing.Point(88, 170);
            this.txtPlcName.Name = "txtPlcName";
            this.txtPlcName.ReadOnly = true;
            this.txtPlcName.Size = new System.Drawing.Size(152, 20);
            this.txtPlcName.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "PLC Name";
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.SystemColors.Window;
            this.txtModel.Location = new System.Drawing.Point(88, 15);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(152, 20);
            this.txtModel.TabIndex = 3;
            // 
            // txtFactoryBoot
            // 
            this.txtFactoryBoot.BackColor = System.Drawing.SystemColors.Window;
            this.txtFactoryBoot.Location = new System.Drawing.Point(88, 144);
            this.txtFactoryBoot.Name = "txtFactoryBoot";
            this.txtFactoryBoot.ReadOnly = true;
            this.txtFactoryBoot.Size = new System.Drawing.Size(152, 20);
            this.txtFactoryBoot.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Factory Boot";
            // 
            // txtBinLib
            // 
            this.txtBinLib.BackColor = System.Drawing.SystemColors.Window;
            this.txtBinLib.Location = new System.Drawing.Point(88, 118);
            this.txtBinLib.Name = "txtBinLib";
            this.txtBinLib.ReadOnly = true;
            this.txtBinLib.Size = new System.Drawing.Size(152, 20);
            this.txtBinLib.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "BinLib Version";
            // 
            // txtBoot
            // 
            this.txtBoot.BackColor = System.Drawing.SystemColors.Window;
            this.txtBoot.Location = new System.Drawing.Point(88, 92);
            this.txtBoot.Name = "txtBoot";
            this.txtBoot.ReadOnly = true;
            this.txtBoot.Size = new System.Drawing.Size(152, 20);
            this.txtBoot.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Boot Version";
            // 
            // txtOS
            // 
            this.txtOS.BackColor = System.Drawing.SystemColors.Window;
            this.txtOS.Location = new System.Drawing.Point(88, 66);
            this.txtOS.Name = "txtOS";
            this.txtOS.ReadOnly = true;
            this.txtOS.Size = new System.Drawing.Size(152, 20);
            this.txtOS.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "OS Version";
            // 
            // txtHW
            // 
            this.txtHW.BackColor = System.Drawing.SystemColors.Window;
            this.txtHW.Location = new System.Drawing.Point(88, 40);
            this.txtHW.Name = "txtHW";
            this.txtHW.ReadOnly = true;
            this.txtHW.Size = new System.Drawing.Size(152, 20);
            this.txtHW.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "HW Revision";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "PLC Model";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Abort);
            this.groupBox1.Controls.Add(this.LongPeriodRead);
            this.groupBox1.Controls.Add(this.ReadAsynch);
            this.groupBox1.Controls.Add(this.txtMI2);
            this.groupBox1.Controls.Add(this.txtMI1);
            this.groupBox1.Controls.Add(this.txtMI0);
            this.groupBox1.Controls.Add(this.Write);
            this.groupBox1.Controls.Add(this.Read);
            this.groupBox1.Location = new System.Drawing.Point(12, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 145);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MI 0 to 2";
            // 
            // ReadAsynch
            // 
            this.ReadAsynch.Location = new System.Drawing.Point(6, 47);
            this.ReadAsynch.Name = "ReadAsynch";
            this.ReadAsynch.Size = new System.Drawing.Size(113, 22);
            this.ReadAsynch.TabIndex = 7;
            this.ReadAsynch.Text = "Async Val Read";
            this.ReadAsynch.UseVisualStyleBackColor = true;
            this.ReadAsynch.Click += new System.EventHandler(this.ReadAsynch_Click);
            // 
            // txtMI2
            // 
            this.txtMI2.Location = new System.Drawing.Point(131, 74);
            this.txtMI2.Name = "txtMI2";
            this.txtMI2.Size = new System.Drawing.Size(114, 20);
            this.txtMI2.TabIndex = 2;
            // 
            // txtMI1
            // 
            this.txtMI1.Location = new System.Drawing.Point(131, 48);
            this.txtMI1.Name = "txtMI1";
            this.txtMI1.Size = new System.Drawing.Size(114, 20);
            this.txtMI1.TabIndex = 1;
            // 
            // txtMI0
            // 
            this.txtMI0.Location = new System.Drawing.Point(131, 21);
            this.txtMI0.Name = "txtMI0";
            this.txtMI0.Size = new System.Drawing.Size(114, 20);
            this.txtMI0.TabIndex = 0;
            // 
            // Write
            // 
            this.Write.Location = new System.Drawing.Point(6, 72);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(113, 22);
            this.Write.TabIndex = 6;
            this.Write.Text = "Write Values";
            this.Write.UseVisualStyleBackColor = true;
            this.Write.Click += new System.EventHandler(this.Write_Click);
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(6, 19);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(113, 22);
            this.Read.TabIndex = 5;
            this.Read.Text = "Read Values";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // LongPeriodRead
            // 
            this.LongPeriodRead.Location = new System.Drawing.Point(6, 100);
            this.LongPeriodRead.Name = "LongPeriodRead";
            this.LongPeriodRead.Size = new System.Drawing.Size(113, 22);
            this.LongPeriodRead.TabIndex = 8;
            this.LongPeriodRead.Text = "Long Period Read";
            this.LongPeriodRead.UseVisualStyleBackColor = true;
            this.LongPeriodRead.Click += new System.EventHandler(this.LongPeriodRead_Click);
            // 
            // Abort
            // 
            this.Abort.Enabled = false;
            this.Abort.Location = new System.Drawing.Point(132, 100);
            this.Abort.Name = "Abort";
            this.Abort.Size = new System.Drawing.Size(113, 22);
            this.Abort.TabIndex = 9;
            this.Abort.Text = "Abort";
            this.Abort.UseVisualStyleBackColor = true;
            this.Abort.Click += new System.EventHandler(this.Abort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 372);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.plcInformation);
            this.Controls.Add(this.Disconnect);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Init);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Connect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.plcInformation.ResumeLayout(false);
            this.plcInformation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Init;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.GroupBox plcInformation;
        private System.Windows.Forms.TextBox txtFactoryBoot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBinLib;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Write;
        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtMI2;
        private System.Windows.Forms.TextBox txtMI1;
        private System.Windows.Forms.TextBox txtMI0;
        private System.Windows.Forms.Button ReadAsynch;
        private System.Windows.Forms.TextBox txtPlcName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Abort;
        private System.Windows.Forms.Button LongPeriodRead;
    }
}

