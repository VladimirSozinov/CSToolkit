﻿using CSToolkit.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CSToolkit.View
{
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            DataContextChanged += new DependencyPropertyChangedEventHandler(SecondWindowDataContextChanged);
            PingHostTextBox.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFABADB3");
        }

        private void SecondWindowDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = DataContext as SecondWindowViewModel;

            if (viewModel == null)
                return;

            viewModel.HideButtonClickedEvent += HideClicked;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ContinueButtonClicked(object sender, EventArgs args)
        {
            BrushConverter bc = new BrushConverter();

            if (!string.IsNullOrEmpty(Proxy1TextBox.Text) && !string.IsNullOrEmpty(Proxy2TextBox.Text))
            {
                Proxy1TextBox.BorderBrush = (Brush)bc.ConvertFrom("#FFABADB3");
                Proxy2TextBox.BorderBrush = (Brush)bc.ConvertFrom("#FFABADB3");
                PingHostTextBox.BorderBrush = (Brush)bc.ConvertFrom("#FFABADB3");
            }
        }

        private void HideClicked()
        {
            WindowState = WindowState.Minimized;
        }

        private void PingHostPreviewMouseUp(object sender, EventArgs args)
        {
            PingHostTextBox.Foreground = Brushes.Black;
            PingHostTextBox.Text = "";
        }

        private void PingHostPreviewMouseDown(object sender, EventArgs args)
        {
            if ( string.IsNullOrEmpty( PingHostTextBox.Text ))
                PingHostTextBox.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFABADB3");
                PingHostTextBox.Text = "www.google.com";
        }
    }
}
