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

namespace TallerMecanico.Module.Reportes
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class ReporteGeneral : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public ReporteGeneral(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private decimal _CostoReal;
        private decimal _CostoProyectado;
        private DateTime _FechaFin;
        private DateTime _FechaInicio;
        private string _Tipo;
        private bool _Eliminar;
        private decimal _Costo;
        private int _Total;
        private int _Numero;
        private string _Descripcion;



        public string Tipo
        {
            get
            {
                return _Tipo;
            }
            set
            {
                SetPropertyValue("Tipo", ref _Tipo, value);
            }
        }

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


        public int Numero
        {
            get
            {
                return _Numero;
            }
            set
            {
                SetPropertyValue("Numero", ref _Numero, value);
            }
        }


        public int Total
        {
            get
            {
                return _Total;
            }
            set
            {
                SetPropertyValue("Total", ref _Total, value);
            }
        }


        public decimal Costo
        {
            get
            {
                return _Costo;
            }
            set
            {
                SetPropertyValue("Costo", ref _Costo, value);
            }
        }


        public bool Eliminar
        {
            get
            {
                return _Eliminar;
            }
            set
            {
                SetPropertyValue("Eliminar", ref _Eliminar, value);
            }
        }



        public DateTime FechaInicio
        {
            get
            {
                return _FechaInicio;
            }
            set
            {
                SetPropertyValue("FechaInicio", ref _FechaInicio, value);
            }
        }



        public DateTime FechaFin
        {
            get
            {
                return _FechaFin;
            }
            set
            {
                SetPropertyValue("FechaFin", ref _FechaFin, value);
            }
        }


        public decimal CostoProyectado
        {
            get
            {
                return _CostoProyectado;
            }
            set
            {
                SetPropertyValue("CostoProyectado", ref _CostoProyectado, value);
            }
        }


        public decimal CostoReal
        {
            get
            {
                return _CostoReal;
            }
            set
            {
                SetPropertyValue("CostoReal", ref _CostoReal, value);
            }
        }
    }
}
