using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.Tools
{
    public class DialogManager
    {
        public string GetDirectoryForSavingReportsDialog()
        {
            var folderSelectorDialog = new CommonOpenFileDialog();
            folderSelectorDialog.EnsureReadOnly = true;
            folderSelectorDialog.IsFolderPicker = true;
            folderSelectorDialog.AllowNonFileSystemItems = false;
            folderSelectorDialog.Multiselect = false;
            folderSelectorDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            folderSelectorDialog.Title = "Choose folder for saving reports";
            folderSelectorDialog.ShowDialog();

            string targetDirectory = Environment.SpecialFolder.Desktop.ToString();

            try
            {
                targetDirectory = folderSelectorDialog.FileName;
            }
            catch { }

            return targetDirectory;
        }
    }
}
