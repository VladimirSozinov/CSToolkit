using Microsoft.WindowsAPICodePack.Dialogs;
using System;

namespace CSToolkit.Tools
{
    public class DialogManager
    {
        public static string GetDirectoryForSavingReportsDialog()
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
