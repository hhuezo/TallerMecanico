using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;

namespace TallerMecanico.Module.BusinessObjects
{
    public enum EstadoSolicitud
    {
        
        NoAplica = 0,
        [XafDisplayNameAttribute("Ingresada")]
        Ingresada = 1,
        [XafDisplayNameAttribute("Enviada")]
        Enviada = 2,
        [XafDisplayNameAttribute("Autorizada")]
        Autorizada = 3,
        [XafDisplayNameAttribute("Diagnostico Realizado")]
        DiagnosticoRealizado = 4,
        [XafDisplayNameAttribute("Obtencion de repuestos Almacen")]
        ObtencionAlmacen = 5,
        [XafDisplayNameAttribute("Obtencion de repuestos Caja Chica")]
        ObtencionCajaChica = 6,
        [XafDisplayNameAttribute("Obtencion de repuestos via UACI")]
        ObtencionUACI = 7,
        [XafDisplayNameAttribute("En reparacion")]
        Reparacion = 8,
        [XafDisplayNameAttribute("Finalizada")]
        Finalizada = 9,
        [XafDisplayNameAttribute("Anulada")]
        Anulada = 10,
    }
}
