#pragma checksum "..\..\Cart.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6E835DF35D8FDD4B70374903242F3F306B28F9812287E23ED6DB41F2E952C2A6"
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
    /// Cart
    /// </summary>
    public partial class Cart : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 75 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProductsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Checkoutbtn;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Totaltxt;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TotalPricetxt;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Remove;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductNametxt;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Addresstxt;
        
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
            System.Uri resourceLocater = new System.Uri("/InventoryManagment;component/cart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Cart.xaml"
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
            this.ProductsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 75 "..\..\Cart.xaml"
            this.ProductsDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ProductsDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\Cart.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Checkoutbtn = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\Cart.xaml"
            this.Checkoutbtn.Click += new System.Windows.RoutedEventHandler(this.Checkoutbtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Totaltxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TotalPricetxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Remove = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\Cart.xaml"
            this.Remove.Click += new System.Windows.RoutedEventHandler(this.Remove_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ProductNametxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Addresstxt = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

