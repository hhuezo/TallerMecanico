using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ReportsV2;
using TallerMecanico.Module.BusinessObjects.Catalogos;

namespace TallerMecanico.Module.Reportes
{
    [DomainComponent]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/#Xaf/CustomDocument3594.
    public class ParametroFechaAuto : ReportParametersObjectBase
    {
        public ParametroFechaAuto(IObjectSpaceCreator provider) : base(provider) { }
        protected override IObjectSpace CreateObjectSpace()
        {
            return objectSpaceCreator.CreateObjectSpace(typeof(object));
        }
        public override CriteriaOperator GetCriteria()
        {
            //CriteriaOperator criteria = new BinaryOperator("MyPropertyName", "MyValue");

           CriteriaOperator criteria = new
           BinaryOperator("Automovil", Automovil);
          
            BetweenOperator BetweenFechas = new BetweenOperator("FechaEntrada", FechaDesde, FechaHasta);
            CriteriaOperator criteria2 = CriteriaOperator.And(BetweenFechas);

            CriteriaOperator criteria3 = null;
            criteria3 = CriteriaOperator.And(criteria, criteria2);
            return criteria3;

        }
        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = { new SortProperty("Automovil", SortingDirection.Descending) };
            return sorting;
        }

        public Automovil Automovil { get; set; }
        
        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }
    }
}
