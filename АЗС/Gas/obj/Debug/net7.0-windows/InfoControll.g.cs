﻿#pragma checksum "..\..\..\InfoControll.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60DBEDCA31C372FBF4DFF187A78A2FEA11D34D46"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Gas;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Gas {
    
    
    /// <summary>
    /// InfoControll
    /// </summary>
    public partial class InfoControll : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\InfoControll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement VideoElement;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\InfoControll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressIndicator;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\InfoControll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimeText;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\InfoControll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BeginButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\InfoControll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StopButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\InfoControll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PauseButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\InfoControll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SpeedUpButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\InfoControll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SlowdownSpeedButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\InfoControll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetNormalSpeedButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Gas;component/infocontroll.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\InfoControll.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.VideoElement = ((System.Windows.Controls.MediaElement)(target));
            
            #line 16 "..\..\..\InfoControll.xaml"
            this.VideoElement.MediaOpened += new System.Windows.RoutedEventHandler(this.VideoElement_OnMediaOpened);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ProgressIndicator = ((System.Windows.Controls.ProgressBar)(target));
            
            #line 20 "..\..\..\InfoControll.xaml"
            this.ProgressIndicator.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ProgressIndicator_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TimeText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.BeginButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\InfoControll.xaml"
            this.BeginButton.Click += new System.Windows.RoutedEventHandler(this.BeginButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.StopButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\InfoControll.xaml"
            this.StopButton.Click += new System.Windows.RoutedEventHandler(this.StopButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PauseButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\InfoControll.xaml"
            this.PauseButton.Click += new System.Windows.RoutedEventHandler(this.PauseButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SpeedUpButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\InfoControll.xaml"
            this.SpeedUpButton.Click += new System.Windows.RoutedEventHandler(this.SpeedUpButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SlowdownSpeedButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\InfoControll.xaml"
            this.SlowdownSpeedButton.Click += new System.Windows.RoutedEventHandler(this.SlowdownSpeedButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.GetNormalSpeedButton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\InfoControll.xaml"
            this.GetNormalSpeedButton.Click += new System.Windows.RoutedEventHandler(this.GetNormalSpeedButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

