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
using TallerMecanico.Module.BusinessObjects;

namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Administracion de Solicitudes")]
    //para hacer fila editable en tab
    [DefaultListViewOptions(true, DevExpress.ExpressApp.NewItemRowPosition.Top)]
    [FriendlyKeyProperty("SolicitudRepuesto")]
    public class SolicitudRepuestos : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public SolicitudRepuestos(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // valor default de campo imprimir
            Imprimir = true;
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...

        private bool _Imprimir;
        private SolicitudReparacion _SolicitudRepuesto;
        private decimal _Total;
        private decimal _PrecioAproximado;
        private string _Detalle;
        private UnidadMedida _UnidadMedida;
        private int _Cantidad;
        private TipoDocumentos _TipoDocumentos;
        private DateTime _FechaSolicitud;



        [ModelDefault("Caption", "Solicitud de Reparacion")]
        [Appearance("SolicitudReadOnly", Enabled = false)]
        [Association("SolicitudReparacion-SolicitudRepuesto")]
        public SolicitudReparacion SolicitudRepuesto
        {
            get
            {
                return _SolicitudRepuesto;
            }
            set
            {
                SetPropertyValue("SolicitudRepuesto", ref _SolicitudRepuesto, value);
            }
        }
    

        [RuleRequiredField]
        public DateTime FechaSolicitud
        {
            get
            {
                return _FechaSolicitud;
            }
            set
            {
                SetPropertyValue("FechaSolicitud", ref _FechaSolicitud, value);
            }
        }


        [DataSourceCriteria("TipoDocumentos > 0")]
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

        [RuleRequiredField]
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

        [RuleRequiredField]
        public UnidadMedida UnidadMedida
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
        public string Detalle
        {
            get
            {
                return _Detalle;
            }
            set
            {
                SetPropertyValue("Detalle", ref _Detalle, value);
            }
        }


        [ModelDefault("EditMask", "#,###,##0.0000")]
        [ModelDefault("DisplayFormat", "#,###,##0.0000")]
        [RuleRequiredField]
        public decimal PrecioAproximado
        {
            get
            {
                return _PrecioAproximado;
            }
            set
            {
                SetPropertyValue("PrecioAproximado", ref _PrecioAproximado, value);
            }
        }


        [ModelDefault("EditMask", "#,###,##0.0000")]
        [ModelDefault("DisplayFormat", "#,###,##0.0000")]
        [Appearance("totalReadOnly", Enabled = false)]
        public decimal Total
        {
            get
            {
                //return _Total;
                decimal _return = 0;

                if (!ReferenceEquals(SolicitudRepuesto, null))
                {
                    _return = Cantidad * PrecioAproximado;
                }
                return _return;
            }
           
        }

        public bool Imprimir
        {
            get
            {
                return _Imprimir;
            }
            set
            {
                SetPropertyValue("Imprimir", ref _Imprimir, value);
            }
        }


        protected override void OnSaving()
        {
           CambiarEstado();
           base.OnSaving();
        }


        private void CambiarEstado()
        {
            if (!ReferenceEquals(this.SolicitudRepuesto, null))
            {
                //int estado = this.DiagnosticoSolicitud.EstadoSolicitud;
               if (this.SolicitudRepuesto.EstadoSolicitud == EstadoSolicitud.DiagnosticoRealizado && this.TipoDocumentos == TipoDocumentos.SolicitudAlmacen)
                {
                    this.SolicitudRepuesto.EstadoSolicitud = EstadoSolicitud.ObtencionAlmacen;
                }
                else if (this.SolicitudRepuesto.EstadoSolicitud == EstadoSolicitud.DiagnosticoRealizado && this.TipoDocumentos == TipoDocumentos.SolicitudCajaChica)
                {
                    this.SolicitudRepuesto.EstadoSolicitud = EstadoSolicitud.ObtencionCajaChica;
                }
                else if (this.SolicitudRepuesto.EstadoSolicitud == EstadoSolicitud.DiagnosticoRealizado && this.TipoDocumentos == TipoDocumentos.SolicitudUACI)
                {
                    this.SolicitudRepuesto.EstadoSolicitud = EstadoSolicitud.ObtencionUACI;
                }
            }
        }

        
    }
}
