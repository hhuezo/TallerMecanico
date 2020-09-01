using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using TallerMecanico.Module.BusinessObjects;

namespace TallerMecanico.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class ViewControllerDevoluacion : ViewController
    {
        public ViewControllerDevoluacion()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void Devolucion_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IEnumerable<CompraRepuesto> ObjetosSeleccionados = e.SelectedObjects.Cast<CompraRepuesto>();
            if (!ReferenceEquals(ObjetosSeleccionados, null))
            {

                int num = 0;

                foreach (CompraRepuesto objetosSeleccionado in ObjetosSeleccionados)
                {
                    SolicitudDevolucionRepuesto objDevolucion = this.ObjectSpace.CreateObject<SolicitudDevolucionRepuesto>();
                    objDevolucion.SolicitudReparacion = objetosSeleccionado.CompraRepuestos;
                    objDevolucion.TipoDocumentos = objetosSeleccionado.TipoDocumentos;
                    objDevolucion.fecha = objetosSeleccionado.fecha;
                    objDevolucion.Proveedor = objetosSeleccionado.Proveedor;
                    objDevolucion.NumeroOrdenFactura = objetosSeleccionado.NumeroOrdenFactura;
                    objDevolucion.NumeroDescargo = objetosSeleccionado.NumeroDescargo;
                    objDevolucion.Cantidad = objetosSeleccionado.Cantidad;
                    objDevolucion.UnidadMedida = objetosSeleccionado.UnidadMedida;
                    objDevolucion.Descripcion = objetosSeleccionado.Descripcion;
                    objDevolucion.PrecioUnitario = objetosSeleccionado.PrecioUnitario;
                    objDevolucion.Total = objetosSeleccionado.Total;
                    objDevolucion.IdAlmacen = objetosSeleccionado.IdAlmacen;


                    CriteriaOperator criteriaReparacion = new BinaryOperator("Oid", objetosSeleccionado.CompraRepuestos);
                    SolicitudReparacion ObjReparacion = ObjectSpace.FindObject<SolicitudReparacion>(criteriaReparacion);

                    if(num == 0)
                    {
                       
                        if (!ReferenceEquals(ObjReparacion, null))
                        {

                            if(ObjReparacion.NumDevolucion>0)
                            {
                                num = ObjReparacion.NumDevolucion;
                            }
                            else
                            {
                                SolicitudReparacion obj = ObjectSpace.FindObject<SolicitudReparacion>(CriteriaOperator.Parse("NumDevolucion>0 and NumDevolucion = [<SolicitudReparacion>][NumDevolucion >0].Max(NumDevolucion)"));
                                if (ReferenceEquals(obj,null))
                                {
                                    num = 1;
                                }
                                else{
                                    num = obj.NumDevolucion + 1;
                                }

                            }                          

                        }
                                            
                       
                    }

                    ObjReparacion.NumDevolucion = num;  

                    BinaryOperator Eliminar = new BinaryOperator("Oid", objetosSeleccionado.Oid, BinaryOperatorType.Equal);
                    this.ObjectSpace.Delete(this.ObjectSpace.FindObject<CompraRepuesto>(Eliminar));

                }
                if (this.View.ObjectSpace.IsModified)
                {
                    this.View.ObjectSpace.CommitChanges();
                    this.View.Refresh();
                }

            }

        }
    }
}
