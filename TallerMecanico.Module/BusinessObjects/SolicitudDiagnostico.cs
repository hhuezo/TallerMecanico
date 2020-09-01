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

namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Administracion de Solicitudes")]
    //para hacer fila editable en tab
    [DefaultListViewOptions(true, DevExpress.ExpressApp.NewItemRowPosition.Top)]
    [FriendlyKeyProperty("DiagnosticoSolicitud")]
    public class SolicitudDiagnostico : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public SolicitudDiagnostico(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        private int _TiempoEjecucionPlaneado;
        private string _Diagnostico;
        private TipoMantenimiento _TipoMantenimiento;
        private Mecanico _Mecanico;
        private DateTime _FechaDiagnostico;
        private SolicitudReparacion _DiagnosticoSolicitud;

        [ModelDefault("Caption", "Solicitud de Reparacion")]
        [Appearance("SolicitudReadOnly", Enabled = false)]
        [RuleRequiredField]
        [RuleUniqueValue]
        [Association("SolicitudReparacion-DiagnosticoSolicitud")]
        public SolicitudReparacion DiagnosticoSolicitud
        {
            get
            {
                return _DiagnosticoSolicitud;
            }
            set
            {
                SetPropertyValue("DiagnosticoSolicitud", ref _DiagnosticoSolicitud, value);
            }
        }

        [RuleRequiredField]
        public DateTime FechaDiagnostico
        {
            get
            {
                return _FechaDiagnostico;
            }
            set
            {
                SetPropertyValue("FechaDiagnostico", ref _FechaDiagnostico, value);
            }
        }

        [DataSourceCriteria("Activo=1")]
        [RuleRequiredField]
        public Mecanico Mecanico
        {
            get
            {
                return _Mecanico;
            }
            set
            {
                SetPropertyValue("Mecanico", ref _Mecanico, value);
            }
        }

       
        [RuleRequiredField]
        public TipoMantenimiento TipoMantenimiento
        {
            get
            {
                return _TipoMantenimiento;
            }
            set
            {
                SetPropertyValue("TipoMantenimiento", ref _TipoMantenimiento, value);
            }
        }

        [Size(250)]
        public string Diagnostico
        {
            get
            {
                return _Diagnostico;
            }
            set
            {
                SetPropertyValue("Diagnostico", ref _Diagnostico, value);
            }
        }

        [ModelDefault("Caption", "Tiempo de Ejecucion Estimado(dias)")]
        public int TiempoEjecucionPlaneado
        {
            get
            {
                return _TiempoEjecucionPlaneado;
            }
            set
            {
                SetPropertyValue("TiempoEjecucionPlaneado", ref _TiempoEjecucionPlaneado, value);
            }
        }

        protected override void OnSaving()
        {
            Mantenimiento();
            CambiarEstado();
            base.OnSaving();

        }


        private void Mantenimiento()
        {
            if (!ReferenceEquals(this.DiagnosticoSolicitud, null))
            {
                DiagnosticoSolicitud.TipoMantenimiento = this.TipoMantenimiento;
            }
        }





        private void CambiarEstado()
        {
            if (!ReferenceEquals(this.DiagnosticoSolicitud, null))
            {                
                if (DiagnosticoSolicitud.EstadoSolicitud == EstadoSolicitud.Autorizada)

                {
                    if (this.TipoMantenimiento != TipoMantenimiento.Servicio)
                    {
                        DiagnosticoSolicitud.EstadoSolicitud = EstadoSolicitud.DiagnosticoRealizado;      
                    }
                    else 
                    {
                        DiagnosticoSolicitud.EstadoSolicitud = EstadoSolicitud.Reparacion;      
                    }
                }
               

                if (this.TipoMantenimiento == TipoMantenimiento.Servicio)
                {
                    //this.DiagnosticoSolicitud.FechaInicioEjecucion = this.FechaDiagnostico;
                    //this.DiagnosticoSolicitud.CostoEjecucionAproximado = 0;
                    //this.DiagnosticoSolicitud.CostoEjecucionReal = 0;
                    //this.DiagnosticoSolicitud.TiempoEjecucionReal = 0;
                    //this.DiagnosticoSolicitud.RendimientoProyectado = 0;
                    //this.DiagnosticoSolicitud.RendimientoReal = 0;      
                }
                else if (TipoMantenimiento == TipoMantenimiento.Preventivo || TipoMantenimiento == TipoMantenimiento.Correctivo)
               {                   
                  // this.DiagnosticoSolicitud.FechaInicioEjecucion = this.FechaDiagnostico;
               }

                //this.DiagnosticoSolicitud.TiempoEjecucionPlaneado = this.TiempoEjecucionPlaneado;
            }

        }

    }
}
