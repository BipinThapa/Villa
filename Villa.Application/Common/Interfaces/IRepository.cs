using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Application.Common.Interfaces
{
    public interface IRepository<T> where T:class
    {
        //dont put update and save function bcoz, update may different with different business logic and save
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);   
    }
}
