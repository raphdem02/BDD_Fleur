﻿#pragma checksum "..\..\..\StoreOrder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1FCFA1C4B467421B444A010D820AC4C51DBB6539"
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
    /// StoreOrder
    /// </summary>
    public partial class StoreOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\StoreOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxOrderId;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\StoreOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxStatusOrder;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\StoreOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxDescription;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\StoreOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPrixMax;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\StoreOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\StoreOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BouttonMAJ;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\StoreOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar cldSample;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\StoreOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BouttonDelete;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\StoreOrder.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Bdd_Fleur_Demare_Delgado;component/storeorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\StoreOrder.xaml"
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
            this.TextBoxOrderId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBoxStatusOrder = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxPrixMax = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.BouttonMAJ = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\StoreOrder.xaml"
            this.BouttonMAJ.Click += new System.Windows.RoutedEventHandler(this.BouttonMAJ_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cldSample = ((System.Windows.Controls.Calendar)(target));
            return;
            case 8:
            this.BouttonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\..\StoreOrder.xaml"
            this.BouttonDelete.Click += new System.Windows.RoutedEventHandler(this.BouttonDelete_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BouttonMenu = ((System.Windows.Controls.Button)(target));
            
            #line 143 "..\..\..\StoreOrder.xaml"
            this.BouttonMenu.Click += new System.Windows.RoutedEventHandler(this.BouttonMenu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

