using SmsControl.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unitronics.ComDriver;
using Unitronics.ComDriver.Messages.DataRequest;

namespace SmsControl
{
    public partial class Form1 : Form
    {
        #region Constants

        // PLC Configuration - Read from App.config
        private readonly string PLC_IP_ADDRESS;
        private readonly int PLC_PORT;
        private readonly int PLC_CONNECTION_TIMEOUT;
        private readonly int PLC_RETRIES;
        private const int PLC_UNIT_ID = 0;

        // Memory Address Constants
        private const ushort PHONE_NUMBERS_START_ADDRESS = 10;
        private const ushort PHONE_NUMBER_OPERAND_COUNT = 5;
        private const ushort PHONE_NUMBERS_TOTAL_COUNT = 20;
        private const int MAX_PHONE_NUMBERS = 4;

        private const ushort SIGNAL_STRENGTH_ADDRESS = 185;
        private const ushort MODEM_STATUS_ADDRESS = 99;
        private const ushort MODEM_FLAGS_ADDRESS = 751;
        private const ushort MODEM_FLAGS_COUNT = 4;
        private const ushort MODEM_INIT_ADDRESS = 114;
        private const ushort MODEM_TEST_ADDRESS = 757;

        private const long IRELAND_COUNTRY_CODE = 859124523;

        #endregion

        #region Fields

        PLC plc;
        string[] numbers = new string[MAX_PHONE_NUMBERS];

        #endregion

        public Form1()
        {
            InitializeComponent();

            // Load PLC configuration from App.config
            PLC_IP_ADDRESS = ConfigurationManager.AppSettings["PLC_IP_ADDRESS"] ?? "192.168.1.100";
            PLC_PORT = int.TryParse(ConfigurationManager.AppSettings["PLC_PORT"], out int port) ? port : 20257;
            PLC_CONNECTION_TIMEOUT = int.TryParse(ConfigurationManager.AppSettings["PLC_CONNECTION_TIMEOUT"], out int timeout) ? timeout : 3000;
            PLC_RETRIES = int.TryParse(ConfigurationManager.AppSettings["PLC_RETRIES"], out int retries) ? retries : 3;

            InitializeNumbers();
        }

        private void InitializeNumbers()
        {
            for (int i = 0; i < MAX_PHONE_NUMBERS; i++)
            {
                numbers[i] = string.Empty;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Ethernet ethernet = null;
            try
            {
                ethernet = new Ethernet(PLC_IP_ADDRESS, PLC_PORT, EthProtocol.TCP, PLC_RETRIES, PLC_CONNECTION_TIMEOUT);
                //ethernet.Password = "ADMIN12345";

                plc = PLCFactory.GetPLC(ethernet, PLC_UNIT_ID);

                if (plc == null)
                {
                    throw new InvalidOperationException("Failed to create PLC instance");
                }

                plc.EventAbortCompleted += new PLC.AbortCompletedDelegate(plc_EventAbortCompleted);
                PlcVersion version = plc.Version;

                logDebug(string.Format("Connected to PLC at {0}:{1}", PLC_IP_ADDRESS, PLC_PORT));

                setBtns(false);
                readNumbers();
            }
            catch (Exception ex)
            {
                setBtns(true);

                if (ethernet != null)
                {
                    try
                    {
                        ethernet.Disconnect();
                    }
                    catch
                    {
                        // Ignore disconnect errors
                    }
                }

                string errorMsg = "Could not establish a connection to the PLC: " + ex.Message;
                logDebug(errorMsg);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (plc == null)
            {
                logDebug("Not connected to PLC. Please connect first.");
                return;
            }

            List<int> changed = new List<int>();

            for (int i = 0; i < MAX_PHONE_NUMBERS; i++)
            {
                TextBox txtbox = this.groupBox1.Controls["txbxNumber" + (i + 1).ToString()] as TextBox;

                if (txtbox == null)
                {
                    logDebug(string.Format("Warning: Could not find textbox for operator {0}", i + 1));
                    continue;
                }

                if (!txtbox.Text.Equals(numbers[i]))
                {
                    changed.Add(i);
                }
            }

            if (changed.Count > 0)
            {
                foreach (var item in changed)
                {
                    TextBox txtbox = this.groupBox1.Controls["txbxNumber" + (item + 1).ToString()] as TextBox;

                    if (txtbox == null)
                        continue;

                    logDebug(string.Format("Operator {0} changed from '{1}' to '{2}'", 
                        item + 1, numbers[item], txtbox.Text));

                    try
                    {
                        var bytes = Encoding.ASCII.GetBytes(txtbox.Text);

                        var last = bytes.Skip(12).ToArray().ToLeInt();
                        var third = bytes.Skip(8).Take(4).ToArray().ToLeInt();
                        var second = bytes.Skip(4).Take(4).ToArray().ToLeInt();
                        var first = bytes.Take(4).ToArray().ToLeInt();

                        int startAddress = PHONE_NUMBERS_START_ADDRESS + (item * PHONE_NUMBER_OPERAND_COUNT);
                        writeNumbers(new int[] { first, second, third, last }, startAddress);
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = string.Format("Error processing number for Operator {0}: {1}", 
                            item + 1, ex.Message);
                        logDebug(errorMsg);
                    }
                }

                readNumbers();
            }
        }


        void writeNumbers(int[] operands, int startAddress)
        {
            if (plc == null)
            {
                logDebug("Error: PLC not connected");
                return;
            }

            if (operands == null || operands.Length == 0)
            {
                logDebug("Error: No operands to write");
                return;
            }

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
                logDebug(string.Format("Successfully wrote {0} operands to address {1}", 
                    operands.Length, startAddress));
            }
            catch (Exception ex)
            {
                string errorMsg = string.Format("Failed to write to PLC at address {0}: {1}", 
                    startAddress, ex.Message);
                logDebug(errorMsg);
            }
        }

        void readNumbers()
        {
            if (plc == null)
            {
                logDebug("Error: PLC not connected");
                return;
            }

            ReadWriteRequest[] rw = new ReadWriteRequest[1];

            rw[0] = new ReadOperands()
            {
                OperandType = OperandTypes.DW,
                NumberOfOperands = PHONE_NUMBERS_TOTAL_COUNT,
                StartAddress = PHONE_NUMBERS_START_ADDRESS
            };

            try
            {
                plc.ReadWrite(ref rw);

                object[] values = (object[])(rw[0].ResponseValues);

                if (values == null)
                {
                    logDebug("Warning: Received null values from PLC");
                    return;
                }

                for (int i = 0; i < MAX_PHONE_NUMBERS; i++)
                {
                    TextBox txtbox = this.groupBox1.Controls["txbxNumber" + (i + 1).ToString()] as TextBox;

                    if (txtbox == null)
                    {
                        logDebug(string.Format("Warning: Could not find textbox for operator {0}", i + 1));
                        continue;
                    }

                    var operandValues = values.Skip(i * PHONE_NUMBER_OPERAND_COUNT)
                                              .Take(PHONE_NUMBER_OPERAND_COUNT)
                                              .ToArray();

                    var convertedValues = convertValues(operandValues);
                    txtbox.Text = convertedValues;
                    numbers[i] = txtbox.Text;
                }

                logDebug("Phone numbers read successfully");
            }
            catch (Exception ex)
            {
                string errorMsg = "Failed to read from PLC: " + ex.Message;
                logDebug(errorMsg);
            }
        }

        string convertValues(object[] nums)
        {
            if (nums == null || nums.Length == 0)
                return string.Empty;

            string result = "";

            for (int i = 0; i < nums.Length; i++)
            {
                try
                {
                    string s = "";
                    var hex = objToHex(nums[i]);

                    if (hex.Length == 8)
                    {
                        s = "" + toChar(hex.Substring(6, 2)) + 
                                toChar(hex.Substring(4, 2)) + 
                                toChar(hex.Substring(2, 2)) + 
                                toChar(hex.Substring(0, 2));
                    }
                    else
                    {
                        s = "" + toChar(hex);
                    }
                    result += s;
                }
                catch (Exception ex)
                {
                    logDebug(string.Format("Error converting value at index {0}: {1}", i, ex.Message));
                }
            }

            return result;
        }

        char toChar(string s)
        {
            try
            {
                return (char)int.Parse(s, NumberStyles.AllowHexSpecifier);
            }
            catch
            {
                return '\0';
            }
        }

        string strToHex(string l) => string.Format("{0:X}", l);

        string objToHex(object l) => string.Format("{0:X8}", l);

        void logDebug(object[] msg)
        {
            if (msg == null)
                return;

            txbxDebug.Text = txbxDebug.Text + "\r\n" + string.Join(",", msg);
        }

        void logDebug(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return;

            txbxDebug.Text = txbxDebug.Text + "\r\n" + DateTime.Now.ToString("HH:mm:ss") + " - " + msg;
        }


        void plc_EventAbortCompleted()
        {
            MethodInvoker mi = delegate ()
            {
                logDebug("Requests abort completed");
            };

            if (this.InvokeRequired)
            {
                this.Invoke(mi);
            }
            else
            {
                mi();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (plc != null)
                {
                    plc.Disconnect();
                    logDebug("Disconnected from PLC");
                }
            }
            catch (Exception ex)
            {
                logDebug("Error during disconnect: " + ex.Message);
            }
            finally
            {
                plc = null;
                txbxDebug.Clear();
                setBtns(true);
            }
        }

        void setBtns(bool b)
        {
            btnConnect.Enabled = b;
            btnDisconnect.Enabled = !b;
            btnSend.Enabled = !b;
            btnTest.Enabled = !b;
            btnInit.Enabled = !b;

            for (int i = 1; i <= MAX_PHONE_NUMBERS; i++)
            {
                TextBox txtbox = this.groupBox1.Controls["txbxNumber" + i.ToString()] as TextBox;
                if (txtbox != null)
                {
                    txtbox.ReadOnly = b;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (btnConnect.Enabled || plc == null)
                return;

            ReadWriteRequest[] rw = new ReadWriteRequest[3];

            rw[0] = new ReadOperands()
            {
                OperandType = OperandTypes.SI,
                NumberOfOperands = 1,
                StartAddress = SIGNAL_STRENGTH_ADDRESS
            };

            rw[1] = new ReadOperands()
            {
                OperandType = OperandTypes.MI,
                NumberOfOperands = 1,
                StartAddress = MODEM_STATUS_ADDRESS
            };

            rw[2] = new ReadOperands()
            {
                OperandType = OperandTypes.MB,
                NumberOfOperands = MODEM_FLAGS_COUNT,
                StartAddress = MODEM_FLAGS_ADDRESS
            };

            try
            {
                plc.ReadWrite(ref rw);

                object[] values = (object[])(rw[0].ResponseValues);
                if (values != null && values.Length > 0)
                {
                    txbxSignal.Text = values[0].ToString();
                }

                values = (object[])(rw[1].ResponseValues);
                if (values != null && values.Length > 0)
                {
                    txbxStatus.Text = values[0].ToString();
                }

                values = (object[])(rw[2].ResponseValues);
                if (values != null && values.Length >= 4)
                {
                    lbModemBusy.Visible = values[0].ToString() == "1";
                    lbModemInit.Visible = values[3].ToString() == "1";
                }
            }
            catch (Exception ex)
            {
                logDebug("Monitoring error: " + ex.Message);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (plc == null)
            {
                logDebug("Not connected to PLC");
                return;
            }

            object[] values = new object[1];
            values[0] = (object)true;

            ReadWriteRequest[] rw = new ReadWriteRequest[1];

            rw[0] = new WriteOperands()
            {
                OperandType = OperandTypes.MB,
                NumberOfOperands = 1,
                StartAddress = MODEM_INIT_ADDRESS,
                Values = values
            };

            try
            {
                plc.ReadWrite(ref rw);
                logDebug("Modem initialization triggered");
            }
            catch (Exception ex)
            {
                string errorMsg = "Failed to initialize modem: " + ex.Message;
                logDebug(errorMsg);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (plc == null)
            {
                logDebug("Not connected to PLC");
                return;
            }

            object[] values = new object[1];
            values[0] = (object)true;

            ReadWriteRequest[] rw = new ReadWriteRequest[1];

            rw[0] = new WriteOperands()
            {
                OperandType = OperandTypes.MB,
                NumberOfOperands = 1,
                StartAddress = MODEM_TEST_ADDRESS,
                Values = values
            };

            try
            {
                plc.ReadWrite(ref rw);
                logDebug("Modem test command sent");
            }
            catch (Exception ex)
            {
                string errorMsg = "Failed to send test command: " + ex.Message;
                logDebug(errorMsg);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbxDebug.Clear();
        }

        private void NumberCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox checkBox))
            {
                return;
            }

            switch (checkBox.Name)
            {
                case "chbxNumber1":
                    // TODO: Handle checkbox for txbxNumber1.
                    break;
                case "chbxNumber2":
                    // TODO: Handle checkbox for txbxNumber2.
                    break;
                case "chbxNumber3":
                    // TODO: Handle checkbox for txbxNumber3.
                    break;
                case "chbxNumber4":
                    // TODO: Handle checkbox for txbxNumber4.
                    break;
                default:
                    logDebug("Unknown number checkbox changed: " + checkBox.Name);
                    break;
            }
        }
    }
}
