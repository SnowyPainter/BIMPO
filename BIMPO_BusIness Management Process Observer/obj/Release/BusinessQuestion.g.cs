﻿#pragma checksum "..\..\BusinessQuestion.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22F1043B988B60467648B29BD8EA1892E85E655E"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using BIMPO_BusIness_Management_Process_Observer;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace BIMPO_BusIness_Management_Process_Observer {
    
    
    /// <summary>
    /// BusinessQuestion
    /// </summary>
    public partial class BusinessQuestion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\BusinessQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock captionTextBlock;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\BusinessQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock contentTextBlock;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\BusinessQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkBtn_Clicked;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\BusinessQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NoBtn_Clicked;
        
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
            System.Uri resourceLocater = new System.Uri("/BIMPO_BusIness Management Process Observer;component/businessquestion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BusinessQuestion.xaml"
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
            
            #line 11 "..\..\BusinessQuestion.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.captionTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.contentTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.OkBtn_Clicked = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\BusinessQuestion.xaml"
            this.OkBtn_Clicked.Click += new System.Windows.RoutedEventHandler(this.OkBtn_Clicked_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NoBtn_Clicked = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\BusinessQuestion.xaml"
            this.NoBtn_Clicked.Click += new System.Windows.RoutedEventHandler(this.NoBtn_Clicked_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

