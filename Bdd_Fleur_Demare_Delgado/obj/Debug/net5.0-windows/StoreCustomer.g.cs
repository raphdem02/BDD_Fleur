﻿#pragma checksum "..\..\..\StoreCustomer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D1FD5CBA6C7A7F1A2A0776FE81ACB1ACBC40477C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Bdd_Fleur_Demare_Delgado;
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


namespace Bdd_Fleur_Demare_Delgado {
    
    
    /// <summary>
    /// StoreCustomer
    /// </summary>
    public partial class StoreCustomer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\StoreCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxNameCustomer;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\StoreCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxMailCustomer;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\StoreCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\StoreCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BouttonMAJ;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\StoreCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BouttonExportXML;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\StoreCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BouttonExportJSON;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\StoreCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BouttonMenu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Bdd_Fleur_Demare_Delgado;component/storecustomer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\StoreCustomer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBoxNameCustomer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBoxMailCustomer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.BouttonMAJ = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\StoreCustomer.xaml"
            this.BouttonMAJ.Click += new System.Windows.RoutedEventHandler(this.BouttonMAJ_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BouttonExportXML = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\StoreCustomer.xaml"
            this.BouttonExportXML.Click += new System.Windows.RoutedEventHandler(this.BouttonExport_XML);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BouttonExportJSON = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\StoreCustomer.xaml"
            this.BouttonExportJSON.Click += new System.Windows.RoutedEventHandler(this.BouttonExport_JSON);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BouttonMenu = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\StoreCustomer.xaml"
            this.BouttonMenu.Click += new System.Windows.RoutedEventHandler(this.BouttonMenu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

