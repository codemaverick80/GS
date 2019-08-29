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


        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {           
            return _context.Set<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
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

        public void Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }



        
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }




        protected void Save()
        {
            _context.SaveChanges();
        }
                       
    }


    public class GenRepository<T> : IGenRepository<T> where T : class
    {

        protected readonly SGDbContext _context;

        public GenRepository(SGDbContext context)
        {
            _context = context;
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddReange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }


        /*
         * GetAll() methods returns IEnumerable<T>, does not return IQueryable<T>.
         * This is the key to remember that our repositories should not return IQueryable
         * becasue this can give the wrong impression to the upper layers like services or controllers that
         * they can use this IQueryable to build queries which is completely against the idea of
         * using a repository in the first place.
         *
         * Our repositories should encapsulate our queries so we do not repeat them again and again.
         *
         * 
         */
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }

}
