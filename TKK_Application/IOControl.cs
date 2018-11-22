using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.BDaq;
using System.Data;
using System.Windows.Forms;
//using System.Threading;
//using System.Timers;

namespace TKK_Application
{
    public class IOControl
    {
        /*
         * Deklaracija objekata koji kontroliraju I/O MODUL
         * instantDoCtrl1 - Digital outputs
         * instantDiCtrl1 - Digital inputs
        */
        public InstantDoCtrl instantDoCtrl1;
        public InstantDiCtrl instantDiCtrl1;
        public string IOprofile;

        /*
         * Deklaracija varijabli koje služe za pohranjivanje očitanog stanja I/O Modula
         */
        public string InputStateCh0;
        public string InputStateCh1;
        public string OutputStateCh0;

        private const int m_startPort = 0;
        private const int m_portCountShow = 2;

        public string[] statusArr = new string[4];

        public string rotationDirection;
        public char[] ChStates_port0;
        public char[] ChStates_port1;
        public char[] ChOutputStates_port0;

        //public System.ComponentModel.IContainer components = null;


        /*
         * Popis timera za koji se koriste kao delay prilikom uključivanja i isključivanja periferije
         *  autoStopTimer - koristi se prilikom kontroliranog stopa
         *  sep1StartTimer - koristi se kao delay prilikom startanja SEPARATORA 1.
         *  sep1StopTimer - koristi se kao delay prilikom stopiranja SEPARATORA 1.
         *  sep2StartTimer - koristi se kao delay prilikom startanja SEPARATORA 2.
         *  sep2StopTimer - koristi se kao delay prilikom stopiranja SEPARATORA 2.
         *  resetTimer - koristi se prilikom reseta outputa na početno stanje
         *  
         */
        public System.Windows.Forms.Timer autoStopTimer;
        public System.Windows.Forms.Timer sep1StartTimer;
        public System.Windows.Forms.Timer sep1StopTimer;
        public System.Windows.Forms.Timer sep2StartTimer;
        public System.Windows.Forms.Timer sep2StopTimer;
        public System.Windows.Forms.Timer resetTimer;
        public System.Windows.Forms.Timer refreshDeviceTimer;
        private static object locker = new Object();

        #region Tags
        public bool inputConfirmed;
        public bool Tag_sep1_RDY;
        public bool Tag_sep1_ACTIVE;

        public bool TotalStop_ACTIVE;
        public bool TotalStop_Pressed;
        public int Belt_counter;
        public int Belt_counterOld;

        public int tickCount;

        public bool MotorRunning;
        //private EventArgs e = null;

        public bool Tag_sep2_RDY;
        public bool Tag_sep2_ACTIVE;
        public bool AutoModeON;
        #endregion Tags

        //public event belt_error BeltError;

        public System.Windows.Forms.Timer timerChStats;
        public int stopTimerInterval;
        public int counter = 5;
        public int updateTick;

        public delegate void belt_error(IOControl Ioc, EventArgs e);

        public IOControl()
        {
            Console.WriteLine("New IOcontrol object created");

            instantDiCtrl1 = new InstantDiCtrl();
            instantDoCtrl1 = new InstantDoCtrl();

            try
            {
                //Kreiranje objekata za upravljanje I/O uređajem
                instantDoCtrl1.SelectedDevice = new DeviceInformation(1);
                instantDiCtrl1.SelectedDevice = new DeviceInformation(1);

                //Učitavanja profila I/O Modula
                IOprofile = "D:/N046_17 DOKUMENTACIJA I PROGRAM/Res/ioProfile.xml";

                //Provjera učitavanja profila
                ErrorCode errProfile = ErrorCode.Success;
                errProfile = instantDiCtrl1.LoadProfile(IOprofile);
                if (errProfile != ErrorCode.Success)
                {
                    HandleError(errProfile);
                }
                else
                {
                    Globals.pCol.writeLog(0, "I/O card profile loaded", "");
                }
            }

            catch (Exception ex)
            {
                Globals.pCol.writeLog(2, "I/O card not ready", "");
                MessageBox.Show("Device not ready: " + ex.ToString());
                return;
            }

            //Provjera inicijalizacije Digitalnih outputa
            if (!instantDoCtrl1.Initialized)
            {
                Globals.pCol.writeLog(2, "No device selected or device open failed!", "");
                MessageBox.Show("No device selected or device open failed!", "StaticDO");
                return;
            }

            //Provjera inicijalizacije Digitalnih inputa
            if (!instantDiCtrl1.Initialized)
            {
                Globals.pCol.writeLog(2, "No device selected or device open failed!", "");
                MessageBox.Show("No device selected or device open failed!", "StaticDI");
                return;
            }

            /*
             *Kreiranje i pokretanje update timera 
             * 50 ms
             * stopTimerInterval - parametar kojim se definira vrijeme vrtnje motora nakon što se ugasi separator 1.
             */
            timerChStats = new System.Windows.Forms.Timer();
            updateTick = 50;
            timerChStats.Interval = updateTick;
            timerChStats.Start();
            timerChStats.Tick += new EventHandler(updateStatus);
            rotationDirection = "0";
            stopTimerInterval = Int32.Parse(Globals.stopTimerInt);

            Belt_counter = 0;
            Belt_counterOld = 0;
            tickCount = 0;
            TotalStop_ACTIVE = false;
            //resetOutputs();
        }

        #region AUTOMATIKA
        //Automatski start
        public void startAuto(string dir)
        {
            ScanStates();
            //Provjera Total stop-a
            if (ChStates_port0[2] == '1')
            {
                char[] newState = ChOutputStates_port0;

                if (dir == "1")
                {
                    startMotorFWD();
                }
                else if (dir == "2")
                {
                    startMotorREV();
                }

                separator1Start();
                separator2Start();
                ispuhivanjeOn();
                AutoModeON = true;
            }
            else
            {
                MessageBox.Show("TOTAL STOP IS ACTIVE!", "TOTAL STOP ERROR");
                Globals.pCol.writeLog(2, "Total stop pressed", "");
            }
        }

        public void stopAuto()
        {
            char[] newState = ChOutputStates_port0;
            separator1Stop();

            autoStopTimer = new Timer();
            autoStopTimer.Interval = stopTimerInterval;
            autoStopTimer.Tick += new EventHandler(stopAutoDelayed);
            autoStopTimer.Start();
        }

        public void stopAutoDelayed(object sender, EventArgs e)
        {
            autoStopTimer.Stop();
            stopMotor();
            ispuhivanjeOff();
            AutoModeON = false;
            //Belt_counter = 0;
            //Belt_counterOld = 0;
            refreshDeviceTimer = new Timer();
            refreshDeviceTimer.Interval = 500;
            refreshDeviceTimer.Tick += new EventHandler(refreshIODevice);
            refreshDeviceTimer.Start();


        }

        public void refreshIODevice(object sender, EventArgs e)
        {
            refreshDeviceTimer.Stop();
            try
            {
                //stopTimer();
                instantDiCtrl1.Dispose();
                instantDoCtrl1.Dispose();
            }
            catch
            {
                Console.WriteLine("Timer not started");
            }

            try
            {
                //Kreiranje objekata za upravljanje I/O uređajem
                instantDoCtrl1.SelectedDevice = new DeviceInformation(1);
                instantDiCtrl1.SelectedDevice = new DeviceInformation(1);

                //Učitavanja profila I/O Modula
                IOprofile = "D:/N046_17 DOKUMENTACIJA I PROGRAM/Res/ioProfile.xml";

                //Provjera učitavanja profila
                ErrorCode errProfile = ErrorCode.Success;
                errProfile = instantDiCtrl1.LoadProfile(IOprofile);
                if (errProfile != ErrorCode.Success)
                {
                    HandleError(errProfile);
                }
                else
                {
                    Globals.pCol.writeLog(0, "I/O card profile loaded", "");
                }
            }

            catch (Exception ex)
            {
                Globals.pCol.writeLog(2, "I/O card not ready", "");
                MessageBox.Show("Device not ready: " + ex.ToString());
                return;
            }
        }

        #endregion AUTOMATIKA

        #region IOMethods

        public void setOutput(int portNum, int state)
        {

            //private static object locker = new Object();

            //lock (locker)
            //{
            try
            {
                ErrorCode err = ErrorCode.Success;
                err = instantDoCtrl1.Write(portNum, (byte)state);
                if (err != ErrorCode.Success)
                {
                    HandleError(err);
                }
                Globals.pCol.writeLog(0, "Output set to: " + state.ToString(), "");
            }
            catch (Exception ex)
            {
                Globals.pCol.writeLog(0, "Error while setting output: " + ex.ToString(), "");
                //locker = null;
            }
            //}
        }

        public void HandleError(ErrorCode err)
        {
            if ((err >= ErrorCode.ErrorHandleNotValid) && (err != ErrorCode.Success))
            {
                Console.WriteLine("Errror happend while setting output state");
                Globals.pCol.writeLog(2, "Errror happend while setting output state from IOControl class", "");
            }
        }

        public void resetOutputs()
        {
            ScanStates();
            char[] newState = ChOutputStates_port0;
            for (int i = 0; i < newState.Length; i++)
            {
                newState[i] = '0';
            }

            setOutput(0, convertOutputToInt(newState));
            resetTimer = new Timer();
            resetTimer.Interval = 600;
            resetTimer.Tick += new EventHandler(resetDelayed);
            resetTimer.Start();
        }
        public void resetDelayed(object sender, EventArgs e)
        {
            resetTimer.Stop();
            ScanStates();
            char[] newState = ChOutputStates_port0;

            newState[4] = '1';
            setOutput(0, convertOutputToInt(newState));
            Console.WriteLine("Outputs reseted");
        }

        //Skeniranje i konverzija stanja I/O modula
        public void ScanStates()
        {
            try
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
            catch
            {
                //Console.WriteLine("Error scanning states");
                Globals.pCol.writeLog(1, "Error scanning states", "");
            }
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

                //Startanje delaya
                sep1StartTimer = new Timer();
                sep1StartTimer.Interval = 800;
                sep1StartTimer.Tick += new EventHandler(sep1DelayedStart);
                sep1StartTimer.Start();
            }
            else
            {
                MessageBox.Show("TOTAL STOP IS ACTIVE!", "TOTAL STOP ERROR");
            }
        }

        public void sep1DelayedStart(object sender, EventArgs e)
        {
            sep1StartTimer.Stop();
            char[] newState = ChOutputStates_port0;
            newState[5] = '0';
            newState[4] = '1';
            setOutput(0, convertOutputToInt(newState));
            Globals.pCol.writeLog(0, "Separator 1. Started from IOControl class", "");
        }

        //Separator 1. STOP        
        public void separator1Stop()
        {
            char[] newState = ChOutputStates_port0;
            newState[5] = '0';
            newState[4] = '0';
            setOutput(0, convertOutputToInt(newState));

            sep1StopTimer = new Timer();
            sep1StopTimer.Interval = 1000;
            sep1StopTimer.Tick += new EventHandler(sep1DelayedStop);
            sep1StopTimer.Start();
        }

        public void sep1DelayedStop(object sender, EventArgs e)
        {
            sep1StopTimer.Stop();
            char[] newState = ChOutputStates_port0;
            newState[4] = '1';
            setOutput(0, convertOutputToInt(newState));
            Globals.pCol.writeLog(0, "Separator 1. Stoped from IOControl class", "");
        }
        #endregion Separator1

        #region Separator2
        //Separator 2. START
        public void separator2Start()
        {
            char[] newState = ChOutputStates_port0;
            newState[2] = '0';
            newState[3] = '1';
            setOutput(0, convertOutputToInt(newState));

            sep2StartTimer = new Timer();
            sep2StartTimer.Interval = 1000;
            sep2StartTimer.Tick += new EventHandler(sep2delayedStart);
            sep2StartTimer.Start();

        }
        //SEPARATOR 2. DELAYED START
        public void sep2delayedStart(object sender, EventArgs e)
        {
            sep2StartTimer.Stop();
            char[] newState = ChOutputStates_port0;
            newState[2] = '0';
            newState[3] = '0';
            setOutput(0, convertOutputToInt(newState));
            Globals.pCol.writeLog(0, "Separator 2. Started from IOControl class", "");

        }

        //Separator 2. STOP
        public void separator2Stop()
        {
            char[] newState = ChOutputStates_port0;
            newState[2] = '1';
            newState[3] = '0';
            setOutput(0, convertOutputToInt(newState));

            sep2StopTimer = new Timer();
            sep2StopTimer.Interval = 800;
            sep2StopTimer.Tick += new EventHandler(sep2delayedStop);
            sep2StopTimer.Start();

        }

        //SEPARATOR 2. DELAYED STOP
        public void sep2delayedStop(object sender, EventArgs e)
        {
            sep2StopTimer.Stop();
            char[] newState = ChOutputStates_port0;
            newState[2] = '0';
            newState[3] = '0';
            setOutput(0, convertOutputToInt(newState));
            Globals.pCol.writeLog(0, "Separator 2. Stoped from IOControl class", "");

        }

        #endregion Separator2

        #region Transporter

        //START MOTOR FWD
        public void startMotorFWD()
        {
            ScanStates();
            try
            {
                if (ChStates_port0[2] == '1')
                {
                    char[] newState = ChOutputStates_port0;
                    newState[6] = '0';
                    newState[7] = '1';
                    setOutput(0, convertOutputToInt(newState));
                    MotorRunning = true;
                    Globals.pCol.writeLog(0, "Transporter FWD, Started from IOControl class", "");

                }
                else
                {
                    MessageBox.Show("TOTAL STOP IS ACTIVE!", "TOTAL STOP ERROR");
                    Globals.pCol.writeLog(2, "Total stop pressed", "");
                }
            }
            catch
            {
            }
        }

        //START MOTOR REV
        public void startMotorREV()
        {
            ScanStates();
            try
            {
                if (ChStates_port0[2] == '1')
                {
                    char[] newState = ChOutputStates_port0;
                    newState[6] = '1';
                    newState[7] = '0';
                    setOutput(0, convertOutputToInt(newState));
                    MotorRunning = true;
                    Globals.pCol.writeLog(0, "Transporter REV, Started from IOControl class", "");
                }
                else
                {
                    MessageBox.Show("TOTAL STOP IS ACTIVE!", "TOTAL STOP ERROR");
                    Globals.pCol.writeLog(2, "Total stop pressed", "");
                }
            }
            catch
            { }
        }

        //MOTOR STOP
        public void stopMotor()
        {
            try
            {
                char[] newState = ChOutputStates_port0;
                newState[7] = '0';
                newState[6] = '0';
                setOutput(0, convertOutputToInt(newState));

                separator1Stop();
                MotorRunning = false;
                Belt_counter = 0;
                Belt_counterOld = 0;
                Globals.pCol.writeLog(0, "Transporter stoped from IOControl class", "");
            }
            catch
            {
                Globals.pCol.writeLog(0, "Error occured while stoping motor from IOControl class", "");
            }
        }

        //Ispuhivanje ON
        public void ispuhivanjeOn()
        {
            char[] newState = ChOutputStates_port0;
            newState[1] = '1';
            setOutput(0, convertOutputToInt(newState));
        }

        //Ispuhivanje OFF
        public void ispuhivanjeOff()
        {
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

            #region Update
            //Separator 1 state
            if (ChStates_port0[0].Equals('1') && ChStates_port0[1].Equals('0'))
            {
                statusArr[1] = "0"; //READY
            }
            else if (ChStates_port0[0].Equals('1') && ChStates_port0[1].Equals('1'))
            {
                statusArr[1] = "1"; //ACTIVE
            }
            else
            {
                statusArr[1] = "2"; //ERROR
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
            if (ChStates_port0[3].Equals('1') && ChStates_port0[4].Equals('0'))
            {
                statusArr[3] = "0";
            }
            else if (ChStates_port0[3].Equals('1') && ChStates_port0[4].Equals('1'))
            {
                statusArr[3] = "1";
            }
            else
            {
                statusArr[3] = "2";
            }

            if (statusArr[1].Equals("0") && statusArr[2].Equals("0") && statusArr[3].Equals("0"))
            {
                statusArr[0] = "0";
            }
            else if (statusArr[1].Equals("1") && statusArr[2].Equals("1") && statusArr[3].Equals("1"))
            {
                statusArr[0] = "1";
            }
            else if (statusArr[1].Equals("0") && statusArr[2].Equals("1") && statusArr[3].Equals("0"))
            {
                statusArr[0] = "0";
            }
            else if (statusArr[1].Equals("1") && statusArr[2].Equals("0") && statusArr[3].Equals("0"))
            {
                statusArr[0] = "0";
            }
            else if (statusArr[1].Equals("0") && statusArr[2].Equals("0") && statusArr[3].Equals("1"))
            {
                statusArr[0] = "0";
            }
            else
            {
                statusArr[0] = "2";
            }


            if (ChOutputStates_port0[7].Equals('1'))
            {
                rotationDirection = "1";
            }
            else if (ChOutputStates_port0[6].Equals('1'))
            {
                rotationDirection = "2";
            }
            else
            {
                rotationDirection = "0";
            }

            #endregion Update

            if (ChStates_port0[2].Equals('0'))
            {
                TotalStop_Pressed = true;
            }
            else
            {
                TotalStop_Pressed = false;
            }

            if (MotorRunning)
            {
                refreshRotationCheck();
                TotalStopCheck();
            }
        }

        public void refreshRotationCheck()
        {

            tickCount = tickCount + 1;

            if (tickCount >= 10)
            {
                /* if (Belt_counter > Belt_counterOld)
                 {
                     Console.WriteLine("Belt OK.");
                 }
                 else
                 {
                     Console.WriteLine("Belt error.");
                 }
                 tickCount = 0;
                 */
            }
            Belt_counterOld = Belt_counter;

        }

        public void TotalStopCheck()
        {

            if (TotalStop_Pressed && !TotalStop_ACTIVE)
            {
                TotalStop_Pressed = true;
                TotalStop_ACTIVE = true;
                MessageBox.Show("Total stop pressed!!!", "Total stop");
                stopMotor();
            }
            else if (!TotalStop_Pressed)
            {
                TotalStop_ACTIVE = false;
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
        public void stopTimer()
        {
            timerChStats.Stop();
            timerChStats.Dispose();
        }

        ~IOControl()
        {
            try
            {
                stopTimer();
                instantDiCtrl1.Dispose();
                instantDoCtrl1.Dispose();
            }
            catch
            {
                Console.WriteLine("Timer not started");
            }
        }

    }
}
