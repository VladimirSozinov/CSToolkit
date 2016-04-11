using CSToolkit.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace CSToolkit.View
{
    public partial class ResultWindow : Window
    {                  
        public ResultWindow(string proxy1, string proxy2)
        {
            InitializeComponent();
            DataContextChanged += new DependencyPropertyChangedEventHandler(ResultWindowDataContextChanged);
        }
        
        private void ResultWindowDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = DataContext as ResultWindowViewModel;

            if (viewModel == null)
                return;

            viewModel.HideButtonClickedEvent += HideClicked;
            viewModel.HtmlHasGenerated += HtmlHasGenerated;
            viewModel.ZiplHasGenerated += ZiplHasGenerated;
        }

        private void HideClicked()
        {
            WindowState = WindowState.Minimized;
        }

        private void HtmlHasGenerated()
        {
            ContinueButton.IsEnabled = true;
            ExitButton.IsEnabled = true;
        }

        private void ZiplHasGenerated()
        {
            ContinueButton.IsEnabled = false;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
