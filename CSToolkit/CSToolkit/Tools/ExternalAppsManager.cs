using Microsoft.Win32;

namespace CSToolkit.Tools
{
    public class ExternalAppsManager
    {
        public static string GetDefaultBrowserPath()
        {
            using (RegistryKey registrykey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false))
            {
                return ((string)registrykey.GetValue(null, null)).Split('"')[1];
            }
        }
    }
}
