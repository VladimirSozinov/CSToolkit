using CSToolkit.View;
using CSToolkit.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CSToolkit
{
    public partial class App : Application
    {
        private const double StartLeftPoint = 50;
        private const double StartTopPoint = 50;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewModel = new StartWindowViewModel(StartLeftPoint, StartTopPoint);
            var view = new StartWindow() { DataContext = viewModel};
        }
    }
}
