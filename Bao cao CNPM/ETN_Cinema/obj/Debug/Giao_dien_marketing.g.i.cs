﻿#pragma checksum "..\..\Giao_dien_marketing.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DFE2E259E8138436259C32D223D06A16"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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
    /// Giao_dien_marketing
    /// </summary>
    public partial class Giao_dien_marketing : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\Giao_dien_marketing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu mn_QuanLiPhim;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\Giao_dien_marketing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mn_NhapKhuyenMai;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Giao_dien_marketing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mn_SuaKhuyenMai;
        
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
            System.Uri resourceLocater = new System.Uri("/ETN_Cinema;component/giao_dien_marketing.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Giao_dien_marketing.xaml"
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
            this.mn_QuanLiPhim = ((System.Windows.Controls.Menu)(target));
            return;
            case 2:
            this.mn_NhapKhuyenMai = ((System.Windows.Controls.MenuItem)(target));
            
            #line 6 "..\..\Giao_dien_marketing.xaml"
            this.mn_NhapKhuyenMai.Click += new System.Windows.RoutedEventHandler(this.mn_NhapKhuyenMai_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mn_SuaKhuyenMai = ((System.Windows.Controls.MenuItem)(target));
            
            #line 11 "..\..\Giao_dien_marketing.xaml"
            this.mn_SuaKhuyenMai.Click += new System.Windows.RoutedEventHandler(this.mn_SuaKhuyenMai_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

