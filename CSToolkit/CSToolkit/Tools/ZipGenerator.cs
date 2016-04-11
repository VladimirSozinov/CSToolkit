using CSToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSToolkit.Tools
{
    public class ZipGenerator
    {
        public static void CreateZipArchive(List<OperationReport> operations, string directory, string htmlName)
        {
            for (int i = 0; i < operations.Count; i++)
            {
                try
                {
                    string result = string.Empty;

                    if(i!=0)
                    {   
                        foreach (var e in operations[i].Report)
                        {
                            result += e.FullCommand + "\n" + e.TextReport + "\n";
                        }  
                    }  
                    else
                    {
                        result += operations[i].Report[0].TextReport + "\n";
                    }

                    var file = new StreamWriter(string.Format("{0}.txt", operations[i].Operation));
                    file.WriteLine(result);
                    file.Close();
                }
                
                catch (SystemException ex) { }
            }
                      
            foreach (var operation in operations)
            {
                ConsoleCommandHandler.ExecuteWithoutOutput(
                        @"bin\zip\zip.exe", 
                        string.Format(@"{0}/Report-{1}.zip {2}.txt", directory, UserInfo.CurrentDate, operation.Operation),
                        false);

                File.Delete(string.Format("{0}.txt", operation.Operation));
            }

            try
            {
                ConsoleCommandHandler.ExecuteWithoutOutput(
                       @"bin\zip\zip.exe", 
                       string.Format(@"{0}/Report-{1}.zip {2}", directory, UserInfo.CurrentDate, htmlName), 
                       false);
            }
            catch (SystemException ex) { }
        }
    }
}
