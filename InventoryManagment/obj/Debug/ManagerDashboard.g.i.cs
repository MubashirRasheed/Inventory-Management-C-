#pragma checksum "..\..\ManagerDashboard.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0462AC81C46C7A6B6A1FF059D30F4B752E1E444E1842C0B04D080D6692EEAC06"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InventoryManagment;
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


namespace InventoryManagment {
    
    
    /// <summary>
    /// ManagerDashboard
    /// </summary>
    public partial class ManagerDashboard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 77 "..\..\ManagerDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPro;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\ManagerDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ManagePro;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\ManagerDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ManageEmp;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\ManagerDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Logout;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\ManagerDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
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
            System.Uri resourceLocater = new System.Uri("/InventoryManagment;component/managerdashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ManagerDashboard.xaml"
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
            this.AddPro = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\ManagerDashboard.xaml"
            this.AddPro.Click += new System.Windows.RoutedEventHandler(this.Add_Products);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ManagePro = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\ManagerDashboard.xaml"
            this.ManagePro.Click += new System.Windows.RoutedEventHandler(this.ManagePro_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ManageEmp = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\ManagerDashboard.xaml"
            this.ManageEmp.Click += new System.Windows.RoutedEventHandler(this.ManageEmp_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Logout = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\ManagerDashboard.xaml"
            this.Logout.Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\ManagerDashboard.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

