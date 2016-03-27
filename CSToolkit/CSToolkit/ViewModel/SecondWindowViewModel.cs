﻿using CSToolkit.Model;
using CSToolkit.Validators;
using System.Windows;
using System.Windows.Media;
using CSToolkit.View;

namespace CSToolkit.ViewModel
{
    public class SecondWindowViewModel : BaseViewModel
    {
        public string Proxy1 { get; set; }
        public string Proxy2 { get; set; }
        public string PingHostText { get; set; }

        public Brush Proxy1BorderBrush { get; set; }
        public Brush Proxy2BorderBrush { get; set; }
        public Brush PingHostBorderBrush { get; set; }

        public SecondWindowRules rules;
        
        private double _top;
        private double _left;
        private double _lastTop;
        private double _lastLeft;
        private double _height;
        private double _width;
        private Visibility _windowVisibility;
        private bool _windowIsMax;
        private const double DefaultWindowHeight = 330;
        private const double DefaultWindowWidth = 625;


        public delegate void CustomHandler(object sender, DataValidationEventArgs isValid);

        public event CustomHandler Proxy1IsValidEvent;
        public event CustomHandler Proxy2IsValidEvent;
        public event CustomHandler PingHostIsValidEvent;

        public SecondWindowViewModel(double left, double top, double width, double height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            BrushConverter bc = new BrushConverter();
            PingHostText = "www.google.com";
            BindCommands();
            Proxy1BorderBrush = (Brush)bc.ConvertFrom("#FFABADB3");
            Proxy2BorderBrush = (Brush)bc.ConvertFrom("#FFABADB3");
            PingHostBorderBrush = (Brush)bc.ConvertFrom("#FFABADB3");
            rules = new SecondWindowRules();
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
                Height = DefaultWindowHeight;
                Width = DefaultWindowWidth;
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

    #region DataValidation

        private bool DataIsValid()
        {
            bool isValid = true;

            if (!rules.IsProxyValid(Proxy1))
            {
                isValid = false;
                Proxy1IsValidEvent(this, new DataValidationEventArgs(false));
            }

            else
            {
                Proxy1IsValidEvent(this, new DataValidationEventArgs(true));
            }

            if (!rules.IsProxyValid(Proxy2))
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
                if (!rules.IsPingHostValid(PingHostText))
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
