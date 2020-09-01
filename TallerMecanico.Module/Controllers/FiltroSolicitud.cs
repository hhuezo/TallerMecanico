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
using TallerMecanico.Module.BusinessObjects.Seguridad;
using TallerMecanico.Module.BusinessObjects;

namespace TallerMecanico.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class FiltroSolicitud : ViewController
    {
        public FiltroSolicitud()
        {
            InitializeComponent();
            RegisterActions(components);
            this.TargetObjectType = typeof(TallerMecanico.Module.BusinessObjects.SolicitudReparacion);
            this.TargetViewType = ViewType.ListView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            ListView Vista = (ListView)this.View;
            BinaryOperator CriteriaUsuario = new BinaryOperator("UserName", SecuritySystem.CurrentUserName);
            Usuario Usuario = this.ObjectSpace.FindObject<Usuario>(CriteriaUsuario);

            Departamento depUsuario = Usuario.Departamento;
            BinaryOperator DepActual = new BinaryOperator("Departamento", depUsuario);


            if (!Usuario.UsuarioAdministrador && !Usuario.UsuarioGerente && !Usuario.UsuarioTaller && !Usuario.UsuarioJefeTaller && !Usuario.UsuarioServiciosGenerales)
            {
                CriteriaOperator DepCriteria = CriteriaOperator.And(DepActual);
                Vista.CollectionSource.Criteria["Filtro Dep"] = DepCriteria;
            }
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
