using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presupuesto.Module.BusinessObjects.Configuracion
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequiereInicializacionGeneradorDeCodigos : Attribute
    {
        // Fields...
        private string _id;
        /// <summary>
        /// Initializes a new instance of the RequiereInicializacionGeneradorDeCodigos class.
        /// </summary>
        /// <param name="id"></param>
        public RequiereInicializacionGeneradorDeCodigos(string id)
        {
            _id = id;
        }
        public string id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

    }
}
