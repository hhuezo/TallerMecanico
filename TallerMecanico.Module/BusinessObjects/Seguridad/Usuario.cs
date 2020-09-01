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
using DevExpress.ExpressApp.Security.Strategy;

namespace TallerMecanico.Module.BusinessObjects.Seguridad
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class Usuario : SecuritySystemUser
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Usuario(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        private string _CorreoElectronico;
        private Departamento _Departamento;
        private bool _UsuarioGerente;
        private string _NombreCompleto;
        private bool _UsuarioJefeTaller;
        private bool _UsuarioTaller;
        private bool _UsuarioAdministrador;
        private bool _UsuarioSolicitante;
        private bool _UsuarioServiciosGenerales;


        public string NombreCompleto
        {
            get
            {
                return _NombreCompleto;
            }
            set
            {
                SetPropertyValue("NombreCompleto", ref _NombreCompleto, value);
            }
        }


        public string CorreoElectronico
        {
            get
            {
                return _CorreoElectronico;
            }
            set
            {
                SetPropertyValue("CorreoElectronico", ref _CorreoElectronico, value);
            }
        }

        
        public Departamento Departamento
        {
            get
            {
                return _Departamento;
            }
            set
            {
                SetPropertyValue("Departamento", ref _Departamento, value);
            }
        }

        public bool UsuarioSolicitante
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


        public bool UsuarioTaller
        {
            get
            {
                return _UsuarioTaller;
            }
            set
            {
                SetPropertyValue("UsuarioTaller", ref _UsuarioTaller, value);
            }
        }


        public bool UsuarioJefeTaller
        {
            get
            {
                return _UsuarioJefeTaller;
            }
            set
            {
                SetPropertyValue("UsuarioJefeTaller", ref _UsuarioJefeTaller, value);
            }
        }



        public bool UsuarioGerente
        {
            get
            {
                return _UsuarioGerente;
            }
            set
            {
                SetPropertyValue("UsuarioGerente", ref _UsuarioGerente, value);
            }
        }


        public bool UsuarioServiciosGenerales
        {
            get
            {
                return _UsuarioServiciosGenerales;
            }
            set
            {
                SetPropertyValue("UsuarioServiciosGenerales", ref _UsuarioServiciosGenerales, value);
            }
        }

        public bool UsuarioAdministrador
        {
            get
            {
                return _UsuarioAdministrador;
            }
            set
            {
                SetPropertyValue("UsuarioAdministrador", ref _UsuarioAdministrador, value);
            }
        }
    }
}
