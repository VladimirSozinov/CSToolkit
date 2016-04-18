using Microsoft.WindowsAPICodePack.Dialogs;
using System;

namespace CSToolkit.Tools
{
    public class DialogManager
    {
        public static string GetDirectoryForSavingReportsDialog()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.EnsureReadOnly = true;
            dialog.IsFolderPicker = true;
            dialog.AllowNonFileSystemItems = false;
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.Title = "Choose folder for saving reports";
            dialog.ShowDialog();

            string targetDirectory = Environment.SpecialFolder.Desktop.ToString();

            try
            {
                targetDirectory = dialog.FileName;
            }
            catch { }

            return targetDirectory;
        }
    }
}
