using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Repository
{
    public interface IUnitOfWork
    {
        public IClientesRepository CRepo { get; set; }
        public ICuentaAhorroRepository CueRepo { get; set; }
        void save();
    }
}
