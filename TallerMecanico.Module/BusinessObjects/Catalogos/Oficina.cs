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

namespace TallerMecanico.Module.BusinessObjects.Catalogos
{
    [DefaultClassOptions]
    [NavigationItem("Catalogos")]
    [FriendlyKeyProperty("Descripcion")]
    public class Oficina : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Oficina(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private string _Descripcion;

        [RuleUniqueValue]
        [RuleRequiredField]
        [ModelDefault("Caption", "Oficina")]
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                SetPropertyValue("Descripcion", ref _Descripcion, value);
            }
        }
    }
}
