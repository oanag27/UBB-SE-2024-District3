﻿#pragma checksum "..\..\..\..\ExtraInfo\PaymentForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "392619D20B5813B01C8AFAAE8E6AE30CE056D5F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using District_3_App.ExtraInfo;
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


namespace District_3_App.ExtraInfo {
    
    
    /// <summary>
    /// PaymentForm
    /// </summary>
    public partial class PaymentForm : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\ExtraInfo\PaymentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid CompleteGrid;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\ExtraInfo\PaymentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CardNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\ExtraInfo\PaymentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ExpirationDateTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\ExtraInfo\PaymentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CVVTextBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\ExtraInfo\PaymentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HolderNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\ExtraInfo\PaymentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl PaymentConfirmedControl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/District 3 App;component/extrainfo/paymentform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ExtraInfo\PaymentForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CompleteGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.CardNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ExpirationDateTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CVVTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.HolderNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 52 "..\..\..\..\ExtraInfo\PaymentForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PaymentConfirmedControl = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

