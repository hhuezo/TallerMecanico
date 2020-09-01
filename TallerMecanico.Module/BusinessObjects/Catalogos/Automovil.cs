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

namespace TallerMecanico.Module.BusinessObjects.Catalogos
{
    [DefaultClassOptions]
    [NavigationItem("Catalogos")]
    [FriendlyKeyProperty("NumeroPlaca")]
    public class Automovil : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public Automovil(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }


        // Fields...
        private bool _Activo;
        private TipoCombustible _TipoCombustible;
        private bool _Preventivo5000km;
        private int _ContadorKilometraje;
        private int _KilometrajeActual;
        private Departamento _Departamento;
        private int _Axo;
        private AutoClase _AutoClase;
        private AutoModelo _AutoModelo;
        private AutoMarca _AutoMarca;
        private string _NumeroPlaca;
        private string _NumeroEquipo;

        [RuleRequiredField]
        [VisibleInLookupListView(true)]
        public string NumeroEquipo
        {
            get
            {
                return _NumeroEquipo;
            }
            set
            {
                SetPropertyValue("NumeroEquipo", ref _NumeroEquipo, value);
            }
        }

        [RuleRequiredField]
        [RuleUniqueValue]
        public string NumeroPlaca
        {
            get
            {
                return _NumeroPlaca;
            }
            set
            {
                SetPropertyValue("NumeroPlaca", ref _NumeroPlaca, value);
            }
        }



        public AutoMarca AutoMarca
        {
            get
            {
                return _AutoMarca;
            }
            set
            {
                SetPropertyValue("AutoMarca", ref _AutoMarca, value);
            }
        }


        public AutoModelo AutoModelo
        {
            get
            {
                return _AutoModelo;
            }
            set
            {
                SetPropertyValue("AutoModelo", ref _AutoModelo, value);
            }
        }


        public AutoClase AutoClase
        {
            get
            {
                return _AutoClase;
            }
            set
            {
                SetPropertyValue("AutoClase", ref _AutoClase, value);
            }
        }

        
        public TipoCombustible TipoCombustible
        {
            get
            {
                return _TipoCombustible;
            }
            set
            {
                SetPropertyValue("TipoCombustible", ref _TipoCombustible, value);
            }
        }



        [ModelDefault("Caption", "Año")]
        public int Axo
        {
            get
            {
                return _Axo;
            }
            set
            {
                SetPropertyValue("Axo", ref _Axo, value);
            }
        }

        
        [VisibleInLookupListView(true)]
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


        public int KilometrajeActual
        {
            get
            {
                return _KilometrajeActual;
            }
            set
            {
                SetPropertyValue("KilometrajeActual", ref _KilometrajeActual, value);
            }
        }


        public int ContadorKilometraje
        {
            get
            {
                return _ContadorKilometraje;
            }
            set
            {
                SetPropertyValue("ContadorKilometraje", ref _ContadorKilometraje, value);
            }
        }
        

        public bool Preventivo5000km
        {
            get
            {
                return _Preventivo5000km;
            }
            set
            {
                SetPropertyValue("Preventivo5000km", ref _Preventivo5000km, value);
            }
        }
    }
}
