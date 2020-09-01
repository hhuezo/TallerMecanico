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
using TallerMecanico.Module.BusinessObjects.Configuracion;
using DevExpress.ExpressApp.Editors;
using TallerMecanico.Module.BusinessObjects.Catalogos;
using TallerMecanico.Module.BusinessObjects.Seguridad;
using Presupuesto.Module.BusinessObjects.Configuracion;


namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Administracion de Solicitudes")]
    [RequiereInicializacionGeneradorDeCodigos("Solicitud")]
    [ModelDefault("Caption", "Solicitud de Taller")]
    [FriendlyKeyProperty("CodSolicitud")]
    public class SolicitudReparacion : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public SolicitudReparacion(Session session)
            : base(session)
        {
        }

        [Appearance("UsuarioSolicitante", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        public Usuario UsuarioSolicitante
        {
            get
            {
                return _UsuarioSolicitante;
            }
            set
            {
                SetPropertyValue("UsuarioSolicitante", ref _UsuarioSolicitante, value);
            }
        }

        [NonPersistent]
        [Appearance("NoVisible en CurrentUserLoged", Visibility = ViewItemVisibility.Hide)]
        public Usuario CurrentUserLoged
        {
            get
            {
                if (!ReferenceEquals(SecuritySystem.CurrentUserId, null))
                {
                    BinaryOperator Criteria = new BinaryOperator("Oid", (Guid)SecuritySystem.CurrentUserId, BinaryOperatorType.Equal);
                    Usuario CurrentUser = this.Session.FindObject<Usuario>(Criteria);
                    return CurrentUser;
                }
                else
                {
                    return null;
                }

            }
        }

    
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            BinaryOperator Criteria = new BinaryOperator("Oid", (Guid)SecuritySystem.CurrentUserId, BinaryOperatorType.Equal);
            this.UsuarioSolicitante = this.Session.FindObject<Usuario>(Criteria);
            if (!ReferenceEquals(this.UsuarioSolicitante, null))
            {
                this.UsuarioSolicitante = UsuarioSolicitante;
            }
        }

        // Fields...
        private decimal _CostoEjecucionAproximado;
        private string _TrabajoRealizado;
        private int _NumDevolucion;
        private SolicitudDevolucionRepuesto _DevolucionRepuesto;
        private Departamento _Departamento;
        private string _Placa;
        private string _Equipo;
        private TipoSolicitud _TipoSolicitud;
        private string _Observacion;
        private TipoMantenimiento _TipoMantenimiento;
        private DateTime _FechaInicioEjecucion;
        private Usuario _UsuarioSolicitante;
        private decimal _RendimientoReal;
        private decimal _RendimientoProyectado;
        private int _TiempoEjecucionPlaneado;
        private int _TiempoEjecucionReal;
        private decimal _CostoEjecucionReal;
        private EstadoSolicitud _EstadoSolicitud;
        private ReporteFalla _ReporteFalla;
        private int _Kilometraje;
        private Automovil _Automovil;
        private DateTime _FechaEntrada;
        private int _CodSolicitud;

        [ModelDefault("Caption", "Codigo Solicitud")]
        [Appearance("CodSolicitud", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        [RuleUniqueValue]
        public int CodSolicitud
        {
            get
            {
                return _CodSolicitud;
            }
            set
            {
                SetPropertyValue("CodSolicitud", ref _CodSolicitud, value);
            }
        }

        [Appearance("TipoSolicitud", Visibility = ViewItemVisibility.Hide, Criteria = "(CurrentUserLoged.UsuarioSolicitante = true)")]
        public TipoSolicitud TipoSolicitud
        {
            get
            {
                return _TipoSolicitud;
            }
            set
            {
                SetPropertyValue("TipoSolicitud", ref _TipoSolicitud, value);
            }
        }

        [RuleRequiredField]
        public DateTime FechaEntrada
        {
            get
            {
                if (CodSolicitud == 0)
                {
                    _FechaEntrada = DateTime.Now;
                }
                return _FechaEntrada;
            }
            set
            {
                SetPropertyValue("FechaEntrada", ref _FechaEntrada, value);
            }
        }

        [ImmediatePostData]
        [RuleRequiredField]
        public Automovil Automovil
        {
            get
            {
                return _Automovil;
            }
            set
            {
                SetPropertyValue("Automovil", ref _Automovil, value);
            }
        }

        //[Appearance("NoVisible Equipo", Visibility = ViewItemVisibility.Hide, Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        [Appearance("Equipo", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        public string Equipo
        {
            get
            {
                if (!ReferenceEquals(Automovil, null) && ReferenceEquals(_Equipo, null))
                {
                    _Equipo = Automovil.NumeroEquipo;
                }
                return _Equipo;
            }
            set
            {
                SetPropertyValue("Equipo", ref _Equipo, value);
            }
        }

        [Appearance("Placa", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        public string Placa
        {
            get
            {
                if (!ReferenceEquals(Automovil, null) && ReferenceEquals(_Placa, null))
                {
                    _Placa = Automovil.NumeroPlaca;
                }
                return _Placa;
            }
            set
            {
                SetPropertyValue("Placa", ref _Placa, value);
            }
        }


        public int Kilometraje
        {
            get
            {
                return _Kilometraje;
            }
            set
            {
                SetPropertyValue("Kilometraje", ref _Kilometraje, value);
            }
        }

        [RuleRequiredField]
        public ReporteFalla ReporteFalla
        {
            get
            {
                return _ReporteFalla;
            }
            set
            {
                SetPropertyValue("ReporteFalla", ref _ReporteFalla, value);
            }
        }

        [Appearance("EstadoSolicitud", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        public EstadoSolicitud EstadoSolicitud
        {
            get
            {
                return _EstadoSolicitud;
            }
            set
            {
                SetPropertyValue("EstadoSolicitud", ref _EstadoSolicitud, value);
            }
        }



        [Appearance("TipoMantenimiento", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
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

        [Appearance("ObservacionEnable", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioSolicitante = true)")]
        public string Observacion
        {
            get
            {
                return _Observacion;
            }
            set
            {
                SetPropertyValue("Observacion", ref _Observacion, value);
            }
        }



        [Appearance("Departamento", Enabled = false, Criteria = "!IsCurrentUserInRole('Administrators')")]
        public Departamento Departamento
        {
            get
            {
                if (!ReferenceEquals(UsuarioSolicitante, null) && CodSolicitud == 0)
                {
                    _Departamento = UsuarioSolicitante.Departamento;
                }
                return _Departamento;
            }
            set
            {
                SetPropertyValue("Departamento", ref _Departamento, value);
            }
        }




        [Appearance("NumDevolucion", Visibility = ViewItemVisibility.Hide, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        public int NumDevolucion
        {
            get
            {
                return _NumDevolucion;
            }
            set
            {
                SetPropertyValue("NumDevolucion", ref _NumDevolucion, value);
            }
        }



         [Appearance("CostoEjecucionAproximado", Visibility = ViewItemVisibility.Hide)]
        public decimal CostoEjecucionAproximado
        {
            get
            {
                return _CostoEjecucionAproximado;
            }
            set
            {
                SetPropertyValue("CostoEjecucionAproximado", ref _CostoEjecucionAproximado, value);
            }
        }


        //[Appearance("CostoEjecucionReal", Visibility = ViewItemVisibility.Hide, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        [Appearance("CostoEjecucionReal", Visibility = ViewItemVisibility.Hide)]
        public decimal CostoEjecucionReal
        {
            get
            {
               return _CostoEjecucionReal;
               // return ActualizarCostoReal();
            }
            set
            {
                SetPropertyValue("CostoEjecucionReal", ref _CostoEjecucionReal, value);
            }
        }

        //[Appearance("TiempoEjecucionReal", Visibility = ViewItemVisibility.Hide, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        [Appearance("TiempoEjecucionReal", Visibility = ViewItemVisibility.Hide)]
        public int TiempoEjecucionReal
        {
            get
            {
                return _TiempoEjecucionReal;
            }
            set
            {
                SetPropertyValue("TiempoEjecucionReal", ref _TiempoEjecucionReal, value);
            }
        }



       // [Appearance("RendimientoReal", Visibility = ViewItemVisibility.Hide, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        [Appearance("RendimientoReal", Visibility = ViewItemVisibility.Hide)]
        public decimal RendimientoReal
        {
            get
            {
                return _RendimientoReal;
            }
            set
            {
                SetPropertyValue("RendimientoReal", ref _RendimientoReal, value);
            }
        }

        [Appearance("TrabajoRealizado", Visibility = ViewItemVisibility.Hide)]
        [Size(600)]
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



        [Appearance("SolicitudCondicionAutomovilReadonly", Enabled = false, Criteria = "(EstadoSolicitud!= 0) and (CurrentUserLoged.UsuarioAdministrador != true)")]
        [Association("SolicitudReparacion-CondicionAutomovil")]
        public XPCollection<SolicitudCondicionVehiculo> CondicionAutomovil
        {
            get
            {
                return GetCollection<SolicitudCondicionVehiculo>("CondicionAutomovil");
            }
        }

       
        [Appearance("SolicitudDiagnosticoReadonly", Enabled = false, Criteria = "(EstadoSolicitud!=3) and (CurrentUserLoged.UsuarioAdministrador != true)  and (CurrentUserLoged.UsuarioJefeTaller != true)")]
        [Association("SolicitudReparacion-DiagnosticoSolicitud")]
        public XPCollection<SolicitudDiagnostico> DiagnosticoSolicitud
        {
            get
            {
                return GetCollection<SolicitudDiagnostico>("DiagnosticoSolicitud");
            }
        }

        [Appearance("SolicitudRepuesto", Enabled = false, Criteria = "(EstadoSolicitud =0 or EstadoSolicitud =1 or EstadoSolicitud =2 or EstadoSolicitud =3 or EstadoSolicitud =8 or EstadoSolicitud =9 or EstadoSolicitud =10) and (CurrentUserLoged.UsuarioAdministrador != true)  and (CurrentUserLoged.UsuarioJefeTaller != true)")]
        [Association("SolicitudReparacion-SolicitudRepuesto")]
        public XPCollection<SolicitudRepuestos> SolicitudRepuesto
        {
            get
            {
                return GetCollection<SolicitudRepuestos>("SolicitudRepuesto");
            }
        }

        [Appearance("CompraRepuestos", Enabled = false, Criteria = "(EstadoSolicitud=0 or EstadoSolicitud=1 or EstadoSolicitud=2 or EstadoSolicitud=3 or EstadoSolicitud=4 or EstadoSolicitud= 9  or EstadoSolicitud=10) and (CurrentUserLoged.UsuarioAdministrador != true)")]
        [Association("SolicitudReparacion-CompraRepuestos")]
        public XPCollection<CompraRepuesto> CompraRepuestos
        {
            get
            {
                return GetCollection<CompraRepuesto>("CompraRepuestos");
            }
        }

        [Appearance("SalidaVehiculo", Enabled = false, Criteria = "(EstadoSolicitud=0 or EstadoSolicitud=1 or EstadoSolicitud=2 or EstadoSolicitud=3 or EstadoSolicitud=4 or EstadoSolicitud=5 or EstadoSolicitud=6  or EstadoSolicitud=7   or EstadoSolicitud=10) and (CurrentUserLoged.UsuarioAdministrador != true)and (CurrentUserLoged.UsuarioJefeTaller != true)")]
        [Association("SolicitudReparacion-SalidaVehiculo")]
        public XPCollection<SolicitudSalidaVehiculo> SalidaVehiculo
        {
            get
            {
                return GetCollection<SolicitudSalidaVehiculo>("SalidaVehiculo");
            }
        }


        [ModelDefault("Caption", "Devolucion Repuestos")]
       // [Appearance("SolicitudDevolucionRepuesto2", Visibility = ViewItemVisibility.Hide, Criteria = "(CurrentUserLoged.UsuarioSolicitante = true)")]
        [Appearance("SolicitudDevolucionRepuesto", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        //[Appearance("SolicitudDevolucionRepuesto2", Visibility = ViewItemVisibility.Hide, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        [Association("SolicitudReparacion-SolicitudDevolucionRepuesto")]
        public XPCollection<SolicitudDevolucionRepuesto> SolicitudDevolucionRepuesto
        {
            get
            {
                return GetCollection<SolicitudDevolucionRepuesto>("SolicitudDevolucionRepuesto");
            }
        }



        [Appearance("Programacion", Enabled = false, Criteria = "(EstadoSolicitud=0 or EstadoSolicitud=1 or EstadoSolicitud=2 or EstadoSolicitud=3 or EstadoSolicitud=4) and (CurrentUserLoged.UsuarioAdministrador != true)and (CurrentUserLoged.UsuarioJefeTaller != true)")]
        [Association("SolicitudReparacion-Programacion")]
        public XPCollection<ProgramacionReparacion> Programacion
        {
            get
            {
                return GetCollection<ProgramacionReparacion>("Programacion");
            }
        }




        protected override void OnSaving()
        {
            if (TipoSolicitud == BusinessObjects.TipoSolicitud.SolicitudLubricantes)
            {
                this.EstadoSolicitud = BusinessObjects.EstadoSolicitud.Finalizada;
            }
            
             if (CodSolicitud == 0)
            {
                RequiereInicializacionGeneradorDeCodigos NombreDeSecuencia = this.ClassInfo.FindAttributeInfo(typeof(RequiereInicializacionGeneradorDeCodigos)) as RequiereInicializacionGeneradorDeCodigos;
                if (!ReferenceEquals(NombreDeSecuencia, null))
                    CodSolicitud = Secuencias.GetNextValue(this.Session.DataLayer, NombreDeSecuencia.id);


                this.Equipo = Automovil.NumeroEquipo;
                this.Placa = Automovil.NumeroPlaca;
            }

             
             if (!ReferenceEquals(UsuarioCreador, null))
             {
                 UsuarioCreador = CurrentUserLoged.UserName;
                 FechaDeIngreso = DateTime.Now;
             }
        } 
    }
}
