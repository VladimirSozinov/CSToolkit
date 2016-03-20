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

namespace CSToolkit.View
{
    public partial class ResultWindow : Window
    {
        private ObservableCollection<Operation> _commands;
        private System.Timers.Timer _aTimer;
        private List<OperationReport> operationReports;
        private int _finishedProcesses;
        private bool _windowIsMax;
        private double _lastLeft;
        private double _lastTop;

        public ResultWindow()
        {
            InitializeComponent();
            
            Refresh += ResultWindowRefresh;
            AllProcessesFinished += ResultWindow_AllProcessesFinished;
        }

        public ResultWindow(string one, string two, double x , double y, ObservableCollection<Operation> commands)
        {
            InitializeComponent();
            TitleLabel.Content = string.Format("Results for Primary Proxy= {0} & Secondary Proxy = {1}", one, two);
            Width = 625;
            Height = 380;
            Left = x;
            Top = y;
            operationReports = new List<OperationReport>();

            _commands = commands;
            Refresh += ResultWindowRefresh;
            AllProcessesFinished += ResultWindow_AllProcessesFinished;

            StartProcessing();
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public ObservableCollection<Operation> Commands
        {
            get
            {
                return _commands;
            }
            set
            {
                _commands = value;
            }
        }

        private void ExpandClicked(object sender, RoutedEventArgs e)
        {
            var workingArea = SystemParameters.WorkArea;

            if(_windowIsMax == false)
            {
                Width = workingArea.Width;
                Height = workingArea.Height;

                _lastLeft = Left;
                _lastTop = Top;

                Left = workingArea.Right - Width;
                Top = workingArea.Bottom - Height;
                _windowIsMax = true;
            }
            else
            {
                Width = 625;
                Height = 380;
                Left = _lastLeft;
                Top = _lastTop;
                _windowIsMax = false;
            }
        }

        private void HideClicked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        void ResultWindow_AllProcessesFinished()
        {
            ContinueButton.IsEnabled = true;
        }

        private void ResultWindowRefresh()
        {
            Dispatcher.BeginInvoke(new Action(delegate()
            {
                CommandList.Items.Refresh();
            }));

            EvaluateFinishedProcesses();
        }

        private void StartProcessing()
        {
            var gridView = new GridView();
            CommandList.Items.Clear();
            CommandList.View = gridView;

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Action",
                Width = 300,
                DisplayMemberBinding = new Binding("CommandName")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Status",
                Width = 300,
                DisplayMemberBinding = new Binding("CurrentState")
            });

            _commands.CollectionChanged += CommandsCollectionChanged;
            
            foreach(var com in _commands)
            {
                CommandList.Items.Add(com);
            }

            CommandList.Items.Refresh();

            _aTimer = new System.Timers.Timer(2000);
            _aTimer.Elapsed += OnTimedEvent;
            _aTimer.Enabled = true;
        }

        private void OnTimedEvent(object s, EventArgs e)
        {
            _aTimer.Stop();
            _aTimer.Enabled = false;
            MyStartExecuting();
        }

        BackgroundWorker worker;
        event Action Refresh;
        event Action AllProcessesFinished;

        private void EvaluateFinishedProcesses()
        {
            int count = _commands.Count(command => command.CurrentState == Operation.States.Finished);

            Dispatcher.BeginInvoke(new Action(delegate()
            {
                FinishedCommandsLabel.Content = string.Format("Finished {0} out of 8 commands", count);

                if( _finishedProcesses == 8 )
                {
                    AllProcessesFinished();
                }
            }));

            _finishedProcesses = count;
        }

        private void MyStartExecuting()
        {
            for (int i = 0; i < _commands.Count; i++)
            {
                if (_commands[i].CurrentState == Operation.States.Waiting)
                    _commands[i].CurrentState = Operation.States.InProgress;

                Refresh();

                try
                {
                    worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(MyWorkerDoWork);
                    worker.RunWorkerAsync(_commands[i]);
                }
                catch { }
            }
        }

        private void MyWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var operation = (Operation)e.Argument;
            var output = String.Empty;
            var reports = new List<Report>();

            foreach (var subCommand in operation.SetCommands)
            {
                output = ConsoleCommandHandler.ExecuteWithOutput(subCommand.Key, subCommand.Value);
                var fullCommand = string.Format("{0} {1}", subCommand.Key, subCommand.Value);
                reports.Add( new Report(fullCommand, output) );
            }

            var operationReport = new OperationReport(operation.TxtName, reports);
            operationReports.Add(operationReport);
            operation.CurrentState = Operation.States.Finished;
            Refresh();
        } 
    
        private void CommandsCollectionChanged(object sender, EventArgs e)
        {
            CommandList.Items.Refresh();
        }

        private string _defaultDirectory;
        private string _reportName;

        private void ContinueButtonClicked(object sender, EventArgs args)
        {
            _defaultDirectory = GetDirectoryForSavingReports();
            _reportName = HtmlGenerator.WriteToHtml(operationReports, _defaultDirectory);
            ReportUrlText.Text = "http://server1.com/" + _reportName;
            ReportUrlLabel.Visibility = Visibility.Visible;
            ReportUrlLabel.IsEnabled = true;
            ContinueButton.IsEnabled = false;
            ZipGenerator.CreateZipArchive(operationReports, _defaultDirectory);
        }

        private string GetDirectoryForSavingReports()
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
        
        private void ReportUrlClicked(object sender, MouseButtonEventArgs e)
        {
            ReportUrlLabel.Foreground = Brushes.Blue;
            ConsoleCommandHandler.ExecuteWithoutOutput(GetDefaultBrowserPath(), string.Format("{0}/{1}", _defaultDirectory,_reportName), false);
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
