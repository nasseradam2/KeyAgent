using keyAgentTest.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace keyAgentTest.Class
{
    class KeyAgentTextFileController : IKeyAgentTextFile
    {
        string path { get; set; }
        Dictionary<string, double> list { get; set; }
        string type { get; set; }

       static String time= DateTime.Now.ToString("HH-mm-ss"); 

        public KeyAgentTextFileController(string path, string type, Dictionary<string, double> list)
        {
            this.path = path;
            this.list = list;
            this.type = type;
        }

        public void WriteToTextFile()
        {
            try
            {
                //  Appending to text file the information for either file or folder from list.  A time is appended to text file name so that both files and folders
                // information are appended to same text file.  In case the console app is run again, the text file will not be overwritten as it is unique with the help
                //  of the time-text appended.  

                using (StreamWriter sw = File.AppendText(path + @"\data" + time + ".txt"))
                {
                    //  Writing the whether file or folder is being read
                    sw.WriteLine("--" + type + "--");

                    //  Loop within the list and append the information to the text file.
                    foreach (KeyValuePair<string, double> kv in list)
                    {
                        
                        sw.WriteLine(kv.Key + "(" + kv.Value + " bytes)");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        } 
    }
}
