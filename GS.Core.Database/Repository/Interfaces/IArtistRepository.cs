using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Core.Database.Entities;

namespace GS.Core.Database.Repository.Interfaces
{
    public interface IArtistRepository:IRepository<Artists>,IDisposable
    {
      /// <summary>
      ///  Returns list of artist Asynchronously.
      /// </summary>
      /// <param name="includeAlbums">default false</param>
      /// <param name="pageIndex">default 1</param>
      /// <param name="pageSize">default 5</param>
      /// <returns></returns>
        Task<IEnumerable<Artists>> GetArtistsAsync(bool includeAlbums = false, int pageIndex = 1, int pageSize = 5);
        
        /// <summary>
        /// Returns a single matching artist Asynchronously.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="includeAlbums">default false</param>
        /// <returns></returns>
        Task<Artists> GetArtistAsync(int id, bool includeAlbums=false);

     
        /// <summary>
        /// Returns a single matching artist Synchronously.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="includeAlbums">default false</param>
        /// <returns></returns>
        Artists GetArtist(int id, bool includeAlbums = false);
        /// <summary>
        ///  Returns list of artist Synchronously.
        /// </summary>
        /// <param name="includeAlbums">default false</param>
        /// <param name="pageIndex">default 1</param>
        /// <param name="pageSize">default 5</param>
        /// <returns></returns>
        IEnumerable<Artists> GetArtists(bool includeAlbums = false, int pageIndex = 1, int pageSize = 5);


    }
}
