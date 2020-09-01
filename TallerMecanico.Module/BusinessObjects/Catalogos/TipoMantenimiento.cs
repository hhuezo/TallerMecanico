using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;

namespace TallerMecanico.Module.BusinessObjects
{
    public enum TipoMantenimiento
    {
        //[XafDisplayNameAttribute("N/A")]
         Ninguno = 0,
        [XafDisplayNameAttribute("Mantenimiento Preventivo")]
         Preventivo = 1,
        [XafDisplayNameAttribute("Mantenimiento Correctivo")]
        Correctivo = 2, 
        [XafDisplayNameAttribute("Solicitud de Servicio")]
        Servicio = 3, 
    }
}
