using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TKK_Application
{
    public class processCollector
    {

        //public string exportLoc = Globals.LogPath;
        public string exportLoc = @"D:\N046_17 DOKUMENTACIJA I PROGRAM\LOGS";
        public string LogName;
        public string Fullpath;
        public string[] eventTypes = { "Info", "Error", "Alarm" };

        private string _timeStamp;
        private string _eventType;
        private string _eventText;
        private string _userID;

        public event updatelog DataRec;
        public EventArgs e;
        public delegate void updatelog(processCollector pC, EventArgs e);


        public processCollector()
        {
            e = EventArgs.Empty;
            Console.WriteLine("New Process Collector object created");
            checkFolder();

            string fileDate = string.Format("{0:HH-mm-dd-MM-yyyy}", DateTime.Now);
            LogName = fileDate + "-" +"LOG"+ ".csv";
            Console.WriteLine("log name : " + LogName.ToString());
            createLog();
        }

        public void createLog()
        {
            if (LogName != null)
            {
                string result = Path.Combine(exportLoc, LogName);

                if (!File.Exists(result))
                {
                    string Header = "Date / Time" + ";" + "Event type" + ";" + "Event Output" + ";" + "User" + Environment.NewLine;
                    File.WriteAllText(result, Header);
                    Console.WriteLine("File created");
                    Fullpath = result;
                }
            }
        }

        public void writeLog(int et, string msg, string uid)
        {

            string tms = string.Format("{0:HH-mm-ss-dd-MM-yyyy}", DateTime.Now);
            _timeStamp = tms;
            _eventType = eventTypes[et];
            _eventText = msg;
            _userID = uid;
           // Console.WriteLine("new log recieved");

            string data = tms + ";" + _eventType + ";" + msg + ";" + uid + Environment.NewLine;
            if (File.Exists(Fullpath))
            {
                try
                {
                    File.AppendAllText(Fullpath, data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while writing into file, " + ex.ToString());
                }
            }
            try
            {
                DataRec(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while recieveing data: " + ex.ToString());
            }
        }

        public void checkFolder()
        {
            if (System.IO.Directory.Exists(exportLoc))
            {
                Console.WriteLine("Folder exists");
            }
            else
            {
                Directory.CreateDirectory(exportLoc);
            }
        }

        public string TimeStamp
        {
            get
            {
                return _timeStamp;
            }
            set
            {
                _timeStamp = value;
            }
        }

        public string EventType
        {
            get
            {
                return _eventType;
            }
            set
            {
                _eventType = value;
            }
        }

        public string EventText
        {
            get
            {
                return _eventText;
            }
            set
            {
                _eventText = value;
            }
        }

        public string UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }

    }
}
