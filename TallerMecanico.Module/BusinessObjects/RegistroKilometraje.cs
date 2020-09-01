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
using TallerMecanico.Module.BusinessObjects.Catalogos;
using TallerMecanico.Module.BusinessObjects.Seguridad;

namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ModelDefault("Caption", "Registro de Kilometrajes")]
    [NavigationItem("Registro de Kilometrajes")]
       public class RegistroKilometraje : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public RegistroKilometraje(Session session)
            : base(session)
        {
        }

        [Appearance("UsuarioSolicitante", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        public Usuario UsuarioRegistro
        {
            get
            {
                return _UsuarioRegistro;
            }
            set
            {
                SetPropertyValue("UsuarioRegistro", ref _UsuarioRegistro, value);
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
            this.UsuarioRegistro = this.Session.FindObject<Usuario>(Criteria);

            if (!ReferenceEquals(this.UsuarioRegistro, null))
            {
                this.UsuarioRegistro = UsuarioRegistro;
            }
        }
        private int _Kilometraje;
        private Automovil _Automovil;
        private DateTime _FechaRegistro;
        private Usuario _UsuarioRegistro;


        public DateTime FechaRegistro
        {
            get
            {
                return _FechaRegistro;
            }
            set
            {
                SetPropertyValue("FechaRegistro", ref _FechaRegistro, value);
            }
        }



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



        protected override void OnSaving()
        {
            CalcularKilometraje();
            base.OnSaving();

        }

        private void CalcularKilometraje()
        {

            if (!ReferenceEquals(this.FechaRegistro, null))
            {
                //this.FechaRegistro = DateTime.Now;
                this.Automovil.KilometrajeActual = this.Kilometraje;

                if (ReferenceEquals(this.Automovil.ContadorKilometraje, null))
                {
                    this.Automovil.ContadorKilometraje = this.Kilometraje;
                }
                else
                {
                    Int32 Contador = 0;
                    Int32 Kilometraje = this.Kilometraje;
                    Int32 ContadorKilometraje = this.Automovil.ContadorKilometraje;
                    Contador = Kilometraje - ContadorKilometraje;

                    bool km = false;
                    km = this.Automovil.Preventivo5000km;

                    if (Contador > 5000 && this.Automovil.Preventivo5000km == true)
                    {

                        String placa = this.Automovil.NumeroPlaca;
                        String equipo = this.Automovil.NumeroEquipo;
                        String Deparatamento = this.Automovil.Departamento.NombreDepartamento;
                        String CorreoANotificar = "";

                        if (!ReferenceEquals(this.UsuarioRegistro.UsuarioSolicitante, false))
                        {
                            EnviarCorreo EnviarCorreo = new EnviarCorreo();
                            CorreoANotificar = this.UsuarioRegistro.CorreoElectronico;
                            string Mensaje = String.Format("Se notifica que el equipo {0} con número de placa {1} asignado a {2}, requiere de mantenimiento preventivo. Por favor ingresarlo al Taller a más tardar 4 días hábiles después de recibido este aviso Nota: En caso de no ingresar al Taller el vehículo en el tiempo indicado la Unidad de Transporte y Taller no se hace responsable de las fallas que un vehículo pueda presentar relacionadas con la falta de mantenimiento preventivo.", equipo, placa, Deparatamento);
                            EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Mantenimiento Preventivo");
                        }

                        //BinaryOperator CriteriaUsuarioGerente = new BinaryOperator("UsuarioGerente", true);
                        //Usuario UsuarioGerente = Session.FindObject<Usuario>(CriteriaUsuarioGerente);
                        //if (!ReferenceEquals(UsuarioGerente, null))
                        //{
                        //    EnviarCorreo EnviarCorreo = new EnviarCorreo();
                        //    CorreoANotificar = UsuarioGerente.CorreoElectronico;
                        //    string Mensaje = String.Format("Se notifica que el equipo {0} con número de placa {1} asignado a {2}, requiere de mantenimiento preventivo. Por favor ingresarlo al Taller a más tardar 4 días hábiles después de recibido este aviso Nota: En caso de no ingresar al Taller el vehículo en el tiempo indicado la Unidad de Transporte y Taller no se hace responsable de las fallas que un vehículo pueda presentar relacionadas con la falta de mantenimiento preventivo.", equipo, placa, Deparatamento);
                        //    EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Mantenimiento Preventivo");
                        //}

                        BinaryOperator CriteriaUsuarioJefeTaller = new BinaryOperator("UsuarioJefeTaller", true);
                        Usuario UsuarioJefeTaller = Session.FindObject<Usuario>(CriteriaUsuarioJefeTaller);
                        if (!ReferenceEquals(UsuarioJefeTaller, null))
                        {
                            EnviarCorreo EnviarCorreo = new EnviarCorreo();
                            CorreoANotificar = UsuarioJefeTaller.CorreoElectronico;
                            string Mensaje = String.Format("Se notifica que el equipo {0} con número de placa {1} asignado a {2}, requiere de mantenimiento preventivo. Por favor ingresarlo al Taller a más tardar 4 días hábiles después de recibido este aviso Nota: En caso de no ingresar al Taller el vehículo en el tiempo indicado la Unidad de Transporte y Taller no se hace responsable de las fallas que un vehículo pueda presentar relacionadas con la falta de mantenimiento preventivo.", equipo, placa, Deparatamento);
                            EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Mantenimiento Preventivo");
                        }


                        BinaryOperator CriteriaUsuarioServiciosGenerales = new BinaryOperator("UsuarioServiciosGenerales", true);
                        Usuario UsuarioServiciosGenerales = Session.FindObject<Usuario>(CriteriaUsuarioServiciosGenerales);
                        if (!ReferenceEquals(UsuarioServiciosGenerales, null))
                        {
                            EnviarCorreo EnviarCorreo = new EnviarCorreo();
                            CorreoANotificar = UsuarioServiciosGenerales.CorreoElectronico;
                            string Mensaje = String.Format("Se notifica que el equipo {0} con número de placa {1} asignado a {2}, requiere de mantenimiento preventivo. Por favor ingresarlo al Taller a más tardar 4 días hábiles después de recibido este aviso Nota: En caso de no ingresar al Taller el vehículo en el tiempo indicado la Unidad de Transporte y Taller no se hace responsable de las fallas que un vehículo pueda presentar relacionadas con la falta de mantenimiento preventivo.", equipo, placa, Deparatamento);
                            EnviarCorreo.EnviarCorreoElectronico(CorreoANotificar, Mensaje, "Mantenimiento Preventivos");
                        }
                    }
                }

            }


        }
    }
}