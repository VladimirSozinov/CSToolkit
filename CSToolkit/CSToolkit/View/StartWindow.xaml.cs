using CSToolkit.ViewModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CSToolkit.View
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            DataContextChanged += new DependencyPropertyChangedEventHandler(StartWindowDataContextChanged);
        }

        private void StartWindowDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = DataContext as StartWindowViewModel;  

            if (viewModel == null)
                return;

            viewModel.HideButtonClickedEvent += HideClicked;
            viewModel.NameIsValidEvent += viewModelNameIsValidEvent;
            viewModel.SerialNumberIsValidEvent += viewModelSerialNumberIsValidEvent;
        }

        private void viewModelNameIsValidEvent(object sender, DataValidationEventArgs e)
        {
            if (e.IsValid)
            {
                CustomerNameTextBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FFABADB3");
                CustomerNameTextBox.ToolTip = null;
            }
            else
            {
                CustomerNameTextBox.BorderBrush = Brushes.Red;
                CustomerNameTextBox.ToolTip = "Incorrect Value";
            }
        }

        private void viewModelSerialNumberIsValidEvent(object sender, DataValidationEventArgs e)
        {
            if (e.IsValid)
            {
                SerialNumberTextBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FFABADB3");
                SerialNumberTextBox.ToolTip = null;
            }
            else
            {
                SerialNumberTextBox.BorderBrush = Brushes.Red;
                SerialNumberTextBox.ToolTip = "Incorrect Value";
            }
        }

        private void HideClicked()
        {
            WindowState = WindowState.Minimized;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
