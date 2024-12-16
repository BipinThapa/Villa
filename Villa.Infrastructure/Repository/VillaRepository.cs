using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Application.Common.Interfaces;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa.Infrastructure.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Vila entity)
        {
            _db.Add(entity);
        }

        public Vila Get(Expression<Func<Vila, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Vila> query = _db.Set<Vila>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!String.IsNullOrEmpty(includeProperties))
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<Vila> GetAll(Expression<Func<Vila, bool>> filter = null, string? includeProperties = null)
        {
            IQueryable<Vila> query = _db.Set<Vila>();
            if (filter!=null)
            {
                query = query.Where(filter);
            }
            if (!String.IsNullOrEmpty(includeProperties))
            {
                foreach (var item in includeProperties .Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }

        public void Remove(Vila entity)
        {
            _db.Remove(entity);
        }

        public void save()
        {
            _db.SaveChanges();
        }

        public void Update(Vila entity)
        {
            _db.Villas.Update(entity);
        }
    }
}
