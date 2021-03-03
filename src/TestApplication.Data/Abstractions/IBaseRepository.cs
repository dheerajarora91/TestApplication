using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestApplication.Data.Abstractions
{
    public interface IBaseRepository<T>
    {
        T Add(T entity);
        Task<int> SaveChangesAsync();
    }
}
