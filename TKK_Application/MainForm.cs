using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Automation.BDaq;


namespace TKK_Application
{
    public partial class TKK : Form
    {
        private Parametri_skenera param_skenera;

        SerialPort _serialPort;
        private Label[] m_portNum;
        private Label[] m_portHex;

        public TKK()
        {
            InitializeComponent();
            instantDoCtrl1.SelectedDevice = new DeviceInformation(0);
            instantDiCtrl1.SelectedDevice = new DeviceInformation(0);

            if (!instantDoCtrl1.Initialized)
            {
                MessageBox.Show("No device be selected or device open failed!", "StaticDO");
                this.Close();
                return;
            }

            if (!instantDiCtrl1.Initialized)
            {
                MessageBox.Show("No device be selected or device open failed!", "StaticDI");
                this.Close();
                return;
            }


        }

        private void postavkeSkeneraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            param_skenera = new Parametri_skenera();
            param_skenera.Show();
        }

        void Init_scanner_connection()
        {

        }

        private void InitializePortState()
        {
            byte portData = 0;
            byte portDir = 0xFF;
            ErrorCode err = ErrorCode.Success;
            byte[] mask = instantDoCtrl1.Features.DoDataMask;
            for (int i = 0; (i + ConstVal.StartPort) < instantDoCtrl1.Features.PortCount && i < ConstVal.PortCountShow; ++i)
            {
                err = instantDoCtrl1.Read(i + ConstVal.StartPort, out portData);
                if (err != ErrorCode.Success)
                {
                    HandleError(err);
                    return;
                }

                m_portNum[i].Text = (i + ConstVal.StartPort).ToString();
                m_portHex[i].Text = portData.ToString("X2");

                if (instantDoCtrl1.Ports != null)
                {
                    portDir = (byte)instantDoCtrl1.Ports[i + ConstVal.StartPort].DirectionMask;
                }
/*
                // Set picture box state
                for (int j = 0; j < 8; ++j)
                {
                    if (((portDir >> j) & 0x1) == 0 || ((mask[i] >> j) & 0x1) == 0)  // Bit direction is input.
                    {
                        m_pictrueBox[i, j].Image = imageList1.Images[2];
                        m_pictrueBox[i, j].Enabled = false;
                    }
                    else
                    {
                        m_pictrueBox[i, j].Click += new EventHandler(PictureBox_Click);
                        m_pictrueBox[i, j].Tag = new DoBitInformation((portData >> j) & 0x1, i + ConstVal.StartPort, j);
                        m_pictrueBox[i, j].Image = imageList1.Images[(portData >> j) & 0x1];
                    }
                    m_pictrueBox[i, j].Invalidate();
 */
                }
            }

        private void HandleError(ErrorCode err)
        {
            if ((err >= ErrorCode.ErrorHandleNotValid) && (err != ErrorCode.Success))
            {
                MessageBox.Show("Sorry ! Some errors happened, the error code is: " + err.ToString());
            }
        }

        public static class ConstVal
        {
            public const int StartPort = 0;
            public const int PortCountShow = 4;
        }

        public struct DoBitInformation
        {
            #region fields
            private int m_bitValue;
            private int m_portNum;
            private int m_bitNum;
            #endregion

            public DoBitInformation(int bitvalue, int portNum, int bitNum)
            {
                m_bitValue = bitvalue;
                m_portNum = portNum;
                m_bitNum = bitNum;
            }

            #region Properties
            public int BitValue
            {
                get { return m_bitValue; }
                set
                {
                    m_bitValue = value & 0x1;
                }
            }
            public int PortNum
            {
                get { return m_portNum; }
                set
                {
                    if ((value - ConstVal.StartPort) >= 0
                       && (value - ConstVal.StartPort) <= (ConstVal.PortCountShow - 1))
                    {
                        m_portNum = value;
                    }
                }
            }
            public int BitNum
            {
                get { return m_bitNum; }
                set
                {
                    if (value >= 0 && value <= 7)
                    {
                        m_bitNum = value;
                    }
                }
            }
            #endregion
        }

        private void DO1_btn_Click(object sender, EventArgs e)
        {
            ErrorCode err = ErrorCode.Success;
            int state = 1;
            int portNum = 0;

            int value;

            if (int.TryParse(textBox1.Text, out value))
            {
                //parsing successful 
            }
            else
            {
                //parsing failed. 
            }

            state = value;

            err = instantDoCtrl1.Write(portNum, (byte)state);
            if (err != ErrorCode.Success)
            {
                HandleError(err);
            }
        }
    }
}
