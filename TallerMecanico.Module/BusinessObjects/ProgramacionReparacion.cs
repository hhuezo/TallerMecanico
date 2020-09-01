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
using TallerMecanico.Module.BusinessObjects.Catalogos;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace TallerMecanico.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Administracion de Solicitudes")]
    public class ProgramacionReparacion : Entidad
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ProgramacionReparacion(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private string _Detalle;
        private DateTime _FechaReparacion;
        private Automovil _Automovil;
        private SolicitudReparacion _Programacion;

        [Appearance("SolicitudReadOnly", Enabled = false)]
        [Association("SolicitudReparacion-Programacion")]
        public SolicitudReparacion Programacion
        {
            get
            {
                return _Programacion;
            }
            set
            {
                SetPropertyValue("Programacion", ref _Programacion, value);
            }
        }


        public Automovil Automovil
        {
            get
            {
                //return _Automovil;
                return this.Programacion.Automovil;
            }
            /* set
             {
                 SetPropertyValue("Automovil", ref _Automovil, value);
             }*/
        }

        [RuleRequiredField]
        public DateTime FechaReparacion
        {
            get
            {
                return _FechaReparacion;
            }
            set
            {
                SetPropertyValue("FechaReparacion", ref _FechaReparacion, value);
            }
        }

       [Size(250)]
        public string Detalle
        {
            get
            {
                return _Detalle;
            }
            set
            {
                SetPropertyValue("Detalle", ref _Detalle, value);
            }
        }
    }
}
