﻿#pragma checksum "..\..\..\Views\Designer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BBAD79E24BDF03EDAB855EF6FFE49ACE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ReportingDesigner.Controls;
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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams.Extensions;
using Telerik.Windows.Controls.Diagrams.Primitives;


namespace ReportingDesigner.Views {
    
    
    /// <summary>
    /// Designer
    /// </summary>
    public partial class Designer : Telerik.Windows.Controls.RadDiagram, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Views\Designer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReportingDesigner.Views.Designer Diagram;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\Designer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.Diagrams.Extensions.SettingsPane SettingPane;
        
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
            System.Uri resourceLocater = new System.Uri("/ReportingDesigner;component/views/designer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Designer.xaml"
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
            this.Diagram = ((ReportingDesigner.Views.Designer)(target));
            
            #line 13 "..\..\..\Views\Designer.xaml"
            this.Diagram.AdditionalContentActivated += new System.EventHandler<Telerik.Windows.Controls.Diagrams.AdditionalContentActivatedEventArgs>(this.Diagram_AdditionalContentActivated);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\Views\Designer.xaml"
            this.Diagram.PreviewDrop += new System.Windows.DragEventHandler(this.Diagram_PreviewDrop);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SettingPane = ((Telerik.Windows.Controls.Diagrams.Extensions.SettingsPane)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

