using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    //para hacer fila editable en tab
    [DefaultListViewOptions(true, DevExpress.ExpressApp.NewItemRowPosition.Top)]
    [NavigationItem("Administracion de Solicitudes")]
    [ModelDefault("Caption", "Devolucion Repuestos")]
    [Appearance("enableItems", TargetItems = "TipoDocumentos,fecha,Proveedor,NumeroOrdenFactura,NumeroDescargo", Criteria = "!IsCurrentUserInRole('Administrators')", Visibility = ViewItemVisibility.Hide)]
    [Appearance("enableItems1", TargetItems = "Cantidad,UnidadMedida,Descripcion,PrecioUnitario,Total", Criteria = "!IsCurrentUserInRole('Administrators')", Enabled = false)]
   
    
    public class SolicitudDevolucionRepuesto : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public SolicitudDevolucionRepuesto(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }


        // Fields...
        private int _IdAlmacen;
        private string _Motivo;
        private decimal _Total;
        private SolicitudReparacion _SolicitudReparacion;
        private string _UnidadMedida;
        private string _NumeroDescargo;
        private decimal _PrecioUnitario;
        private string _Descripcion;
        private int _Cantidad;
        private Proveedor _Proveedor;
        private string _NumeroOrdenFactura;
        private DateTime _Fecha;
        private TipoDocumentos _TipoDocumentos;




        [Association("SolicitudReparacion-SolicitudDevolucionRepuesto")]
        public SolicitudReparacion SolicitudReparacion
        {
            get
            {
                return _SolicitudReparacion;
            }
            set
            {
                SetPropertyValue("SolicitudReparacion", ref _SolicitudReparacion, value);
            }
        }


      

        

         [Appearance("IdAlmacen", Visibility = ViewItemVisibility.Hide, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public int IdAlmacen
        {
            get
            {
                return _IdAlmacen;
            }
            set
            {
                SetPropertyValue("IdAlmacen", ref _IdAlmacen, value);
            }
        }

        public TipoDocumentos TipoDocumentos
        {
            get
            {
                return _TipoDocumentos;
            }
            set
            {
                SetPropertyValue("TipoDocumentos", ref _TipoDocumentos, value);
            }
        }

       
        public DateTime fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                SetPropertyValue("fecha", ref _Fecha, value);
            }
        }

       
        public Proveedor Proveedor
        {
            get
            {
                return _Proveedor;
            }
            set
            {
                SetPropertyValue("Proveedor", ref _Proveedor, value);
            }
        }


      
        public string NumeroOrdenFactura
        {
            get
            {
                return _NumeroOrdenFactura;
            }
            set
            {
                SetPropertyValue("NumeroOrdenFactura", ref _NumeroOrdenFactura, value);
            }
        }


       
        public string NumeroDescargo
        {
            get
            {
                return _NumeroDescargo;
            }
            set
            {
                SetPropertyValue("NumeroDescargo", ref _NumeroDescargo, value);
            }
        }



        public int Cantidad
        {
            get
            {
                return _Cantidad;
            }
            set
            {
                SetPropertyValue("Cantidad", ref _Cantidad, value);
            }
        }


        public string UnidadMedida
        {
            get
            {
                return _UnidadMedida;
            }
            set
            {
                SetPropertyValue("UnidadMedida", ref _UnidadMedida, value);
            }
        }

        [RuleRequiredField]
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                SetPropertyValue("Descripcion", ref _Descripcion, value);
            }
        }

        [ModelDefault("EditMask", "#,###,##0.0000")]
        [ModelDefault("DisplayFormat", "#,###,##0.0000")]
        public decimal PrecioUnitario
        {
            get
            {
                return _PrecioUnitario;
            }
            set
            {
                SetPropertyValue("PrecioUnitario", ref _PrecioUnitario, value);
            }
        }


        [ModelDefault("EditMask", "#,###,##0.0000")]
        [ModelDefault("DisplayFormat", "#,###,##0.0000")]
        public decimal Total
        {
            get
            {
                return _Total;
            }
            set
            {
                SetPropertyValue("Total", ref _Total, value);
            }
        }


        [Size(250)]
        public string Motivo
        {
            get
            {
                return _Motivo;
            }
            set
            {
                SetPropertyValue("Motivo", ref _Motivo, value);
            }
        }

    }
}
