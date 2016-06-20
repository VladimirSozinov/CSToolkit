using CSToolkit.Model;
using CSToolkit.Tools;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;       

namespace CSToolkit.ViewModel
{
    public class ResultWindowViewModel : BaseViewModel
    {                                               
        private ObservableCollection<Operation> _operations;
        private string _windowHeaderText;
        private string _resultText;
        private string _reportName;
        private string _titleText;
        private string _linkButtonText;
        private string _proxy1;
        private string _proxy2;
        private string _pingHost;
        private double _halfOfWindowWidth; 
        private int _counter;

        public event Action HtmlHasGenerated;
        public event Action ZiplHasGenerated;
                                         
        public ICommand LinkCommand { get; set; }

        public ResultWindowViewModel(double left, double top, string proxy1, string proxy2, string pingHost) : base(left, top)
        {
            DefaultWindowHeight = 440; 
            DefaultWindowWidth = 825;
            Proxy1 = proxy1;
            Proxy2 = proxy2;
            PingHost = pingHost;
            SetDefaultWindowDimensions();
            SetDefaultFields();
            BindCommands();
            StartProcessing(2000);//Delay
        }

        private void BindCommands()
        {
            HideCommand = new RelayCommand(arg => HideButtonClicked());
            CloseCommand = new RelayCommand(arg => CloseButtonClicked());
            ContinueCommand = new RelayCommand(arg => ContinueButtonClicked());
            ExitCommand = new RelayCommand(arg => ExitButtonClicked());
            LinkCommand = new RelayCommand(arg => LinkButtonClicked());
        }

        private void SetDefaultFields()
        {
            _operations = new ObservableCollection<Operation>();
            WindowHeaderText = string.Format("Results for Primary Proxy= {0} & Secondary Proxy = {1}", Proxy1, Proxy2);
            ResultText = string.Format("Finished 0 out of {0} tests", _operations.Count);
        } 

        private async void StartProcessing(int timeoutInMilliseconds)
        {
            await Task.Delay(timeoutInMilliseconds);
            StartExecuting();
        }

        private void StartExecuting()
        {
            for (int i = 0; i < _operations.Count; i++)
            {
                if (_operations[i].CurrentState == Operation.AdaptedStates[Operation.States.Waiting])
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        _operations[i].CurrentState = Operation.AdaptedStates[Operation.States.InProgress];                           
                    });
                }

                var myWorker = new Executer(_operations[i], i);
                myWorker.ProcessingFinished += ProcessingFinished;  
            }
        }

        private void ProcessingFinished(object sender, MyWorkerEventArgs e)
        {
            int count = _operations.Count(operation => operation.CurrentState == Operation.AdaptedStates[Operation.States.Finished]);
            count ++;// Becouse current operation state still is "In Progress"

            if (count == _operations.Count)
            {
                _reportName = HtmlGenerator.GenerateHtml();
            }

            App.Current.Dispatcher.Invoke((Action)delegate
            {   
                _operations[e.OperationOrdinalNumber].CurrentState = Operation.AdaptedStates[Operation.States.Finished];  
                ResultText = string.Format("Finished {0} out of {1} tests", count, _operations.Count);

                if (count == _operations.Count)
                {
                    ResultText += " - See results in HTML format at ";
                    LinkButtonText = _reportName;

                    if (HtmlHasGenerated != null)
                        HtmlHasGenerated();
                }
            });                                
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
            get { return _resultText; }
            set
            {
                _resultText = value;
                OnPropertyChanged("ResultText");
            }
        }

        public string TitleText
        {
            get { return _titleText; }
            set
            {
                _titleText = value;
                OnPropertyChanged("TitleText");
            }
        }

        public double HalfOfWindowWidth
        {
            get { return _halfOfWindowWidth; }
            set
            {
                _halfOfWindowWidth = value;
                OnPropertyChanged("HalfOfWindowWidth");
            }
        }

        public string LinkButtonText
        {
            get { return _linkButtonText; }
            set
            {
                _linkButtonText = value;
                OnPropertyChanged("LinkButtonText");
            }
        }
        
        #endregion

        protected override void ContinueButtonClicked()
        {
            var _defaultDirectory = DialogManager.GetDirectoryForSavingReportsDialog();            
            ZipGenerator.CreateZipArchive(_defaultDirectory, _reportName);

            if (ZiplHasGenerated != null && _counter++ == 2)
                ZiplHasGenerated();   
        }

        private void LinkButtonClicked()
        {
            var defaultBrowserPath = ExternalAppsManager.GetDefaultBrowserPath();
            ConsoleCommandHandler.ExecuteWithoutOutput(defaultBrowserPath, string.Format(@"{0}", _reportName), false);
        }
    }
}
