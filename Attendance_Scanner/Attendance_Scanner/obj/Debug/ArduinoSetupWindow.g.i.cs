﻿#pragma checksum "..\..\ArduinoSetupWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ADFEDD34511BB33166BD2080BCD3BF6C7B93E2A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Attendance_Scanner;
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


namespace Attendance_Scanner {
    
    
    /// <summary>
    /// ArduinoSetupWindow
    /// </summary>
    public partial class ArduinoSetupWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ArduinoSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox COMBOX_Ports;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ArduinoSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_Refresh;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ArduinoSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_Connect;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ArduinoSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LBL_LastRead;
        
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
            System.Uri resourceLocater = new System.Uri("/Attendance_Scanner;component/arduinosetupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ArduinoSetupWindow.xaml"
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
            this.COMBOX_Ports = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.BTN_Refresh = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ArduinoSetupWindow.xaml"
            this.BTN_Refresh.Click += new System.Windows.RoutedEventHandler(this.BTN_Refresh_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BTN_Connect = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ArduinoSetupWindow.xaml"
            this.BTN_Connect.Click += new System.Windows.RoutedEventHandler(this.BTN_Connect_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LBL_LastRead = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

