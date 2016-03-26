using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.Model
{
    class OperationNames
    {
        public List<string> Operations { get; set; }
        public List<string> OperationFileNames { get; set; }

        public OperationNames()
        {
            Operations = new List<string>(){"Collecting BASIC INFO", "Collecting WHOAMI", "Checking for OPEN PORT 8080", "Collecting SYSTEM INFORMATION",
                                                       "Executing DNS CHECK", "Executing TRACEROUTE and TCP TRACEROUTE", 
                                                       "Executing PING and TCP PING", "Executing MTR", "Executing CURL"};

            OperationFileNames = new List<string>() { "basicinfo", "whoami", "openproxyport", "systeminfo", "dns", 
                                                                 "traceroute", "pings", "mtr", "curl"};
    
        }
    }
}
