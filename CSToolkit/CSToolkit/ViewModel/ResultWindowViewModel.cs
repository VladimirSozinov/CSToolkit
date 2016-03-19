using CSToolkit.Model;
using System.Collections.ObjectModel;
using System.Windows;

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
        private const double DefaultWindowHeight = 380;
        private const double DefaultWindowWidth = 625;
        private Visibility _windowVisibility;
        private bool _windowIsMax;

        public ResultWindowViewModel(double left, double top)
        {
            SetDefaultConstraints(left ,top);
            BindCommands();
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

        #endregion

        public void SetValues(string proxy1, string proxy2, string pingHostText, ObservableCollection<Operation> operations)
        {
            _proxy1 = proxy1;
            _proxy2 = proxy2;
            _pingHost = pingHostText;
            WindowHeaderText = string.Format("Result for Proxy1: {0}, Proxy2: {1}, Host: {2}", _proxy1, _proxy2, _pingHost);
        }

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
    }
}
