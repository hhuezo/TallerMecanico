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

namespace TallerMecanico.Module.BusinessObjects.vistas
{
    [DefaultClassOptions]
    [ModelDefault("Caption", "Oficinas Samp")]
    [NavigationItem("Catalogos")]
    public class OficinasSamp : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public OficinasSamp(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        private string _SeccionDepartamento;
        private string _OficinaSubGerencia;
        private string _DepartamentoSubGerencia;
        private string _DepartamentoUnidad;
        private string _AreaUnidad;
        private string _SeccionGerencia;
        private string _AreaGerencia;
        private string _DepartamentoGerencia;
        private string _SubGerencia;
        private string _Unidad;
        private string _Gerencia;
        private string _OficinaDependencia;
        private string _Dependencia;
        private int _Oid;

        [Key]
        public int Oid
        {
            get
            {
                return _Oid;
            }
            set
            {
                SetPropertyValue("Oid", ref _Oid, value);
            }
        }


        public string Dependencia
        {
            get
            {
                return _Dependencia;
            }
            set
            {
                SetPropertyValue("Dependencia", ref _Dependencia, value);
            }
        }


        public string OficinaDependencia
        {
            get
            {
                return _OficinaDependencia;
            }
            set
            {
                SetPropertyValue("OficinaDependencia", ref _OficinaDependencia, value);
            }
        }


        public string Gerencia
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


        public string Unidad
        {
            get
            {
                return _Unidad;
            }
            set
            {
                SetPropertyValue("Unidad", ref _Unidad, value);
            }
        }


        public string SubGerencia
        {
            get
            {
                return _SubGerencia;
            }
            set
            {
                SetPropertyValue("SubGerencia", ref _SubGerencia, value);
            }
        }



        public string DepartamentoGerencia
        {
            get
            {
                return _DepartamentoGerencia;
            }
            set
            {
                SetPropertyValue("DepartamentoGerencia", ref _DepartamentoGerencia, value);
            }
        }



        public string AreaGerencia
        {
            get
            {
                return _AreaGerencia;
            }
            set
            {
                SetPropertyValue("AreaGerencia", ref _AreaGerencia, value);
            }
        }


        public string SeccionGerencia
        {
            get
            {
                return _SeccionGerencia;
            }
            set
            {
                SetPropertyValue("SeccionGerencia", ref _SeccionGerencia, value);
            }
        }



        public string AreaUnidad
        {
            get
            {
                return _AreaUnidad;
            }
            set
            {
                SetPropertyValue("AreaUnidad", ref _AreaUnidad, value);
            }
        }



        public string DepartamentoUnidad
        {
            get
            {
                return _DepartamentoUnidad;
            }
            set
            {
                SetPropertyValue("DepartamentoUnidad", ref _DepartamentoUnidad, value);
            }
        }



        public string DepartamentoSubGerencia
        {
            get
            {
                return _DepartamentoSubGerencia;
            }
            set
            {
                SetPropertyValue("DepartamentoSubGerencia", ref _DepartamentoSubGerencia, value);
            }
        }


        public string OficinaSubGerencia
        {
            get
            {
                return _OficinaSubGerencia;
            }
            set
            {
                SetPropertyValue("OficinaSubGerencia", ref _OficinaSubGerencia, value);
            }
        }



        public string SeccionDepartamento
        {
            get
            {
                return _SeccionDepartamento;
            }
            set
            {
                SetPropertyValue("SeccionDepartamento", ref _SeccionDepartamento, value);
            }
        }


    }
}
