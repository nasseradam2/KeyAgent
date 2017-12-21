using System;
using System.Collections.Generic;
using keyAgentTest.Class;

namespace keyAgentTest
{
    class Program
    {

        static void Main(string[] args)
        {
            //  Read path from Console.
            Console.WriteLine("Please input path to read: ");
            String path= Console.ReadLine();

            //  Get a list of folders' and its information found on the path
            Dictionary<string, double> folders = new KeyAgentDirectoryController(path).GetDirectoriesInformation();

            //  Get a list of files' and its information found on the path
            Dictionary<string, double> files = new KeyAgentFileController(path).GetFilesInformation();

            //  Write information to a text file
            new KeyAgentTextFileController(path, "FOLDERS", folders).WriteToTextFile();
            new KeyAgentTextFileController(path, "FILES", files).WriteToTextFile();
        }
    }
}
