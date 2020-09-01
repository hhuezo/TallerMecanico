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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;

namespace TallerMecanico.Module.BusinessObjects.vistas
{
    [DefaultClassOptions]
    [ModelDefault("Caption", "Historial Equipos")]
    [NavigationItem("Administracion de Solicitudes")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    public class view_historial : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
        public view_historial(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
        }

        // Fields...
        private string _RepuestoUACI;
        private string _RepuestoCajaChica;
        private string _RepuestoAlmacen;
        private string _RepuestosInstalados;
        private string _TrabajoRealizado;
        private decimal _Total;
        private decimal _PrecioUnitario;
        private string _Descripcion;
        private int _Cantidad;
        private string _UnidadMedida;
        private string _TipoDocumento;
        private int _TipoDoc;
        private string _FallaPresentada;
        private string _TipoMantenimiento;
        private int _Tipo;
        private string _Mecanico;
        private string _NumeroPlaca;
        private string _NumeroEquipo;
        private DateTime _FechaEntrada;
        private int _CodSolicitud;
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


        public int CodSolicitud
        {
            get
            {
                return _CodSolicitud;
            }
            set
            {
                SetPropertyValue("CodSolicitud", ref _CodSolicitud, value);
            }
        }

        
        public DateTime FechaEntrada
        {
            get
            {
                return _FechaEntrada;
            }
            set
            {
                SetPropertyValue("FechaEntrada", ref _FechaEntrada, value);
            }
        }


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



        public string Mecanico
        {
            get
            {
                return _Mecanico;
            }
            set
            {
                SetPropertyValue("Mecanico", ref _Mecanico, value);
            }
        }

        [Appearance("NoVisible en CurrentUserLoged", Visibility = ViewItemVisibility.Hide)]
        public int Tipo
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


        public string TipoMantenimiento
        {
            get
            {
                if (!ReferenceEquals(Tipo, null))
                {
                    if (Tipo == 0)
                    {
                        _TipoMantenimiento = "No Aplica";

                    }
                    else if (Tipo == 1)
                    {
                        _TipoMantenimiento = "Mantenimiento Preventivo";
                    }
                    else if (Tipo == 2)
                    {
                        _TipoMantenimiento = "Mantenimiento Correctivo";
                    }
                    else if (Tipo == 3)
                    {
                        _TipoMantenimiento = "Solicitud de Servicio";
                    }

                }
                return _TipoMantenimiento;
            }

        }


        public string FallaPresentada
        {
            get
            {
                return _FallaPresentada;
            }
            set
            {
                SetPropertyValue("FallaPresentada", ref _FallaPresentada, value);
            }
        }

        
        public string RepuestoAlmacen
        {
            get
            {
                string repuestos = " ";

                var ListCompras = Session.Query<CompraRepuesto>().Where(f => f.CompraRepuestos.CodSolicitud == CodSolicitud && (f.TipoDocumentos == TipoDocumentos.SolicitudAlmacen || f.TipoDocumentos == TipoDocumentos.Solicitudlubricante)).ToList();
                if (!ReferenceEquals(ListCompras, null))
                {
                    int i = 0; decimal TotalGeneral = 0;
                    foreach (CompraRepuesto objCompra in ListCompras)
                    {
                        string precio = " $" + objCompra.PrecioUnitario.ToString("#.##");
                            if (i == 0)
                            {
                                repuestos = repuestos + objCompra.Cantidad + " " + objCompra.UnidadMedida + " " + objCompra.Descripcion + precio;
                            }
                            else
                            {
                                repuestos = repuestos + " ," + objCompra.Cantidad + " " + objCompra.UnidadMedida + " " + objCompra.Descripcion + precio;
                            }
                            i++;
                            TotalGeneral = TotalGeneral + objCompra.PrecioUnitario * objCompra.Cantidad;                        
                    }
                    if (TotalGeneral > 0)
                    {
                        repuestos = repuestos + " TOTAL INVERTIDO: " + " $" + TotalGeneral.ToString("#.##");
                    }

                }

                _RepuestoAlmacen = repuestos;
                return _RepuestoAlmacen;
            }
        
        }
        

        public string RepuestoCajaChica
        {
            get
            {
                string repuestos = " ";

                var ListCompras = Session.Query<CompraRepuesto>().Where(f => f.CompraRepuestos.CodSolicitud == CodSolicitud && f.TipoDocumentos == TipoDocumentos.SolicitudCajaChica).ToList();
                if (!ReferenceEquals(ListCompras, null))
                {
                    int i = 0; decimal TotalGeneral = 0;
                    foreach (CompraRepuesto objCompra in ListCompras)
                    {
                        string precio = " $" + objCompra.PrecioUnitario.ToString("#.##");
                            if (i == 0)
                            {
                                repuestos = repuestos + objCompra.Cantidad + " " + objCompra.UnidadMedida + " " + objCompra.Descripcion + precio;
                            }
                            else
                            {
                                repuestos = repuestos + " ," + objCompra.Cantidad + " " + objCompra.UnidadMedida + " " + objCompra.Descripcion + precio;
                            }
                            i++;
                            TotalGeneral = TotalGeneral + objCompra.PrecioUnitario * objCompra.Cantidad;                        
                    }
                    if (TotalGeneral > 0)
                    {
                        repuestos = repuestos + " TOTAL INVERTIDO: " + " $" + TotalGeneral.ToString("#.##");
                    }

                }

                _RepuestoCajaChica = repuestos;
                return _RepuestoCajaChica;
            }
           
        }

        public string RepuestoUACI
        {
            get
            {
                string repuestos = " ";

                var ListCompras = Session.Query<CompraRepuesto>().Where(f => f.CompraRepuestos.CodSolicitud == CodSolicitud && f.TipoDocumentos == TipoDocumentos.SolicitudUACI).ToList();
                if (!ReferenceEquals(ListCompras, null))
                {
                    int i = 0; decimal TotalGeneral = 0;
                    foreach (CompraRepuesto objCompra in ListCompras)
                    {
                        string precio = " $" + objCompra.PrecioUnitario.ToString("#.##");
                            if (i == 0)
                            {
                                repuestos = repuestos + objCompra.Cantidad + " " + objCompra.UnidadMedida + " " + objCompra.Descripcion + precio;
                            }
                            else
                            {
                                repuestos = repuestos + " ," + objCompra.Cantidad + " " + objCompra.UnidadMedida + " " + objCompra.Descripcion + precio;
                            }
                            i++;
                            TotalGeneral = TotalGeneral + objCompra.PrecioUnitario * objCompra.Cantidad;                       
                    }
                    if (TotalGeneral > 0)
                    {
                        repuestos = repuestos + " TOTAL INVERTIDO: " + " $" + TotalGeneral.ToString("#.##");
                    }

                }

                _RepuestoUACI = repuestos;


                return _RepuestoUACI;
            }           
        }



        public string TrabajoRealizado
        {
            get
            {
                string trabajoRealizado = " ";
                var ListSalidas = Session.Query<SolicitudSalidaVehiculo>().Where(f => f.SalidaVehiculo.CodSolicitud == CodSolicitud).ToList();
                if (!ReferenceEquals(ListSalidas,null))
                {
                    int i = 0;
                    foreach (SolicitudSalidaVehiculo objSalida in ListSalidas)
                    {
                        if(i == 0)
                        {
                            trabajoRealizado = trabajoRealizado + objSalida.TrabajoRealizado;
                        }
                        else
                        {
                            trabajoRealizado = trabajoRealizado + ", " + objSalida.TrabajoRealizado;
                        }
                        i++;
                    }
                }

                _TrabajoRealizado = trabajoRealizado;

                return _TrabajoRealizado;
            }
           
        }
         
    }
}
