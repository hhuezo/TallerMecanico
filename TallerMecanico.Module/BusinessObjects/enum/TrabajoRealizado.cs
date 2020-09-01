using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;

namespace TallerMecanico.Module.BusinessObjects
{
    public enum TrabajoRealizado
    {
        [XafDisplayNameAttribute("CAMBIO DE FILTRO DE ACEITE")]
        FILTROACEITE = 0,
        [XafDisplayNameAttribute("CAMBIO DE FILTRO DE AIRE")]
        FILTROAIRE = 1,
        [XafDisplayNameAttribute("CAMBIO DE FILTRO DE COMBUSTIBLE")]
        FILTROCOMBUSTIBLE = 2,
        [XafDisplayNameAttribute("CAMBIO DE BUJIAS DE ENCENDIDO")]
        CAMBIOBUJIAS = 3,
        [XafDisplayNameAttribute("CAMBIO DE ACEITE DE MOTOR")]
        CAMBIOACEITE = 4,
        [XafDisplayNameAttribute("REVISION DE SISTEMA DE FRENOS")]
        SISTEMAFRENOS = 5,
        [XafDisplayNameAttribute("REVISION DE NIVELES DE ACEITE Y LIQUIDOS")]
        NIVELELACEITE = 6,
        [XafDisplayNameAttribute("REVISION DE PUESTA A TIEMPO DE MOTOR")]
        PUESTAATIEMPO = 7,
        [XafDisplayNameAttribute("CAMBIO DE KIT DE DISTRIBUCION")]
        KITDISTRIBUCION = 8,
        [XafDisplayNameAttribute("REPARACION DE SISTEMA DE FRENOS")]
        REPARACIONFRENOS = 9,
        [XafDisplayNameAttribute("REPARACION DE SISTEMA DE DIRECCION Y SUSPENSION ")]
        REPARACIONSISTEMADIRECCION = 10,
        [XafDisplayNameAttribute("REPARACION DE SISTEMA ELECTRICO")]
        REPARACIONSISTEMAELECTRICO = 11,
        [XafDisplayNameAttribute("REPARACION DE SISTEMA DE EMBRAGUE")]
        REPARACIONSISTEMAEMBRAGUE = 12,
        [XafDisplayNameAttribute("REPARACION DE ESCAPE")]
        REPARACIONESCAPE = 13,
        [XafDisplayNameAttribute("REPARACION DE CARROCERIA")]
        REPARACIONCARROCERIA = 14,
        [XafDisplayNameAttribute("REPARACION / AJUSTE DE MOTOR")]
        AJUSTEMOTOR = 15,
        [XafDisplayNameAttribute("REPARACION DE SISTEMA DE ENFRIAMIENTO")]
        SISTEMAENFRIAMIENTO = 16,
        [XafDisplayNameAttribute("NO APLICA")]
        NOAPLICA = 17


      


    }
}
