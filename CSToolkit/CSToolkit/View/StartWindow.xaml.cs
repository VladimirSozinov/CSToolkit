using CSToolkit.ViewModel;
using System.Windows;
using System.Windows.Input;

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
