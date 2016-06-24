using CSToolkit.Model;
using CSToolkit.View;
using System.Windows;
using System.Windows.Input;

namespace CSToolkit.ViewModel
{
    public class StartWindowViewModel : BaseViewModel
    {
        private string _userName;
        private string _phoneNumber;
        private string _emailAdress;
        private string _expandInfoAreaButtonText = "+";

        public ICommand ExpandInfoAreaCommand { get; set; }
                                                                                                                                    
        public event CustomEvent.CustomHandler NameIsValidEvent;
        public event CustomEvent.CustomHandler SerialNumberIsValidEvent;

        public StartWindowViewModel(double left, double top) : base(left, top)
        {
            SetDefaultWindowDimensions();
            BindCommands();
        }

        private void BindCommands()
        {
            ExpandInfoAreaCommand = new RelayCommand(arg => ExpandInfoAreaButtonClicked());
            CloseCommand = new RelayCommand(arg => CloseButtonClicked());
            ContinueCommand = new RelayCommand(arg => ContinueButtonClicked());
            ExitCommand = new RelayCommand(arg => ExitButtonClicked());
            HideCommand = new RelayCommand(arg => HideButtonClicked());
        }

        protected override void ContinueButtonClicked()
        {
            if (!DataIsValid())
                return;
            
            var viewModel = new SecondWindowViewModel(Left, Top, Width, Height);
            UserInfo.SetUserInfo(UserName, SerialNumber, EmailAdress);

            var view = new SecondWindow { DataContext = viewModel };
            view.Show();
            WindowVisibility = Visibility.Hidden;
        }

        private void ExpandInfoAreaButtonClicked()
        {
            if(ExpandInfoAreaButtonText == "+")
            {
                ExpandInfoAreaButtonText = "-";
                Height = DefaultWindowHeight + 170;
            }
            else
            {
                ExpandInfoAreaButtonText = "+";
                Height = DefaultWindowHeight;
            }
        }

    #region Public properties

        public string UserName
        { 
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");               
            }
        }

        public string SerialNumber
        {
            get { return _phoneNumber; }
            set
            {
               _phoneNumber = value;
               OnPropertyChanged("SerialNumber");                  
            }
        }

        public string EmailAdress
        {
            get { return _emailAdress; }
            set
            {
                _emailAdress = value;
                OnPropertyChanged("EmailAdress");
            }
        }

        public string ExpandInfoAreaButtonText 
        {
            get { return _expandInfoAreaButtonText; }
            set
            {
                _expandInfoAreaButtonText = value;
                OnPropertyChanged("ExpandInfoAreaButtonText");
            }
        }
    #endregion

    #region DataValidation

        private bool DataIsValid()
        {
            bool isValid = true;

            if ( !validationRules.IsUserNameValid( UserName ))
            {
                isValid = false;
                NameIsValidEvent?.Invoke(this, new DataValidationEventArgs(false));
            }
            else
            {
                NameIsValidEvent?.Invoke(this, new DataValidationEventArgs(true));
            }

            if ( !validationRules.IsSerialNumberValid( SerialNumber ))
            {
                isValid = false;
                SerialNumberIsValidEvent?.Invoke(this, new DataValidationEventArgs(false));
            }
            else
            {
                SerialNumberIsValidEvent?.Invoke(this, new DataValidationEventArgs(true));
            }    
            return isValid;
        }
    #endregion
    }
}
