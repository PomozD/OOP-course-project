﻿#pragma checksum "..\..\OrderControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "845340C47CD96B254227C8AD00656BF500A2D30C3E0DD505E4B5B9AAF27E53C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using courseProject;


namespace courseProject {
    
    
    /// <summary>
    /// OrderControl
    /// </summary>
    public partial class OrderControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 77 "..\..\OrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelName_acc;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\OrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelNumber;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\OrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelWantGet;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\OrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LabelComment;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\OrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Agree;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\OrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NotAgree;
        
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
            System.Uri resourceLocater = new System.Uri("/courseProject;component/ordercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OrderControl.xaml"
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
            this.LabelName_acc = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.LabelNumber = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.LabelWantGet = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.LabelComment = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Agree = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\OrderControl.xaml"
            this.Agree.Click += new System.Windows.RoutedEventHandler(this.ButtonAgree);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NotAgree = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\OrderControl.xaml"
            this.NotAgree.Click += new System.Windows.RoutedEventHandler(this.ButtonNotAgree);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

