using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Model;

namespace TallerMecanico.Module.Reportes
{
    [DomainComponent]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/#Xaf/CustomDocument3594.
    public class ParametroFechas2 : ReportParametersObjectBase
    {
        public ParametroFechas2(IObjectSpaceCreator provider) : base(provider) { }
        protected override IObjectSpace CreateObjectSpace()
        {
            return objectSpaceCreator.CreateObjectSpace(typeof(object));
        }
        public override CriteriaOperator GetCriteria()
        {
            BetweenOperator BetweenFechas = new BetweenOperator("FechaEntrada", FechaDesde, FechaHasta);
            CriteriaOperator criteria = CriteriaOperator.And(BetweenFechas);
            return criteria;
        }
        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = { new SortProperty("Oid", SortingDirection.Descending) };
            return sorting;
        }

        [ModelDefault("Caption", "Fecha Desde")]
        public DateTime FechaDesde { get; set; }
        [ModelDefault("Caption", "Fecha Hasta")]
        public DateTime FechaHasta { get; set; }

    }
}
