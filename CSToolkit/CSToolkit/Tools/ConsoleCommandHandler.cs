using System;
using System.Diagnostics;

namespace CSToolkit.Tools
{
    public class ConsoleCommandHandler
    {
        public static void ExecuteWithoutOutput(string command, string arguments, bool useShellExecute)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = useShellExecute;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.Verb = "runas";
                process.Start();
                process.WaitForExit();
            }
            catch
            {

            }
        }

        public static string ExecuteWithOutput(string command, string arguments)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.Verb = "runas";
                process.Start();
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                return string.Format("{0}\n{1}", output, error);
            }
            catch (SystemException ex)
            {
                return ex.Message;
            }
        }
    }
}
