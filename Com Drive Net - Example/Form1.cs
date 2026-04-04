using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unitronics.ComDriver;
using Unitronics.ComDriver.Messages.DataRequest;
using System.Runtime.Remoting.Messaging;
using System.Reflection;

namespace Com_Drive_Net___Example
{
    public partial class Form1 : Form
    {
        PLC plc;
        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        public Form1()
        {
            InitializeComponent();
            setButtonsEnableState(false);
        }

        private void setButtonsEnableState(bool value)
        {
            Connect.Enabled = !value;
            Reset.Enabled  = value;
            Init.Enabled = value;
            Stop.Enabled = value;
            Run.Enabled = value;
            Disconnect.Enabled = value;
            Read.Enabled = value;
            ReadAsynch.Enabled = value;
            Write.Enabled = value;
            LongPeriodRead.Enabled = value;
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Ethernet ethernet = new Ethernet("192.168.1.100", 20256, EthProtocol.TCP, 3, 3000);
            ethernet.Password = "ADMIN12345";

            try
            {
                plc = PLCFactory.GetPLC(ethernet, 0);
                plc.EventAbortCompleted += new PLC.AbortCompletedDelegate(plc_EventAbortCompleted);
                setButtonsEnableState(true);
                PlcVersion version = plc.Version;
                txtModel.Text = version.OPLCModel;
                txtHW.Text = version.HWVersion;
                txtOS.Text = version.OSVersion;
                txtBoot.Text = version.Boot;
                txtBinLib.Text = version.BinLib;
                txtFactoryBoot.Text = version.FactoryBoot;
                try
                {
                    txtPlcName.Text = plc.PlcName;
                }
                catch
                {
                }
            }
            catch(Exception ex)
            {
                setButtonsEnableState(false);
                ethernet.Disconnect();
                System.Windows.Forms.MessageBox.Show("Could not establish a connection to the PLC: " + ex.Message);
            }
        }

        void plc_EventAbortCompleted()
        {
            MethodInvoker mi = delegate()
            {
                Abort.Enabled = false;
                System.Windows.Forms.MessageBox.Show("Requests abort completed");
            };
            UpdateUI(mi);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            try
            {
                plc.Reset();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Could not communicate with the PLC");
            }
        }

        private void Init_Click(object sender, EventArgs e)
        {
            try
            {
                plc.Init();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Could not communicate with the PLC");
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            try
            {
                plc.Stop();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Could not communicate with the PLC");
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            try
            {
                plc.Run();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Could not communicate with the PLC");
            }
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            plc.Disconnect();
            plc.EventAbortCompleted -= new PLC.AbortCompletedDelegate(plc_EventAbortCompleted);
            setButtonsEnableState(false);
            txtModel.Text = "";
            txtHW.Text = "";
            txtOS.Text = "";
            txtBoot.Text = "";
            txtBinLib.Text = "";
            txtFactoryBoot.Text = "";
            txtPlcName.Text = "";
        }

        private void Read_Click(object sender, EventArgs e)
        {
            ReadWriteRequest[] rw = new ReadWriteRequest[1];

            rw[0] = new ReadOperands()
            {
                OperandType = OperandTypes.MI,
                NumberOfOperands = 3,
                StartAddress = 0
            };

            try
            {
                plc.ReadWrite(ref rw);
                
                object[] values = (object[])(rw[0].ResponseValues);
                
                for (int i=0; i<values.Length; i++)
                {
                    if (values[i] != null)
                    {
                        TextBox txtbox = this.groupBox1.Controls["txtMI" + i.ToString()] as TextBox;
                        txtbox.Text = ((short)values[i]).ToString();
                    }
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Could not communicate with the PLC");
            }
        }

        private void Write_Click(object sender, EventArgs e)
        {
            object[] values = new object[3];
            try
            {
                values[0] = (object)Convert.ToInt16(txtMI0.Text);
                values[1] = (object)Convert.ToInt16(txtMI1.Text);
                values[2] = (object)Convert.ToInt16(txtMI2.Text);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("One of more of the values are not valid");
                return;
            }

            ReadWriteRequest[] rw = new ReadWriteRequest[1];

            rw[0] = new WriteOperands()
            {
                OperandType = OperandTypes.MI,
                NumberOfOperands = 3,
                StartAddress = 0,
                Values = values
            };


            try
            {
                plc.ReadWrite(ref rw);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Could not communicate with the PLC");
            }
        }

        private void ReadAsynch_Click(object sender, EventArgs e)
        {
            ReadWriteRequest[] rw = new ReadWriteRequest[1];

            rw[0] = new ReadOperands()
            {
                OperandType = OperandTypes.MI,
                NumberOfOperands = 3,
                StartAddress = 0
            };

            try
            {
                plc.ReadWrite(ref rw, AsyncReply);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Could not communicate with the PLC");
            }
        }

        private void TestAbortAsyncReply(IAsyncResult ar)
        {
            AsyncResult async;
            async = (AsyncResult)ar;
            ReadWriteOperandsDelegate del = (ReadWriteOperandsDelegate)async.AsyncDelegate;
            ReadWriteRequest[] rw = new ReadWriteRequest[0];
            try
            {
                del.EndInvoke(ref rw, ar);
            }
            catch (ComDriveExceptions ex)
            {
                if (ex.ErrorCode == ComDriveExceptions.ComDriveException.AbortedByUser)
                {
                    System.Diagnostics.Debug.Print("Aborted by user");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Unexpected error");
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Unexpected error");
            }
        }

        private void AsyncReply(IAsyncResult ar)
        {
            AsyncResult async;
            async = (AsyncResult)ar;
            ReadWriteOperandsDelegate del = (ReadWriteOperandsDelegate)async.AsyncDelegate;
            ReadWriteRequest[] rw = new ReadWriteRequest[0];

            try
            {
                del.EndInvoke(ref rw, ar);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return;
            }

            object[] values = (object[])(rw[0].ResponseValues);

            MethodInvoker mi = delegate()
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] != null)
                    {
                        TextBox txtbox = this.groupBox1.Controls["txtMI" + i.ToString()] as TextBox;
                        txtbox.Text = Convert.ToInt16(values[i]).ToString();
                    }
                }

                Abort.Enabled = false;
            };
            UpdateUI(mi);
        }

        private void UpdateUI(MethodInvoker del)
        {
            if (this.InvokeRequired)
                this.Invoke(del);
            else
                del();
        }

        private void LongPeriodRead_Click(object sender, EventArgs e)
        {
            Abort.Enabled = true;
            for (int i = 0; i < 10; i++)
            {
                ReadWriteRequest[] rw = new ReadWriteRequest[8];

                rw[0] = new ReadOperands()
                {
                    OperandType = OperandTypes.MB,
                    NumberOfOperands = 4096,
                    StartAddress = 0
                };

                rw[1] = new ReadOperands()
                {
                    OperandType = OperandTypes.MI,
                    NumberOfOperands = 2048,
                    StartAddress = 0
                };

                rw[2] = new ReadOperands()
                {
                    OperandType = OperandTypes.ML,
                    NumberOfOperands = 256,
                    StartAddress = 0
                };

                rw[3] = new ReadOperands()
                {
                    OperandType = OperandTypes.DW,
                    NumberOfOperands = 64,
                    StartAddress = 0
                };


                rw[4] = new ReadOperands()
                {
                    OperandType = OperandTypes.SB,
                    NumberOfOperands = 512,
                    StartAddress = 0
                };

                rw[5] = new ReadOperands()
                {
                    OperandType = OperandTypes.SI,
                    NumberOfOperands = 512,
                    StartAddress = 0
                };

                rw[6] = new ReadOperands()
                {
                    OperandType = OperandTypes.SL,
                    NumberOfOperands = 56,
                    StartAddress = 0
                };

                rw[7] = new ReadOperands()
                {
                    OperandType = OperandTypes.SDW,
                    NumberOfOperands = 64,
                    StartAddress = 0
                };

                try
                {
                    plc.ReadWrite(ref rw, TestAbortAsyncReply);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Could not communicate with the PLC");
                }
            }
        }

        private void Abort_Click(object sender, EventArgs e)
        {
            plc.Abort();
        }
    }
}