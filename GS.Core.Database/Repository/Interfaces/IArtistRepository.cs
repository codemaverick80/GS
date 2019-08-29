using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Core.Database.Entities;

namespace GS.Core.Database.Repository.Interfaces
{
    public interface IArtistRepository:IRepository<Artists>
    {
        //Task<IEnumerable<Artists>> GetAllArtistAsync();

        Task<IEnumerable<Artists>> GetAllArtistAsync(bool includeAlbums = false);

        Task<Artists> GetArtistByIdAsync(int id, bool includeAlbums=false);

        Task<IEnumerable<Artists>> GetArtistsWithAlbumsAsync(int pageIndex, int pageSize);


    }
}
