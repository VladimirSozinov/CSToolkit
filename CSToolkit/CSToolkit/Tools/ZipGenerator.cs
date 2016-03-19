using CSToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.Tools
{
    public class ZipGenerator
    {
        public static void CreateZipArchive(List<OperationReport> operations, string directory)
        {
            var date = DateTime.Now;
            var suffix = String.Format(@"{0}_{1}", date.ToString("HH-mm"), date.ToString("ddMMMMyyyy"));

            foreach (var operation in operations)
            {
                try
                {
                    string result = string.Empty;

                    foreach(var e in operation.Report)
                    {
                        result += e.FullCommand + "\n" + e.TextReport + "\n";
                    }

                    var file = new StreamWriter(string.Format("{0}.txt", operation.Operation));
                    file.WriteLine(result);
                    file.Close();
                }

                catch (SystemException ex) { }
            }

            try
            {
                var file = new StreamWriter("basicinfo.txt");
                file.WriteLine("Customer Name: {0}, Serialr Number: {1}, Cec Id: {2}", UserInfo.CustomerName, UserInfo.SrNumber, UserInfo.CecId);
                file.Close();
            }
            catch (SystemException ex)
            {
            }

            foreach (var operation in operations)
            {
                ConsoleCommandHandler.ExecuteWithoutOutput(@"bin\zip\zip.exe", string.Format(@"{0}/Report{1}.zip {2}.txt", directory, suffix, operation.Operation), false);
                File.Delete(string.Format("{0}.txt", operation.Operation));
            }

            WriteUserInfo(directory, suffix);
        }

        private static void WriteUserInfo(string directory, string suffix)
        {
            ConsoleCommandHandler.ExecuteWithoutOutput(@"bin\zip\zip.exe", string.Format(@"{0}/Report{1}.zip {2}", directory, suffix, "basicinfo.txt"), false);
            File.Delete("basicinfo.txt");
        }
    }
}
