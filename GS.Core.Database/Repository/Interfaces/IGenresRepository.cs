using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Database.Entities;

namespace GS.Core.Database.Repository.Interfaces
{
    public interface IGenresRepository : IRepository<Genres>
    {

        Task<Genres> GetGenresByIdAsync(int id, bool includeArtists = false);
        Task<IEnumerable<Genres>> GetAllGenresAsync(bool includeArtists = false, int pageIndex = 1, int pageSize = 5);

        ///Task<IEnumerable<Genres>> GetAllGenresAsync(bool includeArtists = false, bool includeSubGenres = false);

        //IEnumerable<Genres> GetAllWithSubGenres();
        //IEnumerable<Genres> FindWithSubGenres(Func<Genres, bool> expression);
        
    }
}
