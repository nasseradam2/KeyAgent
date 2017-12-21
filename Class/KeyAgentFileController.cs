using keyAgentTest.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace keyAgentTest.Class
{
    class KeyAgentFileController : IKeyAgentFile
    {
        string path { get; set; }

        public KeyAgentFileController(string path)
        {
            this.path = path;
        }

        public Dictionary<string, double> GetFilesInformation()
        {
            try
            {
                //  Initialising list of files' information which will be filled and returned accordingly.
                Dictionary<string, double> listOfFiles = new Dictionary<string, double>();

                //  Reading the parent path
                DirectoryInfo di = new DirectoryInfo(path);

                // Get a reference to each file in that directory.
                FileInfo[] filesArray = di.GetFiles();
                // Display the names and sizes of the files.

                //  For each files in the files array, add the file name and its corresponding size to the Dictionary
                foreach (FileInfo f in filesArray)
                    listOfFiles.Add(f.Name, f.Length);

                //  Sort files by file size and return list of files
                return listOfFiles.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
          
        }
    }
}
