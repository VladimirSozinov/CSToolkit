using CSToolkit.Model;
using CSToolkit.Validators;
using CSToolkit.View;
using System.Windows;
using System.Windows.Media;

namespace CSToolkit.ViewModel
{
    public class SecondWindowViewModel : BaseViewModel
    {                                                                                       
        public event CustomEvent.CustomHandler Proxy1IsValidEvent;
        public event CustomEvent.CustomHandler Proxy2IsValidEvent;
        public event CustomEvent.CustomHandler PingHostIsValidEvent;

        public SecondWindowViewModel(double left, double top, double width, double height) : base(left, top)
        {
            Width = width;
            Height = height;
            PingHostText = "www.google.com";
            BindCommands();
        }

        private void BindCommands()
        {
            ExpandCommand = new RelayCommand(arg => ExpandButtonClicked());
            CloseCommand = new RelayCommand(arg => CloseButtonClicked());
            ContinueCommand = new RelayCommand(arg => ContinueButtonClicked());
            ExitCommand = new RelayCommand(arg => ExitButtonClicked());
            HideCommand = new RelayCommand(arg => HideButtonClicked());
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
                Top = workingArea.Bottom - Height;
                Left = workingArea.Right - Width;
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
            if (!DataIsValid())
                return;

            if (string.IsNullOrEmpty(PingHostText))
                PingHostText = "www.google.com";//todo

            var operations = new Operation().GetOperations(Proxy1, Proxy2, PingHostText);
            var viewModel = new ResultWindowViewModel(Left, Top, Proxy1, Proxy2, PingHostText) { Operations = operations };
            var view = new ResultWindow(Proxy1, Proxy2) { DataContext = viewModel };
            view.Show();
            WindowVisibility = Visibility.Hidden;
        }

    #region Public properties

        public string Proxy1 { get; set; }
        public string Proxy2 { get; set; }
        public string PingHostText { get; set; }

    #endregion

    #region DataValidation

        private bool DataIsValid()
        {
            bool isValid = true;

            if (!validationRules.IsProxyValid(Proxy1))
            {
                isValid = false;
                Proxy1IsValidEvent(this, new DataValidationEventArgs(false));
            }

            else
            {
                Proxy1IsValidEvent(this, new DataValidationEventArgs(true));
            }

            if (!validationRules.IsProxyValid(Proxy2))
            {
                isValid = false;
                Proxy2IsValidEvent(this, new DataValidationEventArgs(false));
            }

            else
            {
                Proxy2IsValidEvent(this, new DataValidationEventArgs(true));
            }

            if (string.IsNullOrEmpty(PingHostText))
            {
                PingHostText = "www.google.com";
            }

            else
            {
                if (!validationRules.IsPingHostValid(PingHostText))
                {
                    isValid = false;
                    PingHostIsValidEvent(this, new DataValidationEventArgs(false));
                }

                else
                {
                    PingHostIsValidEvent(this, new DataValidationEventArgs(true));
                }
            }
                                      
            return isValid;
        }  
        #endregion
    }
}
