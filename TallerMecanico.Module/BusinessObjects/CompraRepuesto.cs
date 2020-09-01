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
using TallerMecanico.Module.BusinessObjects;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Catalogos")]
    [ModelDefault("Caption", "Compra Repuestos")]
    //para hacer fila editable en tab
    [DefaultListViewOptions(true, DevExpress.ExpressApp.NewItemRowPosition.Top)]
    [FriendlyKeyProperty("CompraRepuesto")]
    public class CompraRepuesto : Entidad
            { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public CompraRepuesto(Session session)
            : base(session)
        {
        }

        
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
            if (this.Devuelto != true)
            this.Devuelto = false;
        }


        // Fields...
        // Fields...
        private int _IdAlmacen;
        private bool _Devuelto;
        private string _UnidadMedida;
        private string _NumeroDescargo;
        private decimal _PrecioUnitario;
        private string _Descripcion;
        private int _Cantidad;
        private Proveedor _Proveedor;
        private string _NumeroOrdenFactura;
        private DateTime _Fecha;
        private TipoDocumentos _TipoDocumentos;
        private SolicitudReparacion _CompraRepuestos;

        [Association("SolicitudReparacion-CompraRepuestos")]
        public SolicitudReparacion CompraRepuestos
        {
            get
            {
                return _CompraRepuestos;
            }
            set
            {
                SetPropertyValue("CompraRepuestos", ref _CompraRepuestos, value);
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

        [ImmediatePostData()]
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
       // [Appearance("totalReadOnly", Enabled = false)]
        public decimal Total
        {
            get
            {
                //return _Total;
                decimal _return = 0;

                if (!ReferenceEquals(CompraRepuestos, null))
                {
                    _return = Cantidad * PrecioUnitario;
                }
                return _return;
            }
          
        }


        [Appearance("NoVisible en CurrentUserLoged", Visibility = ViewItemVisibility.Hide, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public bool Devuelto
        {
            get
            {
                return _Devuelto;
            }
            set
            {
                SetPropertyValue("Devuelto", ref _Devuelto, value);
            }
        }




        protected override void OnSaving()
        {
           // CalcularTotal();
            CambiarEstado();
            base.OnSaving();

        }

        //metodo para cambiar estado a solicitud
        private void CambiarEstado()
        {
            if (!ReferenceEquals(this.CompraRepuestos, null))
            {
                if (this.CompraRepuestos.EstadoSolicitud == EstadoSolicitud.ObtencionAlmacen || this.CompraRepuestos.EstadoSolicitud == EstadoSolicitud.ObtencionCajaChica || this.CompraRepuestos.EstadoSolicitud == EstadoSolicitud.ObtencionUACI)
                {

                    this.CompraRepuestos.EstadoSolicitud = EstadoSolicitud.Reparacion;
                   // CompraRepuestos.FechaInicioEjecucion = fecha;
                }
            }
        }

     
    }
}
