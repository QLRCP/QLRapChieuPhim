﻿#pragma checksum "..\..\Giao_dien_quan_ly_phim.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "237F6D3AF3197C98CA74FCA16918C5A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
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
    /// Giao_dien_quan_ly_phim
    /// </summary>
    public partial class Giao_dien_quan_ly_phim : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Giao_dien_quan_ly_phim.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu mn_QuanLiPhim;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Giao_dien_quan_ly_phim.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mn_NhapPhim;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Giao_dien_quan_ly_phim.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mn_SuaPhim;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Giao_dien_quan_ly_phim.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mn_NhapSuatChieu;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Giao_dien_quan_ly_phim.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mn_SuaSuatChieu;
        
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
            System.Uri resourceLocater = new System.Uri("/ETN_Cinema;component/giao_dien_quan_ly_phim.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Giao_dien_quan_ly_phim.xaml"
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
            this.mn_NhapPhim = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\Giao_dien_quan_ly_phim.xaml"
            this.mn_NhapPhim.Click += new System.Windows.RoutedEventHandler(this.mn_NhapPhim_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mn_SuaPhim = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\Giao_dien_quan_ly_phim.xaml"
            this.mn_SuaPhim.Click += new System.Windows.RoutedEventHandler(this.mn_SuaPhim_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.mn_NhapSuatChieu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 23 "..\..\Giao_dien_quan_ly_phim.xaml"
            this.mn_NhapSuatChieu.Click += new System.Windows.RoutedEventHandler(this.mn_NhapSuatChieu_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mn_SuaSuatChieu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\Giao_dien_quan_ly_phim.xaml"
            this.mn_SuaSuatChieu.Click += new System.Windows.RoutedEventHandler(this.mn_SuaSuatChieu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

