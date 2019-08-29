using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GS.Core.Database.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);

        
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);


        int Count(Func<T, bool> predicate);
        
    }


    public interface IGenRepository<T> where T : class
    {

        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddReange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
 }
