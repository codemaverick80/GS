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
    public class GenresRepository: Repository<Genres>, IGenresRepository
    {

        #region "Constructor"

        public GenresRepository(GsDbContext context):base(context)
        {

        }   

        #endregion


        #region "Asynchronous Methods"
        
        public async Task<IEnumerable<Genres>> GetGenresAsync(bool includeArtists = false, int pageIndex = 1, int pageSize = 5)
        {
            IQueryable<Genres> query = FindAll();

            if (includeArtists)
            {
                query = query.Include(genres => genres.Artists);
            }

            //Query It
            query.OrderBy(g=>g.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }
        
        
        public async Task<Genres> GetGenreAsync(int id, bool includeArtists = false)
        {
            //_context.Database.ExecuteSqlCommand("WAITFOR DELAY '00:00:02';");
            IQueryable<Genres> query = FindAll();
            if (includeArtists)
            {
                query = query.Include(genre => genre.Artists);
            }

            // Query It
            query = query.Where(g => g.Id == id);

            return await query.SingleOrDefaultAsync();
        }

        #endregion

        #region "Synchronous Methods"
        public Genres GetGenre(int id, bool includeArtists = false)
        {
            //_context.Database.ExecuteSqlCommand("WAITFOR DELAY '00:00:02';");
            IQueryable<Genres> query = FindAll();
            if (includeArtists)
            {
                query = query.Include(genre => genre.Artists);
            }
            query = query.Where(g => g.Id == id);
            return query.SingleOrDefault();
        }

        public IEnumerable<Genres> GetGenres(bool includeArtists = false, int pageIndex = 1, int pageSize = 5)
        {
            IQueryable<Genres> query = FindAll();
            if (includeArtists)
            {
                query = query.Include(genres => genres.Artists);
            }
            //Query It
            query.OrderBy(g=>g.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return query.ToList();
        }

        #endregion
   
        #region "Disposing"

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    //_context = null;
                }
            }
        }


        #endregion

    }
}


//public async Task<IEnumerable<Genres>> GetAllGenresAsync(bool includeArtists = false, bool includeSubGenres = false)
//{
//    IQueryable<Genres> query = FindAll();
//    if (includeArtists)
//    {
//        query = query.Include(g => g.Artists);
//    }
//    if (includeSubGenres)
//    {
//        query = query.Include(g => g.SubGenres);
//    }

//    return await query.OrderBy(g => g.Id).ToListAsync();
//}


//public IEnumerable<Genres> FindWithSubGenres(Func<Genres, bool> predicate)
//{
//    return _context.Genres
//        .Include(a => a.SubGenres)
//        .Where(predicate).ToList();
//}

//public IEnumerable<Genres> GetAllWithSubGenres()
//{
//    return _context.Genres.Include(a => a.SubGenres);
//}
