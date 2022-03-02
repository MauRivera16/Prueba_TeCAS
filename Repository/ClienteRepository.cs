using Microsoft.AspNetCore.Mvc.Rendering;
using Prueba_TeCAS.Data;
using Prueba_TeCAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Repository
{
    public class ClienteRepository : Repository<Clientes>, IClientesRepository
    {
        private readonly ApplicationDbContext cx;
        public ClienteRepository(ApplicationDbContext _cx): base(_cx)
        {
            cx = _cx;
        }
        public IEnumerable<SelectListItem> GetListaCliente()
        {
            return cx.Clientes.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.ID.ToString()
            });
        }

        public void Update(Clientes cli)
        {
            Clientes clienteDesdeDb = cx.Clientes.FirstOrDefault(s
                => s.ID == cli.ID);
            clienteDesdeDb.Nombre = cli.Nombre;
            clienteDesdeDb.ApellidoP = cli.ApellidoP;
            clienteDesdeDb.ApellidoM = cli.ApellidoM;
            clienteDesdeDb.Genero = cli.Genero;
            clienteDesdeDb.Matricula = cli.Matricula;
        }
    }
}
