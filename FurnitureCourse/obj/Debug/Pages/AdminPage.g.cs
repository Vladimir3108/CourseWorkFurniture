﻿#pragma checksum "..\..\..\Pages\AdminPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "059E77B404F1F3B5E3C51B7A74780B5D112FA263B2248987704F2E2380058728"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FurnitureCourse.Pages;
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


namespace FurnitureCourse.Pages {
    
    
    /// <summary>
    /// AdminPage
    /// </summary>
    public partial class AdminPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CategoryBtn;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MaterialBtn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FurnitureBtn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ManufacturerBtn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserBtn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogOutBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/FurnitureCourse;component/pages/adminpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AdminPage.xaml"
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
            this.CategoryBtn = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Pages\AdminPage.xaml"
            this.CategoryBtn.Click += new System.Windows.RoutedEventHandler(this.CategoryBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MaterialBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Pages\AdminPage.xaml"
            this.MaterialBtn.Click += new System.Windows.RoutedEventHandler(this.MaterialBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FurnitureBtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Pages\AdminPage.xaml"
            this.FurnitureBtn.Click += new System.Windows.RoutedEventHandler(this.FurnitureBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ManufacturerBtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Pages\AdminPage.xaml"
            this.ManufacturerBtn.Click += new System.Windows.RoutedEventHandler(this.ManufacturerBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UserBtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Pages\AdminPage.xaml"
            this.UserBtn.Click += new System.Windows.RoutedEventHandler(this.UserBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LogOutBtn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Pages\AdminPage.xaml"
            this.LogOutBtn.Click += new System.Windows.RoutedEventHandler(this.LogOutBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

