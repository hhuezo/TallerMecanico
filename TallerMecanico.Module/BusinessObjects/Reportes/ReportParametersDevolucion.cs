using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.Validation;

namespace TallerMecanico.Module.BusinessObjects.Reportes
{
    [DomainComponent]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/#Xaf/CustomDocument3594.
    public class ReportParametersDevolucion : ReportParametersObjectBase
    {
        public ReportParametersDevolucion(IObjectSpaceCreator provider) : base(provider) { }
        protected override IObjectSpace CreateObjectSpace()
        {
            return objectSpaceCreator.CreateObjectSpace(typeof(object));
        }
        public override CriteriaOperator GetCriteria()
        {
            CriteriaOperator criteria = new BinaryOperator("CodSolicitud", NumeroSolicitud);
            return criteria;
        }
        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = { new SortProperty("CodSolicitud", SortingDirection.Descending) };
            return sorting;
        }

        [RuleRequiredField]
        public int NumeroSolicitud { get; set; }

    }
}
