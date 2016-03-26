using CSToolkit.Tools;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using CSToolkit.Model;
using CSToolkit.View;

namespace CSToolkit.ViewModel
{
    public class StartWindowViewModel : BaseViewModel, IDataErrorInfo
    {
        private string _userName;
        private string _phoneNumber;
        private string _emailAdress;
        private bool _needToInstallWinPcap = true;
        private const string NameRegex = @"^[\D]+$";
        private const string PhoneNumberRegex = @"^[\d]+$";
        private const double DefaultWindowHeight = 330;
        private const double DefaultWindowWidth = 625;
        private double _top;
        private double _left;
        private double _lastTop;
        private double _lastLeft;
        private double _height;
        private double _width;
        private Visibility _windowVisibility;
        private bool _windowIsMax;

        public StartWindowViewModel(double left, double top)
        {
            Left = left;
            Top = top;
            SetDefaultWindowDimensions();
            BindCommands();
        }

        #region IDataErrorInfo Members

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "UserName")
                {
                    if (!NameIsValid()) return "Incorrect value";
                }

                if (columnName == "PhoneNumber")
                {
                    if (!PhoneIsValid()) return "Incorrect value";
                }

                return null;
            }
        }

        #endregion

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

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
               _phoneNumber = value;
               OnPropertyChanged("PhoneNumber");
               
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

        protected override void ExpandButtonClicked()
        {
            var workingArea = SystemParameters.WorkArea;

            if (_windowIsMax == false)
            {
                Height = workingArea.Height;
                Width = workingArea.Width;
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
            if (!NameIsValid() || !PhoneIsValid()) return;

            if (NeedToInstallWinPcap)
                ConsoleCommandHandler.ExecuteWithoutOutput("WinPcap_4_1_2.exe", "", true);

            var viewModel = new SecondWindowViewModel(Left, Top, Width, Height);
            UserInfo.SetUserInfo(UserName, PhoneNumber, EmailAdress);

            var view = new SecondWindow { DataContext = viewModel };
            view.Show(); 
            WindowVisibility = Visibility.Hidden;
        }

        private void SetDefaultWindowDimensions()
        {
            Height = DefaultWindowHeight;
            Width = DefaultWindowWidth;
        }

        private void BindCommands()
        {
            ExpandCommand = new RelayCommand(arg => ExpandButtonClicked());
            CloseCommand = new RelayCommand(arg => CloseButtonClicked());
            ContinueCommand = new RelayCommand(arg => ContinueButtonClicked());
            ExitCommand = new RelayCommand(arg => ExitButtonClicked());
            HideCommand = new RelayCommand(arg => HideButtonClicked());
        }

        private bool NameIsValid()
        {
            return !string.IsNullOrEmpty(UserName);
        }

        private bool PhoneIsValid()
        {
            return !string.IsNullOrEmpty(PhoneNumber) && new Regex(PhoneNumberRegex).Match(PhoneNumber).Success;
        }
    }
}
