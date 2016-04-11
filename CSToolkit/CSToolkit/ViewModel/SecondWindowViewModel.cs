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
            CloseCommand = new RelayCommand(arg => CloseButtonClicked());
            ContinueCommand = new RelayCommand(arg => ContinueButtonClicked());
            ExitCommand = new RelayCommand(arg => ExitButtonClicked());
            HideCommand = new RelayCommand(arg => HideButtonClicked());
        }

        protected override void ContinueButtonClicked()
        {
            if (!DataIsValid())
                return;

            if (string.IsNullOrEmpty(PingHostText))
                PingHostText = "www.google.com";

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

                if (Proxy1IsValidEvent != null)
                    Proxy1IsValidEvent(this, new DataValidationEventArgs(false));
            }  
            else
            {
                if (Proxy1IsValidEvent != null)
                    Proxy1IsValidEvent(this, new DataValidationEventArgs(true));
            }

            if (!validationRules.IsProxyValid(Proxy2))
            {
                isValid = false;

                if (Proxy2IsValidEvent != null)
                    Proxy2IsValidEvent(this, new DataValidationEventArgs(false));
            }   
            else
            {
                if (Proxy2IsValidEvent != null)
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

                    if (PingHostIsValidEvent != null)
                        PingHostIsValidEvent(this, new DataValidationEventArgs(false));
                }       
                else
                {
                    if (PingHostIsValidEvent != null)
                        PingHostIsValidEvent(this, new DataValidationEventArgs(true));
                }
            }                                            
            return isValid;
        }  
        #endregion
    }
}
