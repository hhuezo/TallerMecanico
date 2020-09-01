using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Model;
using TallerMecanico.Module.BusinessObjects;
using System.Collections.Generic;

namespace TallerMecanico.Module.Reportes
{
    [DomainComponent]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/#Xaf/CustomDocument3594.
    public class ParametroFechas : ReportParametersObjectBase
    {
        public ParametroFechas(IObjectSpaceCreator provider) : base(provider) { }
        protected override IObjectSpace CreateObjectSpace()
        {
            return objectSpaceCreator.CreateObjectSpace(typeof(object));
        }
        public override CriteriaOperator GetCriteria()
        {
            GenerateData();
            //CriteriaOperator criteria = new BinaryOperator("MyPropertyName", "MyValue");
            BetweenOperator BetweenFechas = new BetweenOperator("CompraRepuestos.FechaEntrada", FechaDesde, FechaHasta);
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





        private void GenerateData()
        {
            BinaryOperator BinarySolicitud = new BinaryOperator("CodSolicitud", 0, BinaryOperatorType.Greater);
            BetweenOperator BetweenFechas = new BetweenOperator("FechaEntrada", FechaDesde, FechaHasta);
            CriteriaOperator criteria = CriteriaOperator.And(BetweenFechas, BinarySolicitud);

            ICollection<SolicitudReparacion> ListadoDeSolicitudes = ObjectSpace.GetObjects<SolicitudReparacion>(criteria);

            if (!ReferenceEquals(ListadoDeSolicitudes, null))
            {

                foreach (SolicitudReparacion ObjSolicitud in ListadoDeSolicitudes)
                {
                    decimal total = 0;
                    decimal TotalAproximado = 0;
                    string TrabajoRealizado = "";
                    int dias = 0;
                    TimeSpan tiempoTranscurrido;

                    BinaryOperator BinaryCompra = new BinaryOperator("CompraRepuestos", ObjSolicitud);
                    CriteriaOperator criteriaCompra = CriteriaOperator.And(BinaryCompra);
                    ICollection<CompraRepuesto> ListadoCompras = ObjectSpace.GetObjects<CompraRepuesto>(criteriaCompra);

                    BinaryOperator BinarySalida = new BinaryOperator("SalidaVehiculo", ObjSolicitud);
                    CriteriaOperator criteriaSalida = CriteriaOperator.And(BinarySalida);
                    ICollection<SolicitudSalidaVehiculo> ListadoSalidas = ObjectSpace.GetObjects<SolicitudSalidaVehiculo>(criteriaSalida);


                    BinaryOperator BinaryAproximado = new BinaryOperator("SolicitudRepuesto", ObjSolicitud);
                    CriteriaOperator criteriaAproximado = CriteriaOperator.And(BinaryAproximado);
                    ICollection<SolicitudRepuestos> ListadoAproximado = ObjectSpace.GetObjects<SolicitudRepuestos>(criteriaAproximado);


                    if (!ReferenceEquals(ListadoCompras, null))
                    {
                        if (!ReferenceEquals(ListadoCompras, null))
                        {
                            foreach (CompraRepuesto ComprasList in ListadoCompras)
                            {
                                total = total + ComprasList.Total;
                            }

                        }


                        if (!ReferenceEquals(ListadoSalidas, null))
                        {
                            foreach (SolicitudSalidaVehiculo SalidaList in ListadoSalidas)
                            {
                                TrabajoRealizado = TrabajoRealizado + SalidaList.TrabajoRealizado;
                                tiempoTranscurrido = SalidaList.FechaSalida.Subtract(ObjSolicitud.FechaEntrada);
                                dias = tiempoTranscurrido.Days + 1;
                            }

                        }


                        if (!ReferenceEquals(ListadoAproximado, null))
                        {
                            foreach (SolicitudRepuestos AproximadoList in ListadoAproximado)
                            {
                                TotalAproximado += AproximadoList.Total;
                            }

                        }

                    }

                    if (total > 0 && dias>0)
                    {
                        ObjSolicitud.RendimientoReal = total / dias;
                    }
                    else{
                         ObjSolicitud.RendimientoReal = 0;
                    }

                    ObjSolicitud.CostoEjecucionReal = total;
                    ObjSolicitud.CostoEjecucionAproximado = TotalAproximado;
                    ObjSolicitud.TrabajoRealizado = TrabajoRealizado;


               }


                //guardando la data
                this.ObjectSpace.CommitChanges();
            
            }



        }


    }

    

}
