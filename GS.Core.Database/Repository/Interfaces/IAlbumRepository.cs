using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Core.Database.Entities;

namespace GS.Core.Database.Repository.Interfaces
{
    public interface IAlbumRepository:IRepository<Albums>
    {
        Task<Albums> GetAlbumByIdAsync(int id, bool includeTracks = false);
       // Task<IEnumerable<Albums>> GetAllAlbumsAsync(bool includeTracks = false, int pageIndex = 1, int pageSize = 10);
        Task<IEnumerable<Albums>> GetAlbumsWithTracksAsync(bool includeTracks = false, int pageIndex = 1, int pageSize = 10);
    }
}
