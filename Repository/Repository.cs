using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext ctx;
        public DbSet<T> dbset;
        public Repository(DbContext _ctx)
        {
            ctx = _ctx;
            dbset = ctx.Set<T>();
        }
        public void Add(T registro)
        {
            dbset.Add(registro);
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void remove(T registro)
        {
            dbset.Remove(registro);
        }

        public void remove(int id)
        {
            dbset.Remove(dbset.Find(id));
        }
    }
}
