using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;

namespace TallerMecanico.Module.BusinessObjects
{
    public enum TipoDocumentos
    {
        Ninguno=0,
        [XafDisplayNameAttribute("Solicitud de Almacen")]
        SolicitudAlmacen = 1,//disminucion
        [XafDisplayNameAttribute("Compra por Caja Chica")]
        SolicitudCajaChica = 2, //aumento
        [XafDisplayNameAttribute("Compra via UACI")]
        SolicitudUACI = 3,
        [XafDisplayNameAttribute("Bodega de lubricantes")]
        Solicitudlubricante = 4
    }
}
