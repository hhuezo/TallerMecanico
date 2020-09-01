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
using TallerMecanico.Module.BusinessObjects.Seguridad;
using DevExpress.ExpressApp.ConditionalAppearance;



namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Administracion de Solicitudes")]
    //para hacer fila editable en tab
    [DefaultListViewOptions(true, DevExpress.ExpressApp.NewItemRowPosition.Top)]
    public class SolicitudSalidaVehiculo : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public SolicitudSalidaVehiculo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private DateTime _FechaSalida;
        private string _Observaciones;
        private string _TrabajoRealizado;
        private SolicitudReparacion _SalidaVehiculo;


        [Appearance("SolicitudReadOnly", Enabled = false)]
        [Association("SolicitudReparacion-SalidaVehiculo")]
        public SolicitudReparacion SalidaVehiculo
        {
            get
            {
                return _SalidaVehiculo;
            }
            set
            {
                SetPropertyValue("SalidaVehiculo", ref _SalidaVehiculo, value);
            }
        }



        public DateTime FechaSalida
        {
            get
            {
                return _FechaSalida;
            }
            set
            {
                SetPropertyValue("FechaSalida", ref _FechaSalida, value);
            }
        }


        public string TrabajoRealizado
        {
            get
            {
                return _TrabajoRealizado;
            }
            set
            {
                SetPropertyValue("TrabajoRealizado", ref _TrabajoRealizado, value);
            }
        }

         [Size(250)]
        public string Observaciones
        {
            get
            {
                return _Observaciones;
            }
            set
            {
                SetPropertyValue("Observaciones", ref _Observaciones, value);
            }
        }

         protected override void OnSaving()
         {

             CalculoSalida();
             CambiarEstado();
            // EnviarCorreo();
             base.OnSaving();
         }

         private void CalculoSalida()
         {
             if (!ReferenceEquals(this.SalidaVehiculo, null))
             {

                 if (this.SalidaVehiculo.TipoMantenimiento == TipoMantenimiento.Preventivo || this.SalidaVehiculo.TipoMantenimiento == TipoMantenimiento.Correctivo)
                 {
                     this.SalidaVehiculo.TiempoEjecucionReal = 0;
                    // DateTime fechaInicio = this.SalidaVehiculo.FechaInicioEjecucion;
                     DateTime fechaSalida = this.FechaSalida;
                    // int TiempoEjecucion = (fechaSalida - fechaInicio).Days;
                    // int TiempoEjecucionReal = TiempoEjecucion + 1;
                    // this.SalidaVehiculo.TiempoEjecucionReal = TiempoEjecucionReal;
                     //this.SalidaVehiculo.RendimientoReal = this.SalidaVehiculo.CostoEjecucionReal / TiempoEjecucionReal;
                      // calcular el rendimiento proyectado
                     //int tiempoEjecucionproyectado = this.SalidaVehiculo.TiempoEjecucionPlaneado;
                    // decimal CostoEjecuionPlaneado = this.SalidaVehiculo.CostoEjecucionAproximado;
                     //this.SalidaVehiculo.RendimientoProyectado = CostoEjecuionPlaneado / tiempoEjecucionproyectado;
                 }
               
             }
         }

        
         private void CambiarEstado()
         {

             if (!ReferenceEquals(this.SalidaVehiculo, null))
             {
                 if (this.SalidaVehiculo.EstadoSolicitud == EstadoSolicitud.Reparacion || this.SalidaVehiculo.EstadoSolicitud == EstadoSolicitud.ObtencionUACI || this.SalidaVehiculo.EstadoSolicitud == EstadoSolicitud.ObtencionAlmacen || this.SalidaVehiculo.EstadoSolicitud == EstadoSolicitud.ObtencionCajaChica )
                 {
                     SalidaVehiculo.EstadoSolicitud = EstadoSolicitud.Finalizada;
                     if(this.SalidaVehiculo.TipoMantenimiento == TipoMantenimiento.Preventivo)
                     {
                     this.SalidaVehiculo.Automovil.ContadorKilometraje = this.SalidaVehiculo.Kilometraje;
                     }

                 }
             }
         }


         private void EnviarCorreo()
         {
             if (!ReferenceEquals(this.SalidaVehiculo, null))
             {
                 if (ReferenceEquals(this.SalidaVehiculo.EstadoSolicitud , EstadoSolicitud.Reparacion))
                 {
                     String placa = this.SalidaVehiculo.Automovil.NumeroPlaca;
                     String equipo = this.SalidaVehiculo.Automovil.NumeroEquipo;
                     Int32 NumeroSolicitud = this.SalidaVehiculo.CodSolicitud;
                     String departamento = this.SalidaVehiculo.Automovil.Departamento.NombreDepartamento;
                     String CorreoANotificar = "";

                     if (!ReferenceEquals(this.SalidaVehiculo.UsuarioSolicitante.UsuarioSolicitante, false))
                     {
                         EnviarCorreo EnviarCorreo = new EnviarCorreo();
                         CorreoANotificar = this.SalidaVehiculo.UsuarioSolicitante.CorreoElectronico;
                         string Mensaje = String.Format("Se notifica que la solicitud de reparacion con numero {2}, para el equipo {0} de placa numero {1} asignado a {3} ha finalizado ", equipo, placa, NumeroSolicitud, departamento);
                         EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Notificación de finalizacion de  Solicitud de reparacion de vehiculos");
                     }

                     BinaryOperator CriteriaUsuarioGerente = new BinaryOperator("UsuarioGerente", true);
                     Usuario UsuarioGerente = Session.FindObject<Usuario>(CriteriaUsuarioGerente);
                     if (!ReferenceEquals(UsuarioGerente, null))
                     {
                         EnviarCorreo EnviarCorreo = new EnviarCorreo();
                         CorreoANotificar = UsuarioGerente.CorreoElectronico;
                         string Mensaje = String.Format("Se notifica que la solicitud de reparacion con numero {2}, para el equipo {0} de placa numero {1} asignado a {3} ha finalizado ", equipo, placa, NumeroSolicitud, departamento);
                         EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Notificación de finalizacion de  Solicitud de reparacion de vehiculos");
                     }


                     BinaryOperator CriteriaUsuarioJefeTaller = new BinaryOperator("UsuarioJefeTaller", true);
                     Usuario UsuarioJefeTaller = Session.FindObject<Usuario>(CriteriaUsuarioJefeTaller);
                     if (!ReferenceEquals(UsuarioJefeTaller, null))
                     {
                         EnviarCorreo EnviarCorreo = new EnviarCorreo();
                         CorreoANotificar = UsuarioJefeTaller.CorreoElectronico;
                         string Mensaje = String.Format("Se notifica que la solicitud de reparacion con numero {2}, para el equipo {0} de placa numero {1} asignado a {3} ha finalizado ", equipo, placa, NumeroSolicitud, departamento);
                         EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Notificación de finalizacion de  Solicitud de reparacion de vehiculos");
                     }


                     BinaryOperator CriteriaUsuarioServiciosGenerales = new BinaryOperator("UsuarioServiciosGenerales", true);
                     Usuario UsuarioServiciosGenerales = Session.FindObject<Usuario>(CriteriaUsuarioServiciosGenerales);
                     if (!ReferenceEquals(UsuarioServiciosGenerales, null))
                     {
                         EnviarCorreo EnviarCorreo = new EnviarCorreo();
                         CorreoANotificar = UsuarioServiciosGenerales.CorreoElectronico;
                         string Mensaje = String.Format("Se notifica que la solicitud de reparacion con numero {2}, para el equipo {0} de placa numero {1} asignado a {3} ha finalizado ", equipo, placa, NumeroSolicitud, departamento);
                         EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Notificación de finalizacion de  Solicitud de reparacion de vehiculos");
                     }
                 }
             }


         }
     }
}
