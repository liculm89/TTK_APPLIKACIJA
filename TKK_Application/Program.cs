using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKK_Application
{

    public static class Globals
    {
        //public static string rezultat;
        public static string database_loc = Properties.Settings.Default["db_loc"].ToString();
        public static string archive_loc = Properties.Settings.Default["archive_loc"].ToString();
        public static string export_folder = Properties.Settings.Default["Export_folder"].ToString();
        public static string db_passwd = Properties.Settings.Default["db_passwd"].ToString();

        //public static string external_archive_loc = Properties.Settings.Default["external_archive_loc"].ToString();
        //public static string timeout_counter = Properties.Settings.Default["timeout_counter"].ToString();
        //public static string trigger_timer = Properties.Settings.Default["trigger"].ToString();

    }


    static class Program
    {

        public static void update_globals()
        {

            Globals.database_loc = Properties.Settings.Default["db_loc"].ToString();
            Globals.archive_loc = Properties.Settings.Default["archive_loc"].ToString();
            Globals.export_folder = Properties.Settings.Default["Export_folder"].ToString();
            Globals.db_passwd = Properties.Settings.Default["db_passwd"].ToString();

            //Globals.external_archive_loc = Properties.Settings.Default["external_archive_loc"].ToString();
            //Globals.timeout_counter = Properties.Settings.Default["timeout_counter"].ToString();
            //Globals.trigger_timer = Properties.Settings.Default["trigger"].ToString();

        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TKK());
            update_globals();
            Application.Run(new LoginForm());
        }
    }
}
