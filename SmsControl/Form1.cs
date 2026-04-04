using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unitronics.ComDriver;
using Unitronics.ComDriver.Messages.DataRequest;
using System.Buffers.Binary;
using SmsControl.Extensions;

namespace SmsControl
{
    public partial class Form1 : Form
    {
        PLC plc;
        string[] numbers = new string[4];

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Ethernet ethernet = new Ethernet("192.168.1.100", 20257, EthProtocol.TCP, 3, 3000);
            //ethernet.Password = "ADMIN12345";

            try
            {
                plc = PLCFactory.GetPLC(ethernet, 0);
                plc.EventAbortCompleted += new PLC.AbortCompletedDelegate(plc_EventAbortCompleted);
                PlcVersion version = plc.Version;
                logDebug("Connected");
                setBtns(false);
                readNumbers();
            }
            catch (Exception ex)
            {
                setBtns(true);
                ethernet.Disconnect();
                logDebug("Could not establish a connection to the PLC: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            List<int> changed = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                // check any numbers changed
                TextBox txtbox = this.groupBox1.Controls["txbxNumber" + (i + 1).ToString()] as TextBox;
                if (!txtbox.Text.Equals(numbers[i]))
                {
                    changed.Add(i);
                }
            }
            if (changed.Count() > 0)
            {
                foreach (var item in changed)
                {
                    TextBox txtbox = this.groupBox1.Controls["txbxNumber" + (item + 1).ToString()] as TextBox;

                    logDebug(item + " has been changed, number " + numbers[item] + ", new number " + txtbox.Text);

                    var bytes = Encoding.ASCII.GetBytes(txtbox.Text); // should be +353 8583 4975 1 

                    // the first number (prefix) is always (+353 which is 859124523)
                    long prefix = 859124523;
                        
                    // convert in groups of four
                    // start address would be 10 + item*5
                    var last = bytes.Skip(12).ToArray().ToLeInt();
                    var third = bytes.Skip(8).Take(4).ToArray().ToLeInt();
                    var second = bytes.Skip(4).Take(4).ToArray().ToLeInt();
                    var first = bytes.Take(4).ToArray().ToLeInt();
                    writeNumbers(new int[] { first, second, third, last }, item * 5 + 10);
                }
            }
            readNumbers();
        }


        void writeNumbers(int[] operands, int startAddress)
        {
            ReadWriteRequest[] rw = new ReadWriteRequest[1];

            rw[0] = new WriteOperands()
            {
                OperandType = OperandTypes.DW,
                NumberOfOperands = (ushort)operands.Length,
                StartAddress = (ushort)startAddress,
                Values = operands.Select(p => (object)p).ToArray()
            };

            try
            {
                plc.ReadWrite(ref rw);
            }
            catch (Exception ex)
            {

                logDebug(ex.Message);
            }
        }

        void readNumbers()
        {
            ReadWriteRequest[] rw = new ReadWriteRequest[1];

            rw[0] = new ReadOperands()
            {
                OperandType = OperandTypes.DW,
                NumberOfOperands = 20,
                StartAddress = 10
            };

            try
            {
                plc.ReadWrite(ref rw);

                object[] values = (object[])(rw[0].ResponseValues);

                for (int i = 0; i <= 3; i++)
                {                    
                    TextBox txtbox = this.groupBox1.Controls["txbxNumber" + (i+1).ToString()] as TextBox;
                    var convertedValues = convertValues(values.Skip(i * 5).Take(5).ToArray());
                    txtbox.Text = convertedValues;
                    numbers[i] = txtbox.Text;
                }
            }
            catch(Exception ex) {
            
               logDebug(ex.Message);
            }
        }

        string convertValues(object[] nums)
        {
            string result = "";

            for(int i = 0; i < nums.Length; i++)
            {
                string s = "";
                var hex = objToHex(nums[i]);
                if (hex.Length == 8)
                {
                    s = "" + toChar(hex.Substring(6)) + toChar(hex.Substring(4, 2)) + toChar(hex.Substring(2, 2)) + toChar(hex.Substring(0, 2));
                } else
                {
                    s = "" + toChar(hex);
                }
                result += s;
            }


            return result;
        }

        char toChar(string s) => (char)int.Parse(s, NumberStyles.AllowHexSpecifier);

        string strToHex(string l) => string.Format("{0:X}", l);
        string objToHex(object l) => string.Format("{0:X}", l);

        void logDebug(object[] msg)
        {
            txbxDebug.Text = txbxDebug.Text + "\r" + string.Join(",", msg) ;
        }

        void logDebug(string msg)
        {
            txbxDebug.Text = txbxDebug.Text + "\r\n" + msg;
        }


        void plc_EventAbortCompleted()
        {
            MethodInvoker mi = delegate ()
            {
                //Abort.Enabled = false;
                logDebug("Requests abort completed");
            };
            //UpdateUI(mi);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            plc.Disconnect();
            logDebug("Disconnected");
            txbxDebug.Clear();
            setBtns(true);
        }

        void setBtns(bool b)
        {
            btnConnect.Enabled = b;
            btnDisconnect.Enabled = !b;
            btnSend.Enabled = !b;
            btnTest.Enabled = !b;
            btnInit.Enabled = !b;

            for (int i = 1; i <= 4; i++)
            {
                TextBox txtbox = this.groupBox1.Controls["txbxNumber" + (i).ToString()] as TextBox;
                txtbox.ReadOnly = b;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!btnConnect.Enabled)
            {
                ReadWriteRequest[] rw = new ReadWriteRequest[3];
                rw[0] = new ReadOperands()
                {
                    OperandType = OperandTypes.SI,
                    NumberOfOperands = 1,
                    StartAddress = 185
                };
                rw[1] = new ReadOperands()
                {
                    OperandType = OperandTypes.MI,
                    NumberOfOperands = 1,
                    StartAddress = 99
                };
                rw[2] = new ReadOperands()
                {
                    OperandType = OperandTypes.MB,
                    NumberOfOperands = 4,
                    StartAddress = 751
                };
                try
                {                    
                    plc.ReadWrite(ref rw);

                    object[] values = (object[])(rw[0].ResponseValues);
                    txbxSignal.Text = values[0].ToString();

                    values = (object[])(rw[1].ResponseValues);
                    txbxStatus.Text = values[0].ToString();

                    values = (object[])(rw[2].ResponseValues);
                    lbModemBusy.Visible = values[0].ToString()=="1";

                    lbModemInit.Visible = values[3].ToString() == "1";

                }
                catch (Exception ex) {

                    logDebug(ex.Message);
                }
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (!btnConnect.Enabled)
            {
                object[] values = new object[1];

                values[0] = (object)true;

                ReadWriteRequest[] rw = new ReadWriteRequest[1];

                rw[0] = new WriteOperands()
                {
                    OperandType = OperandTypes.MB,
                    NumberOfOperands = 1,
                    StartAddress = 114,
                    Values = values
                };

                try
                {
                    plc.ReadWrite(ref rw);
                }
                catch (Exception ex)
                {
                    logDebug(ex.Message);
                }
            }

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!btnConnect.Enabled)
            {
                object[] values = new object[1];

                values[0] = (object)true;

                ReadWriteRequest[] rw = new ReadWriteRequest[1];

                rw[0] = new WriteOperands()
                {
                    OperandType = OperandTypes.MB,
                    NumberOfOperands = 1,
                    StartAddress = 757,
                    Values = values
                };

                try
                {
                    plc.ReadWrite(ref rw);
                }
                catch (Exception ex)
                {
                    logDebug(ex.Message);
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbxDebug.Clear();
        }
    }
}
