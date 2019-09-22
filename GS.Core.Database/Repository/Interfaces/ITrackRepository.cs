using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Core.Database.Entities;

namespace GS.Core.Database.Repository.Interfaces
{
    public interface ITrackRepository:IRepository<Tracks>,IDisposable
    {
        /// <summary>
        /// Returns a single matching track Asynchronously.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Task<Tracks> GetTrackAsync(int id);
      
        /// <summary>
        ///  Returns list of albums Asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Tracks>> GetTracksAsync(int albumId);
    }
}