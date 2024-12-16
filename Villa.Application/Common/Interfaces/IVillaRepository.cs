using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Application.Common.Interfaces
{
    public interface IVillaRepository
    {
        IEnumerable<Vila> GetAll(Expression<Func<Vila,bool>> filter=null,string? includeProperties=null);
        Vila Get(Expression<Func<Vila,bool>> filter, string? includeProperties = null);
        void Add(Vila entity);
        void Update(Vila entity);
        void Remove(Vila entity);
        void save();
    }
}
