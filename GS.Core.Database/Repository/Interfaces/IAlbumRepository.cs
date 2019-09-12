using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Core.Database.Entities;

namespace GS.Core.Database.Repository.Interfaces
{
    public interface IAlbumRepository:IRepository<Albums>
    {
        /// <summary>
        /// Returns a single matching album Asynchronously.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="includeTracks">default false</param>
        /// <returns></returns>
        Task<Albums> GetAlbumAsync(int id, bool includeTracks = false);
      
       /// <summary>
       ///  Returns list of albums Asynchronously.
       /// </summary>
       /// <param name="includeTracks">default false</param>
       /// <param name="pageIndex">default 1</param>
       /// <param name="pageSize">default 5</param>
       /// <returns></returns>
       Task<IEnumerable<Albums>> GetAlbumsAsync(bool includeTracks = false, int pageIndex = 1, int pageSize = 10);
        
        /// <summary>
        /// Returns a single matching albums Synchronously.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="includeAlbums">default false</param>
        /// <returns></returns>
        Albums GetAlbum(int id, bool includeAlbums = false);
        /// <summary>
        ///  Returns list of albums Synchronously.
        /// </summary>
        /// <param name="includeTracks">default false</param>
        /// <param name="pageIndex">default 1</param>
        /// <param name="pageSize">default 5</param>
        /// <returns></returns>
        IEnumerable<Albums> GetAlbums(bool includeTracks = false, int pageIndex = 1, int pageSize = 5);
    }
}
