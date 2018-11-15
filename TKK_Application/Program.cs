using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TKK_Application
{

    public static class Globals
    {
        public static string database_loc = Properties.Settings.Default["db_loc"].ToString();
        public static string db_passwd = Properties.Settings.Default["db_passwd"].ToString();
        public static string archive_loc = Properties.Settings.Default["archive_loc"].ToString();
        public static string IOid = Properties.Settings.Default["IOdeviceNum"].ToString();
        public static string scannerCOM = Properties.Settings.Default["ScannerCOM"].ToString();
        public static string csvInput = Properties.Settings.Default["csvInput_loc"].ToString();
        public static string stopTimerInt = Properties.Settings.Default["stopTimerTime"].ToString();
        //   public static string LogPath = Properties.Settings.Default["LogPath"].ToString();

        public static processCollector pCol = new processCollector();
        public static IOControl IOCtrl = new IOControl();
        public static scannerControl Scnr = new scannerControl();

    }


    static class Program
    {
        

        public static void update_globals()
        {
            Globals.database_loc = Properties.Settings.Default["db_loc"].ToString();
            Globals.archive_loc = Properties.Settings.Default["archive_loc"].ToString();
            Globals.db_passwd = Properties.Settings.Default["db_passwd"].ToString();
            Globals.IOid = Properties.Settings.Default["IOdeviceNum"].ToString();
            Globals.scannerCOM = Properties.Settings.Default["ScannerCOM"].ToString();
            Globals.csvInput = Properties.Settings.Default["csvInput_loc"].ToString();
            
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            update_globals();

            try
            {
                 Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't start Application: " + ex.ToString());
            }
        }
    }
}
