using Prueba_TeCAS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IClientesRepository CRepo { get; set; }
        public ICuentaAhorroRepository CueRepo { get; set; }

        public readonly ApplicationDbContext contexto;
        public UnitOfWork(ApplicationDbContext ctx)
        {
            contexto = ctx;
            CRepo = new ClienteRepository(ctx);
            CueRepo = new CuentaAhorroRepository(ctx);
        }

        public void save()
        {
            contexto.SaveChanges();
        }
    }
}
