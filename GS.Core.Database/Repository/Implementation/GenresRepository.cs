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

        public IEnumerable<Genres> FindWithSubGenres(Func<Genres, bool> predicate)
        {
            return _context.Genres
                .Include(a => a.SubGenres)
                .Where(predicate).ToList();
        }
              

        public IEnumerable<Genres> GetAllWithSubGenres()
        {            
           return _context.Genres.Include(a => a.SubGenres);            
        }
    }
}
