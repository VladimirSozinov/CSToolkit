using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using CSToolkit.Model;
using CSToolkit.Tools;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using CSToolkit.ViewModel;

namespace CSToolkit.View
{
    public partial class ResultWindow : Window
    {
        public ResultWindow(string proxy1, string proxy2)
        {
            InitializeComponent();
            //TitleLabel.Content = string.Format("Results for Primary Proxy= {0} & Secondary Proxy = {1}", proxy1, proxy2);
            DataContextChanged += new DependencyPropertyChangedEventHandler(ResultWindowDataContextChanged);
        }
        
        private void ResultWindowDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = DataContext as ResultWindowViewModel;

            if (viewModel == null)
                return;

            viewModel.HideButtonClickedEvent += HideClicked;
            viewModel.HtmlHasGenerated += HtmlHasGenerated;
        }

        private void HtmlHasGenerated(object sender, PropertyChangeEventArgs e)
        {
            ReportUrlText.Text = e.PropertyName;
            ReportUrlLabel.Visibility = Visibility.Visible;
            ReportUrlLabel.IsEnabled = true;
            ContinueButton.IsEnabled = true;
        }

        private void HideClicked()
        {
            WindowState = WindowState.Minimized;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        
        private void ReportUrlClicked(object sender, MouseButtonEventArgs e)
        {
            ReportUrlLabel.Foreground = Brushes.Blue;
           // ConsoleCommandHandler.ExecuteWithoutOutput(GetDefaultBrowserPath(), string.Format("{0}/{1}", _defaultDirectory,_reportName), false);
        }

        private void ReportUrlButtonReleased(object sender, MouseButtonEventArgs e)
        {
            ReportUrlLabel.Foreground = Brushes.MediumBlue;
        }
        
        private string GetDefaultBrowserPath()
        {
            string key = @"HTTP\shell\open\command";

            using (RegistryKey registrykey = Registry.ClassesRoot.OpenSubKey(key, false))
            {
                return ((string)registrykey.GetValue(null, null)).Split('"')[1];
            }
        }
    }
}
