using keyAgentTest.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace keyAgentTest.Class
{
    class KeyAgentDirectoryController : IKeyAgentDirectory
    {
        double size = 0;
        string path { get; set; }

        public KeyAgentDirectoryController(string path)
        {
            this.path = path;
        }

        public Dictionary<string, double> GetDirectoriesInformation()
        {
            try
            {
                //Initialise a dictionary which will hold the folder information and which will be returned once sorted
                Dictionary<string, double> folderInfo = new Dictionary<string, double>();

                //Get folders from path
                string[] listOfFolders = Directory.GetDirectories(path);

                // for each folder in the list of folders
                foreach (string folder in listOfFolders)
                {
                    //  Initialise the size of the folder
                    double mySize = 0;

                    //  Get total size of the folder (including the combined size of the subfolders)
                    mySize = GetFolderSize(folder);

                    //  Add information in the Dictionary
                    folderInfo.Add(folder, mySize);

                }
                //Return dictionary after being sorted in descending order of size
                return folderInfo.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }


        double GetFolderSize(string path)
        {
            // for each folders within the parent folder, do a recursive loop
            foreach (string dir in Directory.GetDirectories(path))
            {
                GetFolderSize(dir);
            }

            // for each files in that folder, add the size of that file to the global size
            foreach (FileInfo file in new DirectoryInfo(path).GetFiles())
            {
                size += file.Length;
            }

            return size;
        }
    }
}
