namespace TallerMecanico.Module.Controllers
{
    partial class ViewControllerDevoluacion
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
            this.Devolucion = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // Devolucion
            // 
            this.Devolucion.Caption = "Devolucion";
            this.Devolucion.ConfirmationMessage = "Desea efectuar la devolucion?";
            this.Devolucion.Id = "81097412-b858-4b8b-a325-f3faeb85de28";
            this.Devolucion.TargetObjectType = typeof(TallerMecanico.Module.BusinessObjects.CompraRepuesto);
            this.Devolucion.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.Devolucion.ToolTip = null;
            this.Devolucion.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.Devolucion.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.Devolucion_Execute);
            // 
            // ViewControllerDevoluacion
            // 
            this.Actions.Add(this.Devolucion);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction Devolucion;
    }
}
