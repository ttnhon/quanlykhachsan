<<<<<<< HEAD
﻿#pragma checksum "..\..\ThuePhong.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FA3A29BEB4FEA305C038C1DFD9A784FF"
=======
﻿#pragma checksum "..\..\ThuePhong.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AEEA8B5A4DEFD8B759A023CD1CD93F0A7A797D8A"
>>>>>>> origin/master
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QLKS;
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


namespace QLKS {
    
    
    /// <summary>
    /// ThuePhong
    /// </summary>
    public partial class ThuePhong : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\ThuePhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer MyScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ThuePhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrapPanel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ThuePhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Capnhat;
        
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
            System.Uri resourceLocater = new System.Uri("/QLKS;component/thuephong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ThuePhong.xaml"
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
            
            #line 11 "..\..\ThuePhong.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuKhachThuePhong_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 19 "..\..\ThuePhong.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuDatPhong_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 20 "..\..\ThuePhong.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuChiTietDatPhong_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 22 "..\..\ThuePhong.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuDonPhong_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 23 "..\..\ThuePhong.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuSuaPhong_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MyScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 7:
            this.wrapPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 8:
            this.btn_Capnhat = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\ThuePhong.xaml"
            this.btn_Capnhat.Click += new System.Windows.RoutedEventHandler(this.btn_Capnhat_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

