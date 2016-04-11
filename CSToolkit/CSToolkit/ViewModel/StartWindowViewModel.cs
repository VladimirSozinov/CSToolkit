using CSToolkit.Model;
using CSToolkit.Tools;
using CSToolkit.View;
using System;
using System.Windows;

namespace CSToolkit.ViewModel
{
    public class StartWindowViewModel : BaseViewModel
    {
        private string _userName;
        private string _phoneNumber;
        private string _emailAdress;
        private bool _needToInstallWinPcap = true;
                                                                                                                                    
        public event CustomEvent.CustomHandler NameIsValidEvent;
        public event CustomEvent.CustomHandler SerialNumberIsValidEvent;

        public StartWindowViewModel(double left, double top) : base(left, top)
        {
            SetDefaultWindowDimensions();
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

            if (NeedToInstallWinPcap)
                ConsoleCommandHandler.ExecuteWithoutOutput("WinPcap_4_1_3.exe", "", true);

            var viewModel = new SecondWindowViewModel(Left, Top, Width, Height);
            UserInfo.SetUserInfo(UserName, SerialNumber, EmailAdress);

            var view = new SecondWindow { DataContext = viewModel };
            view.Show();
            WindowVisibility = Visibility.Hidden;
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

        public bool NeedToInstallWinPcap
        {
            get { return _needToInstallWinPcap; }
            set
            {
                _needToInstallWinPcap = value;
                OnPropertyChanged("NeedToInstallWinPcap");
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

                if (NameIsValidEvent != null)
                    NameIsValidEvent(this, new DataValidationEventArgs(false));
            }
            else
            {
                if (NameIsValidEvent != null)
                    NameIsValidEvent(this, new DataValidationEventArgs(true));
            }

            if ( !validationRules.IsSerialNumberValid( SerialNumber ))
            {
                isValid = false;

                if (SerialNumberIsValidEvent != null)
                    SerialNumberIsValidEvent(this, new DataValidationEventArgs(false));
            }
            else
            {
                if (SerialNumberIsValidEvent != null)
                    SerialNumberIsValidEvent(this, new DataValidationEventArgs(true));
            }    
            return isValid;
        }
    #endregion
    }
}
