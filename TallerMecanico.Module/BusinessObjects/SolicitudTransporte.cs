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
    [ModelDefault("Caption", "Salida de vehiculo")]
    [NavigationItem("Administracion de Solicitudes")]
    [Appearance("OcultarKilometraje", TargetItems = "HoraSalida,KilometrajeSalida,HoraEntrada,KilometrajeEntrada,KilometrajeRecorrido", Criteria = "!IsCurrentUserInRole('Administrators') and !IsCurrentUserInRole('Seguridad')", Visibility = ViewItemVisibility.Hide)]
 
    public class SolicitudTransporte : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public SolicitudTransporte(Session session)
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


        private int _KilometrajeRecorrido;
        private int _KilometrajeEntrada;
        private string _HoraEntrada;
        private int _KilometrajeSalida;
        private string _HoraSalida;
        private Oficina _Oficina;
        private string _Acompanantes;
        private string _Destino;
        private string _NombreMotorista;
        private string _UnidadSolicitante;
        private Automovil _Automovil;
        private DateTime _FechaSalida;
        private Usuario _UsuarioRegistro;



        [RuleRequiredField]
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


        //[RuleRequiredField]
        [Appearance("Oficina", Visibility = ViewItemVisibility.Hide, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        public Oficina Oficina
        {
            get
            {
                return _Oficina;
            }
            set
            {
                SetPropertyValue("Oficina", ref _Oficina, value);
            }
        }

       // [Appearance("UnidadSolicitante", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        public string UnidadSolicitante
        {
            get
            {
                return _UnidadSolicitante;
            }
            set
            {
                SetPropertyValue("UnidadSolicitante", ref _UnidadSolicitante, value);
            }
        }


        [RuleRequiredField]
        [ModelDefault("Caption", "Nombre de Motorista")]
        public string NombreMotorista
        {
            get
            {
                return _NombreMotorista;
            }
            set
            {
                SetPropertyValue("NombreMotorista", ref _NombreMotorista, value);
            }
        }

        [RuleRequiredField]
        public string Destino
        {
            get
            {
                return _Destino;
            }
            set
            {
                SetPropertyValue("Destino", ref _Destino, value);
            }
        }

        [ModelDefault("Caption", "Personas Acompañantes")]
        public string Acompanantes
        {
            get
            {
                return _Acompanantes;
            }
            set
            {
                SetPropertyValue("Acompanantes", ref _Acompanantes, value);
            }
        }


        [ModelDefault("EditMask", "##:##")]
        [ModelDefault("DisplayFormat", "##:##")]
        public string HoraSalida
        {
            get
            {
                return _HoraSalida;
            }
            set
            {
                SetPropertyValue("HoraSalida", ref _HoraSalida, value);
            }
        }



        public int KilometrajeSalida
        {
            get
            {
                return _KilometrajeSalida;
            }
            set
            {
                SetPropertyValue("KilometrajeSalida", ref _KilometrajeSalida, value);
            }
        }




        [ModelDefault("EditMask", "##:##")]
        [ModelDefault("DisplayFormat", "##:##")]
        public string HoraEntrada
        {
            get
            {
                return _HoraEntrada;
            }
            set
            {
                SetPropertyValue("HoraEntrada", ref _HoraEntrada, value);
            }
        }




        public int KilometrajeEntrada
        {
            get
            {
                return _KilometrajeEntrada;
            }
            set
            {
                SetPropertyValue("KilometrajeEntrada", ref _KilometrajeEntrada, value);
            }
        }


         [Appearance("KilometrajeRecorrido", Enabled = false, Criteria = "(CurrentUserLoged.UsuarioAdministrador != true)")]
        public int KilometrajeRecorrido
        {
            get
            {
                return _KilometrajeRecorrido;
            }
            set
            {
                SetPropertyValue("KilometrajeRecorrido", ref _KilometrajeRecorrido, value);
            }
        }


         protected override void OnSaving()
         {
             if (KilometrajeSalida > 0 && KilometrajeEntrada > 0 && KilometrajeSalida < KilometrajeEntrada)
             {
                 this.KilometrajeRecorrido = KilometrajeEntrada - KilometrajeSalida;
             }

           
         } 


    }
}
