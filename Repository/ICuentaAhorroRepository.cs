using Prueba_TeCAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Repository
{
    public interface ICuentaAhorroRepository: IRepository<CuentasAhorro>
    {
        void Update(CuentasAhorro cuentas);

        IEnumerable<CuentasAhorro> GetCuentasDetail();
    }
}
