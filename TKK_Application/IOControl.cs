using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.BDaq;
using System.Data;
//using System.Threading.Tasks;
using System.Windows.Forms;


namespace TKK_Application
{
    class IOControl
    {
        //public DaqCtrlBase IOModule;
        public InstantDoCtrl instantDoCtrl1;
        public InstantDiCtrl instantDiCtrl1;
        public string InputStateCh0;
        public string InputStateCh1;
        public string OutputStateCh0;

        private string profileLoc;

        private const int m_startPort = 0;
        private const int m_portCountShow = 2;

        public string[] statusArr = new string[4];
        public char[] ChStates_port0;
        public char[] ChStates_port1;
        public char[] ChOutputStates_port0;

        private System.ComponentModel.IContainer components = null;
        public int counter = 5;

        private Timer timerChStats;

        public IOControl()
        {
            Console.WriteLine("New IOcontrol object created");

            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TKK));
            this.instantDoCtrl1 = new Automation.BDaq.InstantDoCtrl(this.components);
            this.instantDiCtrl1 = new Automation.BDaq.InstantDiCtrl(this.components);
            this.instantDoCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("instantDoCtrl1._StateStream")));
            this.instantDiCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("instantDiCtrl1._StateStream")));

            instantDoCtrl1.SelectedDevice = new DeviceInformation(1);
            instantDiCtrl1.SelectedDevice = new DeviceInformation(1);
            profileLoc = @"D:\N046_17 DOKUMENTACIJA I PROGRAM\Res\ioProfile.xml";

            instantDiCtrl1.LoadProfile(profileLoc);

            if (!instantDoCtrl1.Initialized)
            {
                MessageBox.Show("No device be selected or device open failed!", "StaticDO");
                return;
            }

            if (!instantDiCtrl1.Initialized)
            {
                MessageBox.Show("No device be selected or device open failed!", "StaticDI");
                return;
            }

            DiintChannel[] interruptChans = instantDiCtrl1.DiintChannels;
            interruptChans[0].Enabled = true;
            interruptChans[1].Enabled = true;

            instantDiCtrl1.SnapStart();
            instantDiCtrl1.ChangeOfState += new EventHandler<DiSnapEventArgs>(DInputChanged);
            instantDiCtrl1.Interrupt += new EventHandler<DiSnapEventArgs>(instantDiCtrl_Interrupt);
            //resetOutputs();

            timerChStats = new Timer();
            timerChStats.Interval = 100;
            timerChStats.Start();
            this.timerChStats.Tick += new EventHandler(updateStatus);

        }


        public void instantDiCtrl_Interrupt(object sender, DiSnapEventArgs e)
        {
            // Console.WriteLine("\n DI port {0} status change interrupt occurred!", e.SrcNum);
        }

        public void DInputChanged(object sender, DiSnapEventArgs e)
        {
            // Console.WriteLine("\n DI port {0} status change interrupt occurred!", e.SrcNum);
        }

        #region AUTOMATIKA

        public async void startAuto(string dir)
        {
            ScanStates();
            if (ChStates_port0[2] == '1')
            {
                char[] newState = ChOutputStates_port0;

                await Task.Delay(100);

                if (dir == "1")
                {
                    startMotorFWD();
                }
                else if (dir == "2")
                {
                    startMotorREV();
                }

                await Task.Delay(2000);

                ScanStates();
                separator1Start();
                separator2Start();

                await Task.Delay(500);
            }
            else
            {
                MessageBox.Show("TOTAL STOP IS ACTIVE!", "TOTAL STOP ERROR");
            }
        }

        public async void stopAuto()
        {
            ScanStates();
            char[] newState = ChOutputStates_port0;

            newState[5] = '0';
            newState[4] = '0';
            setOutput(0, convertOutputToInt(newState));

            await Task.Delay(5000);
            resetOutputs();
        }

        #endregion AUTOMATIKA

        #region IOMethods

        public void setOutput(int portNum, int state)
        {
            ErrorCode err = ErrorCode.Success;
            err = instantDoCtrl1.Write(portNum, (byte)state);
            if (err != ErrorCode.Success)
            {
                HandleError(err);
            }
            Console.WriteLine("Output set to: " + state);
        }

        private void HandleError(ErrorCode err)
        {
            if ((err >= ErrorCode.ErrorHandleNotValid) && (err != ErrorCode.Success))
            {
                MessageBox.Show("Sorry ! Some errors happened, the error code is: " + err.ToString());
            }
        }

        public async void resetOutputs()
        {
            ScanStates();
            char[] newState = ChOutputStates_port0;
            for (int i = 0; i < newState.Length; i++)
            {
                newState[i] = '0';
            }
            newState[4] = '1';

            setOutput(0, convertOutputToInt(newState));

            await Task.Delay(300);
            Console.WriteLine("Outputs reseted");
        }

        public void ScanStates()
        {
            #region Inputs
            byte portData = 0;

            ErrorCode err = ErrorCode.Success;
            err = instantDiCtrl1.Read(0, out portData);
            if (err != ErrorCode.Success)
            {
                HandleError(err);
                return;
            }
            ChStates_port0 = convertToArr(portData);
            InputStateCh0 = convertToString(portData);

            err = ErrorCode.Success;
            err = instantDiCtrl1.Read(1, out portData);
            if (err != ErrorCode.Success)
            {
                HandleError(err);
                return;
            }

            ChStates_port1 = convertToArr(portData);
            InputStateCh1 = convertToString(portData);

            #endregion Inputs

            #region Outputs

            portData = 0;
            byte portDir = 0xFF;
            err = ErrorCode.Success;
            byte[] mask = instantDoCtrl1.Features.DoDataMask;

            err = instantDoCtrl1.Read(ConstVal.StartPort, out portData);
            if (err != ErrorCode.Success)
            {
                HandleError(err);
                return;
            }

            if (instantDoCtrl1.Ports != null)
            {
                portDir = (byte)instantDoCtrl1.Ports[ConstVal.StartPort].DirectionMask;
            }
            ChOutputStates_port0 = convertToArr(portData);
            Array.Reverse(ChOutputStates_port0);
            string outStats = new string(ChOutputStates_port0);

            OutputStateCh0 = convertToString(portData);
            #endregion 
        }

        #region Separator1

        //Separator 1. START
        public void separator1Start()
        {
            ScanStates();
            if (ChStates_port0[2] == '1')
            {
                char[] newState = ChOutputStates_port0;
                newState[5] = '1';
                newState[4] = '1';
                setOutput(0, convertOutputToInt(newState));
            }
            else
            {
                MessageBox.Show("TOTAL STOP IS ACTIVE!", "TOTAL STOP ERROR");
            }
        }

        //Separator 1. STOP
        public async void separator1Stop()
        {
            ScanStates();
            char[] newState = ChOutputStates_port0;
            newState[5] = '0';
            newState[4] = '0';
            setOutput(0, convertOutputToInt(newState));

            await Task.Delay(300);

            ScanStates();
            newState = ChOutputStates_port0;
            newState[4] = '1';
            setOutput(0, convertOutputToInt(newState));
        }
        #endregion Separator1

        #region Separator2
        //Separator 2. START
        public async void separator2Start()
        {
            ScanStates();
            char[] newState = ChOutputStates_port0;
            newState[2] = '0';
            newState[3] = '1';
            setOutput(0, convertOutputToInt(newState));
          
            await Task.Delay(300);

            ScanStates();
            newState = ChOutputStates_port0;
            newState[2] = '0';
            newState[3] = '0';
            setOutput(0, convertOutputToInt(newState));
        }

        //Separator 2. STOP
        public async void separator2Stop()
        {
            ScanStates();
            char[] newState = ChOutputStates_port0;
            newState[2] = '1';
            newState[3] = '0';
            setOutput(0, convertOutputToInt(newState));

            await Task.Delay(300);

            ScanStates();
            newState = ChOutputStates_port0;
            newState[2] = '0';
            newState[3] = '0';
            setOutput(0, convertOutputToInt(newState));
        }


        #endregion Separator2

        #region Transporter

        //START MOTOR FWD
        public void startMotorFWD()
        {
            ScanStates();
            if (ChStates_port0[2] == '1')
            {      
                char[] newState = ChOutputStates_port0;
                newState[6] = '0';
                newState[7] = '1';
                setOutput(0, convertOutputToInt(newState));
            }
            else
            {
                MessageBox.Show("TOTAL STOP IS ACTIVE!", "TOTAL STOP ERROR");
            }
        }

        //START MOTOR REV
        public void startMotorREV()
        {
            ScanStates();
            if (ChStates_port0[2] == '1')
            {
                char[] newState = ChOutputStates_port0;
                newState[6] = '1';
                newState[7] = '0';
                setOutput(0, convertOutputToInt(newState));
            }
            else
            {
                MessageBox.Show("TOTAL STOP IS ACTIVE!", "TOTAL STOP ERROR");
            }
        }

        //MOTOR STOP
        public void stopMotor()
        {
            ScanStates();
            char[] newState = ChOutputStates_port0;
            newState[7] = '0';
            newState[6] = '0';
            setOutput(0, convertOutputToInt(newState));
        }

        //Ispuhivanje ON
        public void ispuhivanjeOn()
        {
            ScanStates();
            char[] newState = ChOutputStates_port0;
            newState[1] = '1';
            setOutput(0, convertOutputToInt(newState));
        }

        public void ispuhivanjeOff()
        {
            ScanStates();
            char[] newState = ChOutputStates_port0;
            newState[1] = '0';
            setOutput(0, convertOutputToInt(newState));
        }
        #endregion Transporter

        #endregion IOMethods

        #region Utility

        public void updateStatus(object sender, EventArgs e)
        {
            ScanStates();

            //Separator 1 state
            if (ChStates_port0[0].Equals('1') && ChStates_port0[1].Equals('0'))
            {
                statusArr[1] = "0";
            }
            else if (ChStates_port0[0].Equals('1') && ChStates_port0[1].Equals('1'))
            {
                statusArr[1] = "1";
            }
            else
            {
                statusArr[1] = "2";
            }

            //Separator 2 state
            if (ChStates_port1[1].Equals('1') && ChStates_port1[2].Equals('0'))
            {
                statusArr[2] = "0";
            }
            else if (ChStates_port1[1].Equals('1') && ChStates_port1[2].Equals('1'))
            {
                statusArr[2] = "1";
            }
            else
            {
                statusArr[2] = "2";
            }

            //Transporter state
            if (ChStates_port1[3].Equals('1') && ChStates_port1[4].Equals('0'))
            {
                statusArr[3] = "0";
            }
            else if (ChStates_port1[3].Equals('1') && ChStates_port1[4].Equals('1'))
            {
                statusArr[3] = "1";
            }
            else
            {
                statusArr[3] = "2";
            }

            if (statusArr[1].Equals('0') && statusArr[2].Equals('0') && statusArr[3].Equals('0'))
            {
                statusArr[0] = "0";
            }
            else if (statusArr[1].Equals('1') && statusArr[2].Equals('1') && statusArr[3].Equals('1'))
            {
                statusArr[0] = "1";
            }
            else 
            {
                statusArr[0] = "2";
            }

        }

        public char[] convertToArr(int state)
        {
            string s = Convert.ToString(state, 2);
            char[] bitsarr = s.PadLeft(8, '0').ToCharArray();
            Array.Reverse(bitsarr);
            return bitsarr;
        }

        public string convertToString(byte data)
        {
            char[] ChStates = convertToArr(data);
            string output = new string(ChStates);
            return output;
        }

        public string convertOutputToString(char[] outputState)
        {
            string result = new string(outputState);
            return result;
        }

        public int convertOutputToInt(char[] outputState)
        {
            string outputS = new string(outputState);
            int output = Convert.ToInt32(outputS, 2);
            return output;
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
        #endregion
        ~IOControl()
        {
            timerChStats.Stop();
        }

    }
}
