using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ParamReporteGeneral : ReportParametersObjectBase
    {
        public ParamReporteGeneral(IObjectSpaceCreator provider) : base(provider) { }
        protected override IObjectSpace CreateObjectSpace()
        {
            return objectSpaceCreator.CreateObjectSpace(typeof(object));
        }
        public override CriteriaOperator GetCriteria()
        {
            DeleteData();
            GenerateData();
            //BetweenOperator BetweenFechas = new BetweenOperator("FechaEntrada", FechaDesde, FechaHasta);
            //CriteriaOperator criteria = CriteriaOperator.And(BetweenFechas);
            CriteriaOperator criteria = null;
            return criteria;
        }
        public override SortProperty[] GetSorting()
        {
            SortProperty[] sorting = { new SortProperty("Numero", SortingDirection.Ascending ) };
            return sorting;
        }

        [ModelDefault("Caption", "Fecha Desde")]
        public DateTime FechaDesde { get; set; }
        [ModelDefault("Caption", "Fecha Hasta")]
        public DateTime FechaHasta { get; set; }

        private void DeleteData()
        {
            BinaryOperator Eliminar = new BinaryOperator("Eliminar", true);
            bool Seguir = true;
            while (Seguir)
            {
                if (!ReferenceEquals(this.ObjectSpace.FindObject<ReporteGeneral>(Eliminar), null))
                {
                    this.ObjectSpace.Delete(this.ObjectSpace.FindObject<ReporteGeneral>(Eliminar));
                    this.ObjectSpace.CommitChanges();
                }
                else
                {
                    Seguir = false;
                }
            }

        }

        private void GenerateData()
        {
            BetweenOperator BetweenFechas = new BetweenOperator("FechaEntrada", FechaDesde, FechaHasta);
            CriteriaOperator criteria = CriteriaOperator.And(BetweenFechas);
            ICollection<SolicitudReparacion> ListadoDeSolicitudes = ObjectSpace.GetObjects<SolicitudReparacion>(criteria);

            int NoAplica = 0; int Ingresada = 0; int Enviada = 0; int Autorizada = 0; int DiagnosticoRealizado = 0; int ObtencionAlmacen = 0;
            int ObtencionCajaChica = 0; int ObtencionUACI = 0; int Reparacion = 0; int Finalizada = 0; int Anulada = 0;
            decimal totalNoAplica = 0; decimal totalIngresada = 0; decimal totalEnviada = 0; decimal totalAutorizada = 0; decimal totalDiagnosticoRealizado = 0;
            decimal totalObtencionAlmacen = 0; decimal totalObtencionCajaChica = 0; decimal totalObtencionUACI = 0; decimal totalReparacion = 0;
            decimal totalFinalizada = 0; decimal totalAnulada = 0; decimal CostoProyectado = 0;decimal CostoReal=0;

            int Servicio = 0; decimal totalServicio = 0; int Preventivo = 0; decimal TotalPreventivo = 0; int Correctivo = 0; decimal totalCorrectivo = 0;


            foreach (SolicitudReparacion SolicitudList in ListadoDeSolicitudes)
            {
                decimal total = 0;

                BinaryOperator BinaryCompra = new BinaryOperator("CompraRepuestos", SolicitudList);
                CriteriaOperator criteriaCompra = CriteriaOperator.And(BinaryCompra);
                ICollection<CompraRepuesto> ListadoCompras = ObjectSpace.GetObjects<CompraRepuesto>(criteriaCompra);

                if(!ReferenceEquals(ListadoCompras,null))
                {
                    foreach (CompraRepuesto ComprasList in ListadoCompras)
                    {
                        total = total + ComprasList.Total;
                    }
                }


                if(SolicitudList.EstadoSolicitud == EstadoSolicitud.NoAplica)
                {
                    NoAplica++;
                    totalNoAplica = totalNoAplica + total;
                }
                else if (SolicitudList.EstadoSolicitud == EstadoSolicitud.Ingresada)
                {
                    Ingresada++;
                    totalIngresada = totalIngresada + total;
                }
                else if(SolicitudList.EstadoSolicitud == EstadoSolicitud.Enviada )
                {
                    Enviada++;
                    totalEnviada = totalEnviada + total;
                }
                else if (SolicitudList.EstadoSolicitud == EstadoSolicitud.Autorizada )
                {
                    Autorizada++;
                    totalAutorizada = totalAutorizada + total;
                }
                else if (SolicitudList.EstadoSolicitud == EstadoSolicitud.DiagnosticoRealizado)
                {
                    DiagnosticoRealizado++;
                    totalDiagnosticoRealizado = totalDiagnosticoRealizado + total;
                }
                else if (SolicitudList.EstadoSolicitud == EstadoSolicitud.ObtencionAlmacen)
                {
                    ObtencionAlmacen++;
                    totalObtencionAlmacen = totalObtencionAlmacen + total;
                }
                else if (SolicitudList.EstadoSolicitud == EstadoSolicitud.ObtencionCajaChica)
                {
                    ObtencionCajaChica++;
                    totalObtencionCajaChica = totalObtencionCajaChica + total;
                }
                else if (SolicitudList.EstadoSolicitud == EstadoSolicitud.ObtencionUACI)
                {
                    ObtencionUACI++;
                    totalObtencionUACI = totalObtencionUACI + total;
                }
                else if (SolicitudList.EstadoSolicitud == EstadoSolicitud.Reparacion)
                {
                    Reparacion++;
                    totalReparacion = totalReparacion + total;
                }
                else if (SolicitudList.EstadoSolicitud == EstadoSolicitud.Finalizada)
                {
                    Finalizada++;
                    totalFinalizada = totalFinalizada + total;
                }
                else if (SolicitudList.EstadoSolicitud == EstadoSolicitud.Anulada)
                {
                    Anulada++;
                    totalAnulada = totalAnulada + total;
                }


                

                if (!ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Anulada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Autorizada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Enviada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Ingresada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.NoAplica))
                {
                    int mantenimiento = 0;
                    BinaryOperator BinaryDiagnostico = new BinaryOperator("DiagnosticoSolicitud", SolicitudList);
                    CriteriaOperator criteriaDiagnostico = CriteriaOperator.And(BinaryDiagnostico);
                    ICollection<SolicitudDiagnostico> ListadoDiagnostico = ObjectSpace.GetObjects<SolicitudDiagnostico>(criteriaDiagnostico);
                    
                    if (!ReferenceEquals(ListadoDiagnostico, null))
                    {
                        foreach (SolicitudDiagnostico DiagnosticoList in ListadoDiagnostico)
                        {
                            if(DiagnosticoList.TipoMantenimiento == TipoMantenimiento.Servicio)
                            {
                                Servicio++;
                                mantenimiento = 1;
                            }
                            else if (DiagnosticoList.TipoMantenimiento == TipoMantenimiento.Preventivo )
                            {
                                Preventivo++;
                                mantenimiento = 2;
                            }
                            else if (DiagnosticoList.TipoMantenimiento == TipoMantenimiento.Correctivo)
                            {
                                Correctivo++;
                                mantenimiento = 3;
                            }
                        }

                        BinaryOperator BinaryCompras = new BinaryOperator("CompraRepuestos", SolicitudList);
                        CriteriaOperator criteriaCompras = CriteriaOperator.And(BinaryCompras);
                        ICollection<CompraRepuesto> ListadoCompra = ObjectSpace.GetObjects<CompraRepuesto>(criteriaCompras);

                        total = 0;

                        if (!ReferenceEquals(ListadoCompra, null))
                        {
                            foreach (CompraRepuesto ComprasList in ListadoCompra)
                            {
                                total = total + ComprasList.Total;
                            }
                        }

                        if(mantenimiento == 1)
                        {
                            totalServicio = totalServicio + total;                   
                        }
                        else if (mantenimiento == 2)
                        {
                            TotalPreventivo = TotalPreventivo + total;
                        }
                        else if (mantenimiento == 3)
                        {
                            totalCorrectivo = totalCorrectivo + total;
                        }
                    }
                
                }

                CostoReal = totalServicio + TotalPreventivo + totalCorrectivo;

            }
            var newListadoDeSolicitudes = ListadoDeSolicitudes.OrderBy(o => o.CodSolicitud);
            foreach (SolicitudReparacion SolicitudList in newListadoDeSolicitudes)
            {
                if (!ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Anulada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Autorizada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Enviada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Ingresada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.NoAplica))
                {
                    decimal total = 0; int codigo = 0;
                    BinaryOperator BinaryAlmacen = new BinaryOperator("SolicitudRepuesto", SolicitudList);
                    CriteriaOperator criteriaAlmacen = CriteriaOperator.And(BinaryAlmacen);
                    ICollection<SolicitudRepuestos> ListadoRepuesto = ObjectSpace.GetObjects<SolicitudRepuestos>(criteriaAlmacen);

                    if (!ReferenceEquals(ListadoRepuesto, null))
                    {
                        foreach (SolicitudRepuestos ComprasList in ListadoRepuesto)
                        {
                            codigo = SolicitudList.CodSolicitud;
                            total = total + ComprasList.Total;
                        }
                    }

                    SolicitudList.CostoEjecucionAproximado = total;
                    //CostoProyectado = CostoProyectado + total;
                }
            }

            this.ObjectSpace.CommitChanges();

            foreach (SolicitudReparacion SolicitudList in newListadoDeSolicitudes)
            {
                if (!ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Anulada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Autorizada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Enviada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.Ingresada) && !ReferenceEquals(SolicitudList.EstadoSolicitud, EstadoSolicitud.NoAplica))
                {
                    CostoProyectado = CostoProyectado + SolicitudList.CostoEjecucionAproximado;
                }
            }





            //creando registros para estados de solicitud
            ReporteGeneral reporte0 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte0.Numero = 0;
            reporte0.Descripcion = "NoAplica";
            reporte0.Total = NoAplica;
            reporte0.Eliminar = true;
            reporte0.Tipo = "ESTADO SOLICITUD";
            reporte0.Costo = totalNoAplica;
            reporte0.FechaInicio = FechaDesde;
            reporte0.FechaFin = FechaHasta;
            reporte0.CostoProyectado = CostoProyectado;
            reporte0.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte1 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte1.Numero = 1;
            reporte1.Descripcion = "Ingresada";
            reporte1.Total = Ingresada;
            reporte1.Eliminar = true;
            reporte1.Tipo = "ESTADO SOLICITUD";
            reporte1.Costo = totalIngresada;
            reporte1.FechaInicio = FechaDesde;
            reporte1.FechaFin = FechaHasta;
            reporte1.CostoProyectado = CostoProyectado;
            reporte1.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte2 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte2.Numero = 2;
            reporte2.Descripcion = "Enviada";
            reporte2.Total = Enviada;
            reporte2.Eliminar = true;
            reporte2.Tipo = "ESTADO SOLICITUD";
            reporte2.Costo = totalEnviada;
            reporte2.FechaInicio = FechaDesde;
            reporte2.FechaFin = FechaHasta;
            reporte2.CostoProyectado = CostoProyectado;
            reporte2.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte3 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte3.Numero = 3;
            reporte3.Descripcion = "Autorizada";
            reporte3.Total = Autorizada;
            reporte3.Eliminar = true;
            reporte3.Tipo = "ESTADO SOLICITUD";
            reporte3.Costo = totalAutorizada;
            reporte3.FechaInicio = FechaDesde;
            reporte3.FechaFin = FechaHasta;
            reporte3.CostoProyectado = CostoProyectado;
            reporte3.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte4 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte4.Numero = 4;
            reporte4.Descripcion = "DiagnosticoRealizado";
            reporte4.Total = DiagnosticoRealizado;
            reporte4.Eliminar = true;
            reporte4.Tipo = "ESTADO SOLICITUD";
            reporte4.Costo = totalDiagnosticoRealizado;
            reporte4.FechaInicio = FechaDesde;
            reporte4.FechaFin = FechaHasta;
            reporte4.CostoProyectado = CostoProyectado;
            reporte4.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte5 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte5.Numero = 5;
            reporte5.Descripcion = "ObtencionAlmacen";
            reporte5.Total = ObtencionAlmacen;
            reporte5.Eliminar = true;
            reporte5.Tipo = "ESTADO SOLICITUD";
            reporte5.Costo = totalObtencionAlmacen;
            reporte5.FechaInicio = FechaDesde;
            reporte5.FechaFin = FechaHasta;
            reporte5.CostoProyectado = CostoProyectado;
            reporte5.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte6 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte6.Numero = 6;
            reporte6.Descripcion = "ObtencionCajaChica";
            reporte6.Total = ObtencionCajaChica;
            reporte6.Eliminar = true;
            reporte6.Tipo = "ESTADO SOLICITUD";
            reporte6.Costo = totalObtencionCajaChica;
            reporte6.FechaInicio = FechaDesde;
            reporte6.FechaFin = FechaHasta;
            reporte6.CostoProyectado = CostoProyectado;
            reporte6.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte7 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte7.Numero = 7;
            reporte7.Descripcion = "ObtencionUACI";
            reporte7.Total = ObtencionUACI;
            reporte7.Eliminar = true;
            reporte7.Tipo = "ESTADO SOLICITUD";
            reporte7.Costo = totalObtencionUACI;
            reporte7.FechaInicio = FechaDesde;
            reporte7.FechaFin = FechaHasta;
            reporte7.CostoProyectado = CostoProyectado;
            reporte7.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte8 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte8.Numero = 8;
            reporte8.Descripcion = "Reparacion";
            reporte8.Total = Reparacion;
            reporte8.Eliminar = true;
            reporte8.Tipo = "ESTADO SOLICITUD";
            reporte8.Costo = totalReparacion;
            reporte8.FechaInicio = FechaDesde;
            reporte8.FechaFin = FechaHasta;
            reporte8.CostoProyectado = CostoProyectado;
            reporte8.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte9 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte9.Numero = 9;
            reporte9.Descripcion = "Finalizada";
            reporte9.Total = Finalizada;
            reporte9.Eliminar = true;
            reporte9.Tipo = "ESTADO SOLICITUD";
            reporte9.Costo = totalFinalizada;
            reporte9.FechaInicio = FechaDesde;
            reporte9.FechaFin = FechaHasta;
            reporte9.CostoProyectado = CostoProyectado;
            reporte9.CostoReal = CostoReal;

            //creando registros
            ReporteGeneral reporte10 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte10.Numero = 10;
            reporte10.Descripcion = "Anulada";
            reporte10.Total = Anulada;
            reporte10.Eliminar = true;
            reporte10.Tipo = "ESTADO SOLICITUD";
            reporte10.Costo = totalAnulada;
            reporte10.FechaInicio = FechaDesde;
            reporte10.FechaFin = FechaHasta;
            reporte10.CostoProyectado = CostoProyectado;
            reporte10.CostoReal = CostoReal;

            //creando registros para tipos de mantenimiento
            ReporteGeneral reporte11 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte11.Numero = 1;
            reporte11.Descripcion = "Solicitud de servicio";
            reporte11.Total = Servicio;
            reporte11.Eliminar = true;
            reporte11.Tipo = "TIPO DE MANTENIMIENTO";
            reporte11.Costo = totalServicio;
            reporte11.FechaInicio = FechaDesde;
            reporte11.FechaFin = FechaHasta;
            reporte11.CostoProyectado = CostoProyectado;
            reporte11.CostoReal = CostoReal;

            ReporteGeneral reporte12 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte12.Numero = 2;
            reporte12.Descripcion = "Mantenimiento Preventivo";
            reporte12.Total = Preventivo;
            reporte12.Eliminar = true;
            reporte12.Tipo = "TIPO DE MANTENIMIENTO";
            reporte12.Costo = TotalPreventivo;
            reporte12.FechaInicio = FechaDesde;
            reporte12.FechaFin = FechaHasta;
            reporte12.CostoProyectado = CostoProyectado;
            reporte12.CostoReal = CostoReal;

            ReporteGeneral reporte13 = this.ObjectSpace.CreateObject<ReporteGeneral>();
            reporte13.Numero = 3;
            reporte13.Descripcion = "Mantenimiento Correctivo";
            reporte13.Total = Correctivo;
            reporte13.Eliminar = true;
            reporte13.Tipo = "TIPO DE MANTENIMIENTO";
            reporte13.Costo = totalCorrectivo;
            reporte13.FechaInicio = FechaDesde;
            reporte13.FechaFin = FechaHasta;
            reporte13.CostoProyectado = CostoProyectado;
            reporte13.CostoReal = CostoReal;

            //guardando la data
            this.ObjectSpace.CommitChanges();


        }
    }
}
