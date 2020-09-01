using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;

namespace TallerMecanico.Module.BusinessObjects
{
    public enum NivelCombustible
    {
        Ninguno=0,
        [XafDisplayNameAttribute("1/4 de Tanque")]
        Cuarto = 1,//disminucion
        [XafDisplayNameAttribute("1/2 Tanque")]
        Medio = 2, //aumento
        [XafDisplayNameAttribute("3/4 de Tanque")]
        TresCuartos = 3,
        [XafDisplayNameAttribute("Tanque Lleno")]
        Lleno = 4, //ajuste



    }
}
