﻿#pragma checksum "..\..\Giao dien tinh gia ve.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "927E6FDA5872788998A2795BC55F80B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace ETN_Cinema {
    
    
    /// <summary>
    /// Giao_dien_tinh_gia_ve
    /// </summary>
    public partial class Giao_dien_tinh_gia_ve : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\Giao dien tinh gia ve.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_MaKH;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\Giao dien tinh gia ve.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_MaKH;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Giao dien tinh gia ve.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl CheckBoxes;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Giao dien tinh gia ve.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Submit;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Giao dien tinh gia ve.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_TongHoaDon;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Giao dien tinh gia ve.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_XuatTongTien;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Giao dien tinh gia ve.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_CheckKH;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Giao dien tinh gia ve.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_Exist;
        
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
            System.Uri resourceLocater = new System.Uri("/ETN_Cinema;component/giao%20dien%20tinh%20gia%20ve.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Giao dien tinh gia ve.xaml"
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
            this.lb_MaKH = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.tb_MaKH = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.CheckBoxes = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 4:
            this.btn_Submit = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Giao dien tinh gia ve.xaml"
            this.btn_Submit.Click += new System.Windows.RoutedEventHandler(this.btn_Submit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lb_TongHoaDon = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lb_XuatTongTien = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btn_CheckKH = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Giao dien tinh gia ve.xaml"
            this.btn_CheckKH.Click += new System.Windows.RoutedEventHandler(this.btn_CheckKH_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lb_Exist = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

