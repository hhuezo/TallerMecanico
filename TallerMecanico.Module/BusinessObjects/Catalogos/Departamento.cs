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


namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Catalogos")]
    [FriendlyKeyProperty("NombreDepartamento")]
    public class Departamento : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Departamento(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        private string _CorreoNotificar;
        private Gerencia _Gerencia;
        private string _NombreDepartamento;

        [RuleRequiredField]
        [RuleUniqueValue]
        public string NombreDepartamento
        {
            get
            {
                return _NombreDepartamento;
            }
            set
            {
                SetPropertyValue("NombreDepartamento", ref _NombreDepartamento, value);
            }
        }

        [RuleRequiredField]
        public Gerencia Gerencia
        {
            get
            {
                return _Gerencia;
            }
            set
            {
                SetPropertyValue("Gerencia", ref _Gerencia, value);
            }
        }


        public string CorreoNotificar
        {
            get
            {
                return _CorreoNotificar;
            }
            set
            {
                SetPropertyValue("CorreoNotificar", ref _CorreoNotificar, value);
            }
        }

      

    }
}
