using System.Collections.Generic;

namespace CSToolkit.Model
{
    public class OperationNames
    {
        private static List<string> _operations = new List<string>() 
                { "Collecting BASIC INFO", "Collecting WHOAMI", "Checking for OPEN PORT 8080", "Collecting SYSTEM INFORMATION",
                  "Executing DNS CHECK", "Executing TRACEROUTE and TCP TRACEROUTE", 
                  "Executing PING and TCP PING", "Executing MTR", "Executing CURL"};

        private static List<string> _operationNames = new List<string>() 
                { "basicinfo", "whoami", "openproxyport", "systeminfo", "dns", 
                  "traceroute", "pings", "mtr", "curl"};
                        
        public static List<string> Operations 
        {
            get 
            { 
                return _operations; 
            }
        }

        public static List<string> OperationFileNames 
        {
            get
            { 
                return _operationNames;
            }
        }
    }
}
