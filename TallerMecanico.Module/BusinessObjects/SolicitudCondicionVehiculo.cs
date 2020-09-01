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
using TallerMecanico.Module.BusinessObjects.Seguridad;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Administracion de Solicitudes")]
    [FriendlyKeyProperty("Administracion de Solicitudes")]
    public class SolicitudCondicionVehiculo : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public SolicitudCondicionVehiculo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        private SolicitudReparacion _CondicionAutomovil;
        private NivelCombustible _NivelCombustible;
        private bool _CinturonSeguridad;
        private bool _Extintor;
        private bool _Parabrisa;
        private bool _DefensaTrasera;
        private bool _DefensaDelantera;
        private bool _Escobilla;
        private bool _Cono;
        private bool _Triangulo;
        private bool _LlaveL;
        private bool _LlaveCruz;
        private bool _Mica;
        private bool _Antena;
        private bool _LlantaRepuesto;
        private bool _BomperTrasero;
        private bool _BomperDelantero;
        private bool _TarjetaCirulacion;
        private bool _LlavesEncendido;
        private bool _StopIzquierdo;
        private bool _StopDerecho;
        private bool _Bateria;
        private bool _SealBeanIzquierdo;
        private bool _SealBeanDerecho;
        private bool _TaponConbustible;
        private bool _ViaTraseraIzquierda;
        private bool _ViaTraseraDerecha;
        private bool _ViaDelanteraIzquierda;
        private bool _ViaDelateraDerecha;
        private bool _EspejoDerecho;
        private bool _EspejoIzquierdo;
        private bool _EspejoInterior;


        [Appearance("SolicitudReadOnly", Enabled = false)]
        [Association("SolicitudReparacion-CondicionAutomovil")]
        public SolicitudReparacion CondicionAutomovil
        {
            get
            {
                return _CondicionAutomovil;
            }
            set
            {
                SetPropertyValue("CondicionAutomovil", ref _CondicionAutomovil, value);
            }
        }

        public NivelCombustible NivelCombustible
        {
            get
            {
                return _NivelCombustible;
            }
            set
            {
                SetPropertyValue("NivelCombustible", ref _NivelCombustible, value);
            }
        }

        public bool EspejoInterior
        {
            get
            {
                return _EspejoInterior;
            }
            set
            {
                SetPropertyValue("EspejoInterior", ref _EspejoInterior, value);
            }
        }


        public bool EspejoIzquierdo
        {
            get
            {
                return _EspejoIzquierdo;
            }
            set
            {
                SetPropertyValue("EspejoIzquierdo", ref _EspejoIzquierdo, value);
            }
        }


        public bool EspejoDerecho
        {
            get
            {
                return _EspejoDerecho;
            }
            set
            {
                SetPropertyValue("EspejoDerecho", ref _EspejoDerecho, value);
            }
        }


        public bool ViaDelateraDerecha
        {
            get
            {
                return _ViaDelateraDerecha;
            }
            set
            {
                SetPropertyValue("ViaDelateraDerecha", ref _ViaDelateraDerecha, value);
            }
        }



        public bool ViaDelanteraIzquierda
        {
            get
            {
                return _ViaDelanteraIzquierda;
            }
            set
            {
                SetPropertyValue("ViaDelanteraIzquierda", ref _ViaDelanteraIzquierda, value);
            }
        }


        public bool ViaTraseraDerecha
        {
            get
            {
                return _ViaTraseraDerecha;
            }
            set
            {
                SetPropertyValue("ViaTraseraDerecha", ref _ViaTraseraDerecha, value);
            }
        }



        public bool ViaTraseraIzquierda
        {
            get
            {
                return _ViaTraseraIzquierda;
            }
            set
            {
                SetPropertyValue("ViaTraseraIzquierda", ref _ViaTraseraIzquierda, value);
            }
        }



        public bool TaponConbustible
        {
            get
            {
                return _TaponConbustible;
            }
            set
            {
                SetPropertyValue("TaponConbustible", ref _TaponConbustible, value);
            }
        }


        public bool SealBeanDerecho
        {
            get
            {
                return _SealBeanDerecho;
            }
            set
            {
                SetPropertyValue("SealBeanDerecho", ref _SealBeanDerecho, value);
            }
        }


        public bool SealBeanIzquierdo
        {
            get
            {
                return _SealBeanIzquierdo;
            }
            set
            {
                SetPropertyValue("SealBeanIzquierdo", ref _SealBeanIzquierdo, value);
            }
        }


        public bool Bateria
        {
            get
            {
                return _Bateria;
            }
            set
            {
                SetPropertyValue("Bateria", ref _Bateria, value);
            }
        }



        public bool StopDerecho
        {
            get
            {
                return _StopDerecho;
            }
            set
            {
                SetPropertyValue("StopDerecho", ref _StopDerecho, value);
            }
        }


        public bool StopIzquierdo
        {
            get
            {
                return _StopIzquierdo;
            }
            set
            {
                SetPropertyValue("StopIzquierdo", ref _StopIzquierdo, value);
            }
        }


        public bool LlavesEncendido
        {
            get
            {
                return _LlavesEncendido;
            }
            set
            {
                SetPropertyValue("LlavesEncendido", ref _LlavesEncendido, value);
            }
        }


        public bool TarjetaCirulacion
        {
            get
            {
                return _TarjetaCirulacion;
            }
            set
            {
                SetPropertyValue("TarjetaCirulacion", ref _TarjetaCirulacion, value);
            }
        }


        public bool BomperDelantero
        {
            get
            {
                return _BomperDelantero;
            }
            set
            {
                SetPropertyValue("BomperDelantero", ref _BomperDelantero, value);
            }
        }



        public bool BomperTrasero
        {
            get
            {
                return _BomperTrasero;
            }
            set
            {
                SetPropertyValue("BomperTrasero", ref _BomperTrasero, value);
            }
        }



        public bool LlantaRepuesto
        {
            get
            {
                return _LlantaRepuesto;
            }
            set
            {
                SetPropertyValue("LlantaRepuesto", ref _LlantaRepuesto, value);
            }
        }


        public bool Antena
        {
            get
            {
                return _Antena;
            }
            set
            {
                SetPropertyValue("Antena", ref _Antena, value);
            }
        }


        public bool Mica
        {
            get
            {
                return _Mica;
            }
            set
            {
                SetPropertyValue("Mica", ref _Mica, value);
            }
        }



        public bool LlaveCruz
        {
            get
            {
                return _LlaveCruz;
            }
            set
            {
                SetPropertyValue("LlaveCruz", ref _LlaveCruz, value);
            }
        }


        public bool LlaveL
        {
            get
            {
                return _LlaveL;
            }
            set
            {
                SetPropertyValue("LlaveL", ref _LlaveL, value);
            }
        }


        public bool Triangulo
        {
            get
            {
                return _Triangulo;
            }
            set
            {
                SetPropertyValue("Triangulo", ref _Triangulo, value);
            }
        }



        public bool Cono
        {
            get
            {
                return _Cono;
            }
            set
            {
                SetPropertyValue("Cono", ref _Cono, value);
            }
        }


        public bool Escobilla
        {
            get
            {
                return _Escobilla;
            }
            set
            {
                SetPropertyValue("Escobilla", ref _Escobilla, value);
            }
        }



        public bool DefensaDelantera
        {
            get
            {
                return _DefensaDelantera;
            }
            set
            {
                SetPropertyValue("DefensaDelantera", ref _DefensaDelantera, value);
            }
        }



        public bool DefensaTrasera
        {
            get
            {
                return _DefensaTrasera;
            }
            set
            {
                SetPropertyValue("DefensaTrasera", ref _DefensaTrasera, value);
            }
        }



        public bool Parabrisa
        {
            get
            {
                return _Parabrisa;
            }
            set
            {
                SetPropertyValue("Parabrisa", ref _Parabrisa, value);
            }
        }


        public bool Extintor
        {
            get
            {
                return _Extintor;
            }
            set
            {
                SetPropertyValue("Extintor", ref _Extintor, value);
            }
        }



        public bool CinturonSeguridad
        {
            get
            {
                return _CinturonSeguridad;
            }
            set
            {
                SetPropertyValue("CinturonSeguridad", ref _CinturonSeguridad, value);
            }
        }

      protected override void OnSaving()
        {
            if (!ReferenceEquals(CondicionAutomovil, null))
            {

                //if (this.CondicionAutomovil.EstadoSolicitud == EstadoSolicitud.NoAplica)
                //{
                //    EnviarCorreo();

                //}
            
            CambiarEstado();
            GuardarDetalle();
            base.OnSaving();
            }
        }


        private void CambiarEstado()
        {
            
            if (!ReferenceEquals(this.CondicionAutomovil, null))
            {
                if (this.CondicionAutomovil.EstadoSolicitud == EstadoSolicitud.NoAplica)
                this.CondicionAutomovil.EstadoSolicitud = EstadoSolicitud.Ingresada;
            }

        }

        private void GuardarDetalle()
        {
            EspejoInterior = this.EspejoInterior; 
        
        
        }








       private void EnviarCorreo()
        {
            if (!ReferenceEquals(this.CondicionAutomovil, null))
            {
                String placa = this.CondicionAutomovil.Automovil.NumeroPlaca;
                String equipo = this.CondicionAutomovil.Automovil.NumeroEquipo;
                Int32 NumeroSolicitud = this.CondicionAutomovil.CodSolicitud;
                String Departamento = this.CondicionAutomovil.Automovil.Departamento.NombreDepartamento;
                String CorreoANotificar = "";

                if (!ReferenceEquals(this.CondicionAutomovil.UsuarioSolicitante.UsuarioSolicitante, false))
                {
                    EnviarCorreo EnviarCorreo = new EnviarCorreo();
                    CorreoANotificar = this.CondicionAutomovil.UsuarioSolicitante.CorreoElectronico;
                    string Mensaje = String.Format("Se notifica que hay una nueva solicitud de trabajo para vehículos con número {2}, para el equipo {0} con número de placa {1} asignado a la {3}. ", equipo, placa, NumeroSolicitud, Departamento);
                    EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Notificación de nueva Solicitud de reparacion de vehiculos");
                }

                BinaryOperator CriteriaUsuarioGerente = new BinaryOperator("UsuarioGerente", true);
                Usuario UsuarioGerente = Session.FindObject<Usuario>(CriteriaUsuarioGerente);
                if (!ReferenceEquals(UsuarioGerente, null))
                {
                    EnviarCorreo EnviarCorreo = new EnviarCorreo();
                    CorreoANotificar = UsuarioGerente.CorreoElectronico;
                    string Mensaje = String.Format("Se notifica que hay una nueva solicitud de trabajo para vehículos con número {2}, para el equipo {0} con número de placa {1} asignado a la {3}. ", equipo, placa, NumeroSolicitud, Departamento);
                    //EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Notificación de nueva Solicitud de reparacion de vehiculos");
                }


                BinaryOperator CriteriaUsuarioJefeTaller = new BinaryOperator("UsuarioJefeTaller", true);
                Usuario UsuarioJefeTaller = Session.FindObject<Usuario>(CriteriaUsuarioJefeTaller);
                if (!ReferenceEquals(UsuarioJefeTaller, null))
                {
                    EnviarCorreo EnviarCorreo = new EnviarCorreo();
                    CorreoANotificar = UsuarioJefeTaller.CorreoElectronico;
                    string Mensaje = String.Format("Se notifica que hay una nueva solicitud de trabajo para vehículos con número {2}, para el equipo {0} con número de placa {1} asignado a la {3}. ", equipo, placa, NumeroSolicitud, Departamento);
                    //EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Notificación de nueva Solicitud de reparacion de vehiculos");
                }


                BinaryOperator CriteriaUsuarioServiciosGenerales = new BinaryOperator("UsuarioServiciosGenerales", true);
                Usuario UsuarioServiciosGenerales = Session.FindObject<Usuario>(CriteriaUsuarioServiciosGenerales);
                if (!ReferenceEquals(UsuarioServiciosGenerales, null))
                {
                    EnviarCorreo EnviarCorreo = new EnviarCorreo();
                    CorreoANotificar = UsuarioServiciosGenerales.CorreoElectronico;
                    string Mensaje = String.Format("Se notifica que hay una nueva solicitud de trabajo para vehículos con número {2}, para el equipo {0} con número de placa {1} asignado a la {3}. ", equipo, placa, NumeroSolicitud, Departamento);
                    //EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Notificación de nueva Solicitud de reparacion de vehiculos");
                }
                                
            }
           
        }
    


    }
}
