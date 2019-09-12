using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Database.Entities;

namespace GS.Core.Database.Repository.Interfaces
{
    public interface IGenresRepository : IRepository<Genres>, IDisposable
    {
        /// <summary>
        /// Returns a single matching genre Asynchronously.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="includeArtists">default false</param>
        /// <returns></returns>
        Task<Genres> GetGenreAsync(int id, bool includeArtists = false);
        /// <summary>
        ///  Returns list of genres Asynchronously.
        /// </summary>
        /// <param name="includeArtists">default false</param>
        /// <param name="pageIndex">default 1</param>
        /// <param name="pageSize">default 5</param>
        /// <returns></returns>
        Task<IEnumerable<Genres>> GetGenresAsync(bool includeArtists = false, int pageIndex = 1, int pageSize = 5);

        
        /// <summary>
        /// Returns a single matching genre Synchronously.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="includeArtists">default false</param>
        /// <returns></returns>
        Genres GetGenre(int id, bool includeArtists = false);
        /// <summary>
        ///  Returns list of genre Synchronously.
        /// </summary>
        /// <param name="includeArtists">default false</param>
        /// <param name="pageIndex">default 1</param>
        /// <param name="pageSize">default 5</param>
        /// <returns></returns>
        IEnumerable<Genres> GetGenres(bool includeArtists = false, int pageIndex = 1, int pageSize = 5);
        
        
        
        
    }
}
