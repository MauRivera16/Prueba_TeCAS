using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Models
{
    public class ModeloPadre
    {
        public CuentasAhorro cuenta { get; set; }

        public IEnumerable<SelectListItem> ListaClientes { get; set; }

    }
}
