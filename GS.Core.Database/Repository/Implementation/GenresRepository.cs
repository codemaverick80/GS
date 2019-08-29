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
        public GenresRepository(SGDbContext context):base(context)
        {

        }       

        public async Task<IEnumerable<Genres>> GetAllGenresAsync(bool includeArtists = false)
        {
            IQueryable<Genres> query = FindAll();

            if (includeArtists)
            {
                query = query.Include(genres => genres.Artists);
            }

            return await query.OrderBy(g => g.Id).ToListAsync();
        }



        public async Task<IEnumerable<Genres>> GetAllGenresAsync(bool includeArtists = false, bool includeSubGenres = false)
        {
            IQueryable<Genres> query = FindAll();
            if (includeArtists)
            {
                query = query.Include(g => g.Artists);
            }
            if (includeSubGenres)
            {
                query = query.Include(g => g.SubGenres);
            }

            return await query.OrderBy(g => g.Id).ToListAsync();
        }
        


        public async Task<Genres> GetGenresByIdAsync(int id, bool includeArtists = false)
        {
            IQueryable<Genres> query = FindAll();
            if (includeArtists)
            {
                query = query.Include(genre => genre.Artists);
            }

            // Query It
            query = query.Where(g => g.Id == id);

            return await query.SingleOrDefaultAsync();
        }

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



    }
}
