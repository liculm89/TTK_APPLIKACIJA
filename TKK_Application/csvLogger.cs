using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace TKK_Application
{
    class csvLogger
    {

        public string exportLoc = Globals.archive_loc;
        public string FileName = null;

        public csvLogger()
        {
            Console.WriteLine("New csvLogger object created");
            checkFolder();
        }

        public string createFileName(string filename)
        {
            string result = null;

            Console.WriteLine(exportLoc);

            if (Directory.Exists(exportLoc))
            {
                Console.WriteLine("That path exists already.");
                result = Path.Combine(exportLoc, filename);
                Console.WriteLine(result);
                
            }

            FileName = result;
            return result;
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

        public void createProcessLogFile()
        {
            if (FileName != null)
            {

                if (!File.Exists(FileName))
                {
                    string clientHeader = "Datum" + ";" + "Materijal" + ";" + "Los" + ";" + "Program" + ";" + "Operater" + Environment.NewLine;

                    File.WriteAllText(FileName, clientHeader);
                }
            }
        }

        public void appendcsvFile(string date, string material, string los, string direction, string operater)
        {
            string data = date + ";" + material + ";" + los + ";" + direction + ";" + operater + Environment.NewLine;

            if (File.Exists(FileName))
            {
                try
                {
                    File.AppendAllText(FileName, data);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error while writing into file, " + ex.ToString());
                }
                }
        }
    }
}
