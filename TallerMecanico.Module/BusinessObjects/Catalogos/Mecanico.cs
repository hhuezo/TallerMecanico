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
    [FriendlyKeyProperty("NombreMecanico")]
    //para hacer fila editable en tab
    [DefaultListViewOptions(true, DevExpress.ExpressApp.NewItemRowPosition.Top)]
    public class Mecanico : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Mecanico(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }
        private bool _Activo;
        private static bool _Externo;
        private string _NombreMecanico;

        [RuleRequiredField]
        public string NombreMecanico
        {
            get
            {
                return _NombreMecanico;
            }
            set
            {
                SetPropertyValue("NombreMecanico", ref _NombreMecanico, value);
            }
        }


        public bool Activo
        {
            get
            {
                return _Activo;
            }
            set
            {
                SetPropertyValue("Activo", ref _Activo, value);
            }
        }

        public bool Externo
        {
            get
            {
                return _Externo;
            }
            set
            {
                SetPropertyValue("Externo", ref _Externo, value);
            }
        }

    }
}
