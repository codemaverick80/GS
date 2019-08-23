using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GS.Core.Database.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SGDbContext _context;

        public Repository(SGDbContext context)
        {
            _context = context;
        }

        protected void Save()
        {
            _context.SaveChanges();
        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<T> FindAsync(Func<T, bool> predicate)
        {

            return await _context.Set<T>().FindAsync(predicate);

        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }


        public async Task<T[]> GetAllAsync()
        {
            IQueryable<T> query = _context.Set<T>();
            return await query.ToArrayAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }



    }
}
