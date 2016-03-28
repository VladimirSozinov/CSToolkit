using CSToolkit.Validators;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CSToolkit.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ICommand HideCommand { get; set; }
        public ICommand ExpandCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand ContinueCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action HideButtonClickedEvent;

        protected double DefaultWindowHeight = 330;
        protected double DefaultWindowWidth = 625;
        protected GeneralValidationRules validationRules;               
        protected double _top;
        protected double _left;
        protected double _lastLeft;
        protected double _lastTop;
        protected double _height;
        protected double _width;
        protected Visibility _windowVisibility;
        protected bool _windowIsMax;

        public BaseViewModel(double left, double top)
        {
            Left = left;
            Top = top;
            validationRules = new GeneralValidationRules();
        }

        protected virtual void HideButtonClicked()
        {
            HideButtonClickedEvent();
        }

        protected virtual void ExpandButtonClicked()
        {
        }

        protected virtual void CloseButtonClicked()
        {
            Application.Current.Shutdown();
        }

        protected virtual void ContinueButtonClicked()
        {
        }  

        protected void ExitButtonClicked()
        {
           Application.Current.Shutdown();
        }
             
        protected void SetDefaultWindowDimensions()
        {
            Height = DefaultWindowHeight;
            Width = DefaultWindowWidth;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    #region Public properties

        public virtual double Left
        {
            get { return _left; }
            set
            {
                _left = value;
                OnPropertyChanged("Left");
            }
        }

        public virtual double Top
        {
            get { return _top; }
            set
            {
                _top = value;
                OnPropertyChanged("Top");
            }
        }

        public virtual double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged("Width");
            }
        }

        public virtual double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }

        public virtual Visibility WindowVisibility
        {
            get { return _windowVisibility; }
            set
            {
                _windowVisibility = value;
                OnPropertyChanged("WindowVisibility");
            }
        }
    #endregion
    }
}
