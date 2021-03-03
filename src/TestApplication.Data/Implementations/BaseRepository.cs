using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Data.Abstractions;

namespace TestApplication.Data.Implementations
{
    public abstract class BaseRepository<T>: IBaseRepository<T> where T : class
    {
        protected TestApplicationDbContext context;

        public BaseRepository(TestApplicationDbContext context)
        {
            this.context = context;
        }

        public virtual T Add(T entity)
        {
            return context.Add(entity).Entity;
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
