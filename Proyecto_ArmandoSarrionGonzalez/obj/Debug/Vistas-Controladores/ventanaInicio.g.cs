﻿#pragma checksum "..\..\..\Vistas-Controladores\ventanaInicio.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2868156B8CAAA89076CFE12674AF54E62C03AED084313B599135AD46FDBDCB4F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto_ArmandoSarrionGonzalez;
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


namespace Proyecto_ArmandoSarrionGonzalez {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\Vistas-Controladores\ventanaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Proyecto_ArmandoSarrionGonzalez.MainWindow ventanaPrincipal1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Vistas-Controladores\ventanaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Vistas-Controladores\ventanaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistro;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Vistas-Controladores\ventanaInicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgBienvenido;
        
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
            System.Uri resourceLocater = new System.Uri("/Proyecto_ArmandoSarrionGonzalez;component/vistas-controladores/ventanainicio.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vistas-Controladores\ventanaInicio.xaml"
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
            this.ventanaPrincipal1 = ((Proyecto_ArmandoSarrionGonzalez.MainWindow)(target));
            
            #line 8 "..\..\..\Vistas-Controladores\ventanaInicio.xaml"
            this.ventanaPrincipal1.Loaded += new System.Windows.RoutedEventHandler(this.VentanaPrincipal1_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Vistas-Controladores\ventanaInicio.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.BtnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnRegistro = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Vistas-Controladores\ventanaInicio.xaml"
            this.btnRegistro.Click += new System.Windows.RoutedEventHandler(this.BtnRegistro_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imgBienvenido = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
