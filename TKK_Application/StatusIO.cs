using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.BDaq;
using System.Globalization;

namespace TKK_Application
{
    public partial class StatusIO : Form
    {

        #region
        private Label[] m_portNum;
        private Label[] m_portHex;
        private PictureBox[,] m_pictrueBox;
        private const int m_startPort = 0;
        private const int m_portCountShow = 2;

        private Label[] m_portNumOutput;
        private Label[] m_portHexOutput;
        private PictureBox[,] m_pictrueBoxOutput;
        #endregion


        public StatusIO()
        {
            InitializeComponent();
        }

        public StatusIO(int deviceNumber)
        {
            InitializeComponent();
            //Initialize digital inputs
            instantDiCtrl1.SelectedDevice = new DeviceInformation(deviceNumber);

            //Initialize digital outputs
            instantDoCtrl1.SelectedDevice = new DeviceInformation(deviceNumber);

           // string profileLoc= @"D:\N046_17 DOKUMENTACIJA I PROGRAM\Res\Programi.csv";
            //ErrorCode 

            if (!instantDiCtrl1.Initialized || !instantDoCtrl1.Initialized)
            {
                MessageBox.Show("No device be selected or device open failed!", "StaticDI");
                this.Close();
                return;
            }

            Console.WriteLine("Device initialized");

        }


        private void HandleError(ErrorCode err)
        {
            if ((err >= ErrorCode.ErrorHandleNotValid) && (err != ErrorCode.Success))
            {
                MessageBox.Show("Sorry ! Some errors happened, the error code is: " + err.ToString(), "Static DI");
            }
        }

        private void StatusIO_Load(object sender, EventArgs e)
        {
            #region INPUTS
            if (!instantDiCtrl1.Initialized)
            {
                MessageBox.Show("No device be selected or device open failed!", "StaticDI");
                this.Close();
                return;
            }

            this.Text = "Status USB Modula: (" + instantDiCtrl1.SelectedDevice.Description + ")";

            m_portNum = new Label[m_portCountShow] { PortNum0, PortNum1};
            m_portHex = new Label[m_portCountShow] { PortHex0, PortHex1};

            m_pictrueBox = new PictureBox[m_portCountShow, 8]{
             {pictureBox0, pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,pictureBox6, pictureBox7},
             {pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13,pictureBox14,pictureBox15}
                };
            timer1.Enabled = true;
            #endregion INPUTS

            #region OUTPUTS

            m_portNumOutput = new Label[m_portCountShow] { PortNum0_output, PortNum1_output };
            m_portHexOutput = new Label[m_portCountShow] { PortHex0_output, PortHex1_output };

            m_pictrueBoxOutput = new PictureBox[m_portCountShow, 8]
            {
                {pictureBox16, pictureBox17,pictureBox18,pictureBox19,pictureBox20,pictureBox21,pictureBox22,pictureBox23 },
                {pictureBox24, pictureBox25, pictureBox26,pictureBox27,pictureBox28,pictureBox29,pictureBox30,pictureBox31}
            };
            InitOutputState();
            #endregion OUTPUTS

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Inputs
            byte portData = 0;
            ErrorCode err = ErrorCode.Success;

            for (int i = 0; (i + m_startPort) < instantDiCtrl1.Features.PortCount && i < m_portCountShow; ++i)
            {
                err = instantDiCtrl1.Read(i + m_startPort, out portData);
                if (err != ErrorCode.Success)
                {
                    timer1.Enabled = false;
                    HandleError(err);
                    return;
                }

               //Console.WriteLine(portData);
                m_portNum[i].Text = (i + m_startPort).ToString();
                m_portHex[i].Text = portData.ToString("X2");

                // Set picture box state
                for (int j = 0; j < 8; ++j)
                {
                    m_pictrueBox[i, j].Image = imageList1.Images[(portData >> j) & 0x1];
                    m_pictrueBox[i, j].Invalidate();
                }
            }
            #endregion Inputs

            #region Outputs
            /*
            
            byte portDataOutput = 0;
            byte portDir = 0xFF;
            ErrorCode errOutput = ErrorCode.Success;
            byte[] mask = instantDoCtrl1.Features.DoDataMask;
            for (int i = 0; (i + ConstVal.StartPort) < instantDoCtrl1.Features.PortCount && i < ConstVal.PortCountShow; ++i)
            {
                errOutput = instantDoCtrl1.Read(i + ConstVal.StartPort, out portDataOutput);
                if (errOutput != ErrorCode.Success)
                {
                    HandleError(errOutput);
                    return;
                }

                m_portNumOutput[i].Text = (i + ConstVal.StartPort).ToString();
                m_portHexOutput[i].Text = portDataOutput.ToString("X2");

                if (instantDoCtrl1.Ports != null)
                {
                    portDir = (byte)instantDoCtrl1.Ports[i + ConstVal.StartPort].DirectionMask;
                }

                // Set picture box state
                for (int j = 0; j < 8; ++j)
                {
                    if (((portDir >> j) & 0x1) == 0 || ((mask[i] >> j) & 0x1) == 0)  // Bit direction is input.
                    {
                        m_pictrueBoxOutput[i, j].Image = imageList2.Images[2];
                        m_pictrueBoxOutput[i, j].Enabled = false;
                    }
                    else
                    {
                        m_pictrueBoxOutput[i, j].Click += new EventHandler(OutputButton_Click);
                        m_pictrueBoxOutput[i, j].Tag = new DoBitInformation((portDataOutput >> j) & 0x1, i + ConstVal.StartPort, j);
                        m_pictrueBoxOutput[i, j].Image = imageList2.Images[(portDataOutput >> j) & 0x1];
                    }
                    m_pictrueBoxOutput[i, j].Invalidate();
                }
            } 
    */
            #endregion Output
        }

        private void InitOutputState()
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

                m_portNumOutput[i].Text = (i + ConstVal.StartPort).ToString();
                m_portHexOutput[i].Text = portData.ToString("X2");

                if (instantDoCtrl1.Ports != null)
                {
                    portDir = (byte)instantDoCtrl1.Ports[i + ConstVal.StartPort].DirectionMask;
                }

                // Set picture box state
                for (int j = 0; j < 8; ++j)
                {
                    if (((portDir >> j) & 0x1) == 0 || ((mask[i] >> j) & 0x1) == 0)  // Bit direction is input.
                    {
                        m_pictrueBoxOutput[i, j].Image = imageList2.Images[2];
                        m_pictrueBoxOutput[i, j].Enabled = false;
                    }
                    else
                    {
                        m_pictrueBoxOutput[i, j].Click += new EventHandler(OutputButton_Click);
                        m_pictrueBoxOutput[i, j].Tag = new DoBitInformation((portData >> j) & 0x1, i + ConstVal.StartPort, j);
                        m_pictrueBoxOutput[i, j].Image = imageList2.Images[(portData >> j) & 0x1];
                    }
                    m_pictrueBoxOutput[i, j].Invalidate();
                }
            }
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            ErrorCode err = ErrorCode.Success;
            PictureBox box = (PictureBox)sender;
            DoBitInformation boxInfo = (DoBitInformation)box.Tag;

            boxInfo.BitValue = (~(int)(boxInfo).BitValue) & 0x1;
            box.Tag = boxInfo;
            box.Image = imageList2.Images[boxInfo.BitValue];
            box.Invalidate();

            // refresh hex
            int state = Int32.Parse(m_portHexOutput[boxInfo.PortNum - ConstVal.StartPort].Text, NumberStyles.AllowHexSpecifier);
            //Console.WriteLine("state:" + state);
            state &= ~(0x1 << boxInfo.BitNum);
            state |= boxInfo.BitValue << boxInfo.BitNum;

            string s = Convert.ToString(state, 2);
            char[] bitsarr = s.PadLeft(8,'0').ToCharArray();
            Array.Reverse(bitsarr);
  
            m_portHexOutput[boxInfo.PortNum - ConstVal.StartPort].Text = state.ToString("X2");
            err = instantDoCtrl1.Write(boxInfo.PortNum, (byte)state);
            if (err != ErrorCode.Success)
            {
                HandleError(err);
            }
        }


        #region Utility functions
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

        public static class ConstVal
        {
            public const int StartPort = 0;
            public const int PortCountShow = 4;
        }
        #endregion Utility functions


    }
}
