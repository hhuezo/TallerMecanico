namespace TallerMecanico.Module.Controllers
{
    partial class SolicitudEstado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolicitudEstado));
            this.EnviarSolicitud = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.AutorizarSolicitud = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.FinalizarSolicitud = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.btnFinalizar = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // EnviarSolicitud
            // 
            this.EnviarSolicitud.Caption = "Enviar Solicitud";
            this.EnviarSolicitud.ConfirmationMessage = "Desea enviar la solicitud?";
            this.EnviarSolicitud.Id = "5cb36949-6999-4ac9-a638-dc222ea8f831";
            this.EnviarSolicitud.TargetObjectsCriteria = "(EstadoSolicitud=1) ";
            this.EnviarSolicitud.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.EnviarSolicitud.ToolTip = null;
            this.EnviarSolicitud.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.EnviarSolicitud.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.EnviarSolicitud_Execute);
            // 
            // AutorizarSolicitud
            // 
            this.AutorizarSolicitud.Caption = "Autorizar Solicitud";
            this.AutorizarSolicitud.ConfirmationMessage = "Desea autorizar la solicitud?";
            this.AutorizarSolicitud.Id = "9ed2e0fb-7b8f-45bb-b9b0-fe31922b975d";
            this.AutorizarSolicitud.TargetObjectsCriteria = "(EstadoSolicitud=2) and CurrentUserLoged.UsuarioJefeTaller=true";
            this.AutorizarSolicitud.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.AutorizarSolicitud.ToolTip = null;
            this.AutorizarSolicitud.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.AutorizarSolicitud.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.AutorizarSolicitud_Execute);
            // 
            // FinalizarSolicitud
            // 
            this.FinalizarSolicitud.Caption = "Anular Solicitud";
            this.FinalizarSolicitud.ConfirmationMessage = null;
            this.FinalizarSolicitud.Id = "15185b5e-83cc-4dd9-9302-9e68a86aa2e5";
            this.FinalizarSolicitud.TargetObjectsCriteria = resources.GetString("FinalizarSolicitud.TargetObjectsCriteria");
            this.FinalizarSolicitud.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.FinalizarSolicitud.ToolTip = null;
            this.FinalizarSolicitud.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.FinalizarSolicitud.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.FinalizarSolicitud_Execute);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Caption = "Finalizar";
            this.btnFinalizar.ConfirmationMessage = null;
            this.btnFinalizar.Id = "99f933fb-26f0-46ed-afdb-b98046b54b32";
            this.btnFinalizar.TargetObjectType = typeof(TallerMecanico.Module.BusinessObjects.SolicitudReparacion);
            this.btnFinalizar.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.btnFinalizar.ToolTip = null;
            this.btnFinalizar.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.btnFinalizar.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btnFinalizar_Execute);
            // 
            // SolicitudEstado
            // 
            this.Actions.Add(this.EnviarSolicitud);
            this.Actions.Add(this.AutorizarSolicitud);
            this.Actions.Add(this.FinalizarSolicitud);
            this.Actions.Add(this.btnFinalizar);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction EnviarSolicitud;
        private DevExpress.ExpressApp.Actions.SimpleAction AutorizarSolicitud;
        private DevExpress.ExpressApp.Actions.SimpleAction FinalizarSolicitud;
        private DevExpress.ExpressApp.Actions.SimpleAction btnFinalizar;
    }
}
