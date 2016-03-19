using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public BaseViewModel()
        {
        }

        protected virtual void HideButtonClicked()
        {
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
