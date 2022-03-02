using Microsoft.AspNetCore.Mvc.Rendering;
using Prueba_TeCAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Repository
{
    public interface IClientesRepository :IRepository<Clientes>
    {
        void Update(Clientes cli);
        IEnumerable<SelectListItem> GetListaCliente();
    }
}
