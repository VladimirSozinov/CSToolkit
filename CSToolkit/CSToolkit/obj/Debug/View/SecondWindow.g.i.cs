﻿#pragma checksum "..\..\..\View\SecondWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8734A38C23ED6F6E0917E2DBED0FD473"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CSToolkit.Validators;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CSToolkit.View {
    
    
    /// <summary>
    /// SecondWindow
    /// </summary>
    public partial class SecondWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 53 "..\..\..\View\SecondWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Proxy1TextBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\View\SecondWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Proxy2TextBox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\View\SecondWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PingHostTextBox;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\View\SecondWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ContinueButton;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\View\SecondWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CSToolkit;component/view/secondwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\SecondWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\..\View\SecondWindow.xaml"
            ((CSToolkit.View.SecondWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Proxy1TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Proxy2TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PingHostTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\View\SecondWindow.xaml"
            this.PingHostTextBox.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.PingHostPreviewMouseUp);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\View\SecondWindow.xaml"
            this.PingHostTextBox.PreviewLostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.PingHostPreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ContinueButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

