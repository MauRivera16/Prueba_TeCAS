using Microsoft.EntityFrameworkCore;
using Prueba_TeCAS.Data;
using Prueba_TeCAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Repository
{
    public class CuentaAhorroRepository : Repository<CuentasAhorro>, ICuentaAhorroRepository
    {
        private readonly ApplicationDbContext cx;
        public CuentaAhorroRepository(ApplicationDbContext _cx) : base(_cx)
        {
            cx = _cx;
        }
        public IEnumerable<CuentasAhorro> GetCuentasDetail()
        {
            DbSet<CuentasAhorro> referencia = cx.Cuentasahorro;
            return referencia.Include("ClientObj").ToList();
        }

        public void Update(CuentasAhorro cuentas)
        {
            CuentasAhorro cuentaFromDb = cx.Cuentasahorro.FirstOrDefault(S => S.ID == cuentas.ID);
            cuentaFromDb.Cliente_id = cuentas.Cliente_id;
            cuentaFromDb.Saldo = cuentas.Saldo;
        }
    }
}
