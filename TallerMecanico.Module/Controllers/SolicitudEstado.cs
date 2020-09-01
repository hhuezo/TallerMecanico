using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using TallerMecanico.Module.BusinessObjects;

namespace TallerMecanico.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class SolicitudEstado : ViewController
    {
        public SolicitudEstado()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void EnviarSolicitud_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            SolicitudReparacion SolicitudActual = (SolicitudReparacion)e.CurrentObject;
            int Estado = 0;
            Estado = Convert.ToInt32(SolicitudActual.EstadoSolicitud);

            if (SolicitudActual.Automovil.Departamento == SolicitudActual.CurrentUserLoged.Departamento)
            {
                SolicitudActual.EstadoSolicitud = EstadoSolicitud.Enviada;


                if (this.View.ObjectSpace.IsModified)
                {
                    this.View.ObjectSpace.CommitChanges();
                    this.View.Refresh();
                }
            }
        }

        private void AutorizarSolicitud_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            SolicitudReparacion SolicitudActual = (SolicitudReparacion)e.CurrentObject;
            int Estado = 0;
            Estado = Convert.ToInt32(SolicitudActual.EstadoSolicitud);

            if (Estado == 2)
            {
                SolicitudActual.EstadoSolicitud = EstadoSolicitud.Autorizada;

            }

            if (this.View.ObjectSpace.IsModified)
            {
                this.View.ObjectSpace.CommitChanges();
                this.View.Refresh();
            }
        }

        private void FinalizarSolicitud_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
             SolicitudReparacion SolicitudActual = (SolicitudReparacion)e.CurrentObject;
            int Estado = 0;
            Estado = Convert.ToInt32(SolicitudActual.EstadoSolicitud);

            SolicitudActual.EstadoSolicitud = EstadoSolicitud.Anulada;
            
            if (this.View.ObjectSpace.IsModified)
            {
                this.View.ObjectSpace.CommitChanges();
                this.View.Refresh();
            }
        }

        private void btnFinalizar_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            SolicitudReparacion objCurrent = (SolicitudReparacion)e.CurrentObject;
            while (!ReferenceEquals(objCurrent.EstadoSolicitud, EstadoSolicitud.NoAplica))
            {

                if (!ReferenceEquals(objCurrent, null))
                {

                    SolicitudDiagnostico Diagnostico = (SolicitudDiagnostico)e.CurrentObject;
                    SolicitudSalidaVehiculo SalidaVehiculo = (SolicitudSalidaVehiculo)e.CurrentObject;

                    if (objCurrent.EstadoSolicitud != EstadoSolicitud.NoAplica)
                    {
                        if (!ReferenceEquals(objCurrent.DiagnosticoSolicitud, null))
                        {
                            if (Diagnostico.TipoMantenimiento != TipoMantenimiento.Servicio && ReferenceEquals(Diagnostico.DiagnosticoSolicitud, objCurrent.Oid))
                            {
                                if (!ReferenceEquals(SalidaVehiculo, null) && ReferenceEquals(SalidaVehiculo.SalidaVehiculo, objCurrent.Oid))
                                {

                                   // DateTime fechaInicio = objCurrent.FechaInicioEjecucion;
                                    //DateTime fechaSalida = objCurrent.FechaInicioEjecucion;
                                    //int TiempoEjecucion = (fechaSalida - fechaInicio).Days;
                                    //int TiempoEjecucionReal = TiempoEjecucion + 1;
                                    //objCurrent.TiempoEjecucionReal = TiempoEjecucionReal;
                                    //objCurrent.RendimientoReal = objCurrent.CostoEjecucionReal / TiempoEjecucionReal;

                                    // calcular el rendimiento proyectado
                                    //int tiempoEjecucionproyectado = objCurrent.TiempoEjecucionPlaneado;
                                    //decimal CostoEjecuionPlaneado = objCurrent.CostoEjecucionAproximado;
                                    //objCurrent.RendimientoProyectado = CostoEjecuionPlaneado / tiempoEjecucionproyectado;

                                    objCurrent.EstadoSolicitud = EstadoSolicitud.Finalizada;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}

