﻿#pragma checksum "..\..\ReportWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D4635222D4AFB7789B00A6A082CE6566"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ReportingDesigner.Commands;
using ReportingDesigner.Controls;
using ReportingDesigner.Views;
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
using Telerik.Windows.Controls.Diagrams.Extensions;


namespace ReportingDesigner {
    
    
    /// <summary>
    /// ReportWindow
    /// </summary>
    public partial class ReportWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 186 "..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReportingDesigner.Controls.Toolbox Toolbox;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.Diagrams.Extensions.RadDiagramRuler TopRuler;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.Diagrams.Extensions.RadDiagramRuler SideRuler;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReportingDesigner.Views.DesignerContainer Designer;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.Diagrams.Extensions.RadDiagramNavigationPane navigationPane;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReportingDesigner.Views.PageNumberView PageNumberView;
        
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
            System.Uri resourceLocater = new System.Uri("/ReportingDesigner;component/reportwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReportWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.Toolbox = ((ReportingDesigner.Controls.Toolbox)(target));
            return;
            case 2:
            this.TopRuler = ((Telerik.Windows.Controls.Diagrams.Extensions.RadDiagramRuler)(target));
            return;
            case 3:
            this.SideRuler = ((Telerik.Windows.Controls.Diagrams.Extensions.RadDiagramRuler)(target));
            return;
            case 4:
            this.Designer = ((ReportingDesigner.Views.DesignerContainer)(target));
            return;
            case 5:
            this.navigationPane = ((Telerik.Windows.Controls.Diagrams.Extensions.RadDiagramNavigationPane)(target));
            return;
            case 6:
            this.PageNumberView = ((ReportingDesigner.Views.PageNumberView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

