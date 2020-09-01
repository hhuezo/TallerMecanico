using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;

namespace TallerMecanico.Module.BusinessObjects
{
    public enum TipoSolicitud
    {
        [XafDisplayNameAttribute("Solicitud de Reparacion")]
        SolicitudTaller = 0,
        [XafDisplayNameAttribute("Solicitud Bodega Lubricantes")]
        SolicitudLubricantes = 1,

    }
}
