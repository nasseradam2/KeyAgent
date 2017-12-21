using System;
using System.Collections.Generic;
using System.Text;

namespace keyAgentTest.Interfaces
{
    interface IKeyAgentFile
    {
        Dictionary<string, double> GetFilesInformation();
    }
}
