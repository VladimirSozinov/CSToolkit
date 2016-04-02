using CSToolkit.Model;
using CSToolkit.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CSToolkit.ViewModel
{
    public class ResultWindowViewModel : BaseViewModel
    {                                               
        private ObservableCollection<Operation> _operations;
        private System.Timers.Timer _aTimer;
        private List<OperationReport> _operationReports;
        private string _windowHeaderText;
        private string _resultText;
        private string _reportName;
        private string _titleText;
        private string _linkButtonText;
        private string _proxy1;
        private string _proxy2;
        private string _pingHost;
        private double _halfOfWindowWidth;
        private BackgroundWorker worker;
        private object _syncObject = new Object();  
        private int _counter;

        public event Action HtmlHasGenerated;
        public event Action ZiplHasGenerated;
                                         
        public ICommand LinkCommand { get; set; }

        public ResultWindowViewModel(double left, double top, string proxy1, string proxy2, string pingHost) : base(left, top)
        {
            DefaultWindowHeight = 400; 
            DefaultWindowWidth = 750;
            Proxy1 = proxy1;
            Proxy2 = proxy2;
            PingHost = pingHost;
            SetDefaultWindowDimensions();
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
            LinkCommand = new RelayCommand(arg => LinkButtonClicked());
        }

        private void SetDefaultFields()
        {
            _operations = new ObservableCollection<Operation>();
            _operationReports = new List<OperationReport>();
            WindowHeaderText = string.Format("Results for Primary Proxy= {0} & Secondary Proxy = {1}", Proxy1, Proxy2);
            ResultText = string.Format("Finished 0 out of {0} tests", _operations.Count);
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

            lock(_syncObject)
            {          
                _operationReports.Add(operationReport);
            }

            operation.CurrentState = Operation.States.Finished;  
            EvaluateFinishedProcesses();
        }

        private void EvaluateFinishedProcesses()
        {
            int count = _operations.Count(operation => operation.CurrentState == Operation.States.Finished);

            App.Current.Dispatcher.Invoke((Action)delegate
            {
                ResultText = string.Format("Finished {0} out of {1} tests", count, _operations.Count);

                if (count == _operations.Count)
                {
                    GenerateHtmlReport();
                }
            });
        } 

        private void GenerateHtmlReport()
        {
            AddReportForUserInfo();        
            _reportName = HtmlGenerator.WriteToHtml(_operationReports);
            ResultText += " - See results in HTML format at ";
            LinkButtonText = "http://server1.com/" + _reportName;

            if (HtmlHasGenerated != null)
                HtmlHasGenerated();
        }

        private void AddReportForUserInfo()
        {
            var listReports = new List<Report>();
            listReports.Add(new Report("user data collecting", UserInfo.GetInfoForReport()));//Adding report for UserInfo
            _operationReports[0] = new OperationReport(_operationReports[0].Operation, listReports);
        }
                
    #region Public properties
                                  
        public string WindowHeaderText
        {
            get { return _windowHeaderText; }
            set
            {
                _windowHeaderText = value;
                OnPropertyChanged("WindowHeaderText");
            }
        }
        
        public override double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                HalfOfWindowWidth = _width / 2 - 8;
                OnPropertyChanged("Width");
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

        public string LinkButtonText
        {
            get
            {
                return _linkButtonText;
            }

            set
            {
                _linkButtonText = value;
                OnPropertyChanged("LinkButtonText");
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
                SetDefaultWindowDimensions();
                Left = _lastLeft;
                Top = _lastTop;
                _windowIsMax = false;
            }
        }

        protected override void ContinueButtonClicked()
        {
            var _defaultDirectory = new DialogManager().GetDirectoryForSavingReportsDialog();            
            ZipGenerator.CreateZipArchive(_operationReports, _defaultDirectory, _reportName);

            if (ZiplHasGenerated != null && _counter++ == 2)
                ZiplHasGenerated();   
        }

        private void LinkButtonClicked()
        {
            var pathToDefaultBrowser = new ExternalAppsManager().GetDefaultBrowserPath();
            ConsoleCommandHandler.ExecuteWithoutOutput(pathToDefaultBrowser, string.Format(@"{0}", _reportName), false);
        }
    }
}
