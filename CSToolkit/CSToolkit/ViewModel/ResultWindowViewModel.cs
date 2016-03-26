using CSToolkit.Model;
using CSToolkit.Tools;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CSToolkit.ViewModel
{
    public class ResultWindowViewModel : BaseViewModel
    {
        private string _proxy1;
        private string _proxy2;
        private string _pingHost;
        public string WindowHeaderText { get; set; }

        private double _left;
        private double _top;
        private double _lastLeft;
        private double _lastTop;
        private double _height;
        private double _width;
        private const double DefaultWindowHeight = 400;
        private const double DefaultWindowWidth = 750;
        private Visibility _windowVisibility;
        private ObservableCollection<Operation> _operations;
        private System.Timers.Timer _aTimer;
        private List<OperationReport> _operationReports;
        private bool _windowIsMax;
        private string _resultText;
        private string _defaultDirectory;
        private string _reportName;
        private string _titleText;
        private BackgroundWorker worker;
        private double _halfOfWindowWidth;

        public event CustomHandler HtmlHasGenerated;
        public event Action ZiplHasGenerated;
        public delegate void CustomHandler(object sender, PropertyChangeEventArgs data);

        public ResultWindowViewModel(double left, double top, string proxy1, string proxy2, string pingHost)
        {
            Proxy1 = proxy1;
            Proxy2 = proxy2;
            PingHost = pingHost;
            SetDefaultConstraints(left ,top);
            SetDefaultFields();
            BindCommands();
            StartProcessing();
        }

        private void BindCommands()
        {
            HideCommand = new RelayCommand(arg => HideButtonClicked());
            ExpandCommand = new RelayCommand(arg => ExpandButtonClicked());
            CloseCommand = new RelayCommand(arg => CloseButtonClicked());
            ContinueCommand = new RelayCommand(arg => ContinueButtonClicked());
            ExitCommand = new RelayCommand(arg => ExitButtonClicked());
        }

        private void SetDefaultConstraints()
        {
            Height = DefaultWindowHeight;
            Width = DefaultWindowWidth;
            Left = _lastLeft;
            Top = _lastTop;
        }

        private void SetDefaultConstraints(double left, double top)
        {
            Height = DefaultWindowHeight;
            Width = DefaultWindowWidth;
            Left = left;
            Top = top;
        }

        private void SetDefaultFields()
        {
            _operations = new ObservableCollection<Operation>();
            _operationReports = new List<OperationReport>();
            WindowHeaderText = string.Format("Results for Primary Proxy= {0} & Secondary Proxy = {1}", Proxy1, Proxy2);
            ResultText = string.Format("Finished 0 out of {0} commands", _operations.Count);
        }

        private void StartProcessing()
        {
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

        private void MyStartExecuting()
        {
            for (int i = 0; i < _operations.Count; i++)
            {
                if (_operations[i].CurrentState == Operation.States.Waiting)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        _operations[i].CurrentState = Operation.States.InProgress;
                    });
                }

                try
                {
                    worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(MyWorkerDoWork);
                    worker.RunWorkerAsync(_operations[i]);
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
                reports.Add(new Report(fullCommand, output));
            }

            var operationReport = new OperationReport(operation.TxtName, reports);
            _operationReports.Add(operationReport);
            operation.CurrentState = Operation.States.Finished;

            EvaluateFinishedProcesses();
        }

        private void EvaluateFinishedProcesses()
        {
            int count = _operations.Count(operation => operation.CurrentState == Operation.States.Finished);

            App.Current.Dispatcher.Invoke((Action)delegate
            {
                ResultText = string.Format("Finished {0} out of {1} commands", count, _operations.Count);

                if (count == _operations.Count)
                {
                    GenerateHtmlReport();
                }
            });
        } 
        
        private string GetCurrentDate()
        {
            var date = DateTime.Now;
            return String.Format(@"{0}-{1}GMT", date.ToString("ddMMMMyyyy"), date.ToString("HHmm"));
        }

        private void GenerateHtmlReport()
        {
            UserInfo.CurrentDate = GetCurrentDate();//UserInfo CurrentDate setting
            var listReports = new List<Report>();
            listReports.Add(new Report("user data collecting", UserInfo.GetInfoForReport()));//Adding report for UserInfo
            _operationReports[0] = new OperationReport(_operationReports[0].Operation, listReports);
            _reportName = HtmlGenerator.WriteToHtml(_operationReports);
            var link = _reportName;

            if (HtmlHasGenerated != null)
                HtmlHasGenerated(this, new PropertyChangeEventArgs(link));
        }
                
        #region Public properties

        public double Left
        {
            get { return _left; }
            set
            {
                _left = value;
                OnPropertyChanged("Left");
            }
        }

        public double Top
        {
            get { return _top; }
            set
            {
                _top = value;
                OnPropertyChanged("Top");
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                HalfOfWindowWidth = _width / 2 - 8;
                OnPropertyChanged("Width");
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }

        public Visibility WindowVisibility
        {
            get { return _windowVisibility; }
            set
            {
                _windowVisibility = value;
                OnPropertyChanged("WindowVisibility");
            }
        }

        public string Proxy1
        {
            get { return _proxy1; }
            set
            {
                _proxy1 = value;
                OnPropertyChanged("Proxy1");
            }
        }

        public string Proxy2
        {
            get { return _proxy2; }
            set
            {
                _proxy2 = value;
                OnPropertyChanged("Proxy2");
            }
        }

        public string PingHost
        {
            get { return _pingHost; }
            set
            {
                _pingHost = value;
                OnPropertyChanged("PingHost");
            }
        }

        public ObservableCollection<Operation> Operations
        {
            get { return _operations; }
            set
            {
                _operations = value;
                OnPropertyChanged("Operations");
            }
        }

        public string ResultText
        {
            get
            {
                return _resultText;
            }

            set
            {
                _resultText = value;
                OnPropertyChanged("ResultText");
            }
        }

        public string TitleText
        {
            get
            {
                return _titleText;
            }

            set
            {
                _titleText = value;
                OnPropertyChanged("TitleText");
            }
        }

        public double HalfOfWindowWidth
        {
            get
            {
                return _halfOfWindowWidth;
            }

            set
            {
                _halfOfWindowWidth = value;
                OnPropertyChanged("HalfOfWindowWidth");
            }
        }
        
        #endregion

        protected override void ExpandButtonClicked()
        {
            var workingArea = SystemParameters.WorkArea;

            if (_windowIsMax == false)
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
                SetDefaultConstraints();
                _windowIsMax = false;
            }
        }
        
        protected override void ContinueButtonClicked()
        {
            _defaultDirectory = GetDirectoryForSavingReports();            
            ZipGenerator.CreateZipArchive(_operationReports, _defaultDirectory);
            if (ZiplHasGenerated != null)
                ZiplHasGenerated();
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
            //ReportUrlLabel.Foreground = Brushes.Blue;
            ConsoleCommandHandler.ExecuteWithoutOutput(GetDefaultBrowserPath(), string.Format(@"{0}\{1}", _defaultDirectory, _reportName), false);
        }

        private void ReportUrlButtonReleased(object sender, MouseButtonEventArgs e)
        {
            //ReportUrlLabel.Foreground = Brushes.MediumBlue;
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
