using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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


        public IQueryable<T> FindAll()
        {           
            return  _context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public void Add(T entity)
        {
            _context.Add(entity);           
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange();           
        }

       
        public void Remove(T entity)
        {
            _context.Remove(entity);            
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);            
        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }
        
        /// <summary>
        /// Returns true only if at least one row was changed.
        /// </summary>
        /// <returns></returns>
        //public async Task<bool> SaveChangesAsync()
        //{
            
        //   return( await _context.SaveChangesAsync())>0;
        //}

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }

}
