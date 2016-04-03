using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.Tools
{
    public class ExternalAppsManager
    {
        public string GetDefaultBrowserPath()
        {
            string key = @"HTTP\shell\open\command";

            using (RegistryKey registrykey = Registry.ClassesRoot.OpenSubKey(key, false))
            {
                return ((string)registrykey.GetValue(null, null)).Split('"')[1];
            }
        }
    }
}
