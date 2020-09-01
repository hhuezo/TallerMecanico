using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;

namespace TallerMecanico.Module.BusinessObjects
{
	public enum  TipoCombustible
	{
         NoAplica = 0,
         [XafDisplayNameAttribute("DIESEL")]
         DIESEL = 1,
        [XafDisplayNameAttribute("GASOLINA")]
         GASOLINA = 2,
       
	}
}
