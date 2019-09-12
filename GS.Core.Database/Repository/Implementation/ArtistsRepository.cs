using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GS.Core.Database.Repository.Implementation
{
    public class ArtistsRepository:Repository<Artists>,IArtistRepository
    {
        public ArtistsRepository(GsDbContext context):base(context)
        {
        }

        public async Task<IEnumerable<Artists>> GetArtistsAsync(bool includeAlbums = false, int pageIndex = 1, int pageSize = 5)
        { 
            //_context.Database.ExecuteSqlCommand("WAITFOR DELAY '00:00:02';");
            IQueryable<Artists> query = FindAll().Include(a => a.ArtistBasicInfo);

            if (includeAlbums)
            {
                query = query.Include(artist => artist.Albums);
            }
            query.OrderBy(a => a.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<Artists> GetArtistAsync(int id, bool includeAlbums = false)
        {
            //_context.Database.ExecuteSqlCommand("WAITFOR DELAY '00:00:02';");
            IQueryable<Artists> query = FindAll().Include(a=>a.ArtistBasicInfo);
            
            if (includeAlbums)
            {
                query = query.Include(artist => artist.Albums);
            }
            // Query It
            query = query.Where(c => c.Id == id);

            ////If record not found, return empty Artists() object. this might be helpfull in some cases
            //return await query.DefaultIfEmpty(new Artists()).FirstOrDefaultAsync();
            return await query.FirstOrDefaultAsync();
            
        }

        public Artists GetArtist(int id, bool includeAlbums = false)
        {
           // _context.Database.ExecuteSqlCommand("WAITFOR DELAY '00:00:02';");
            IQueryable<Artists> query = FindAll();
            if (includeAlbums)
            {
                query = query.Include(genre => genre.Albums);
            }
            query = query.Where(g => g.Id == id);
            return query.SingleOrDefault();
        }

        public IEnumerable<Artists> GetArtists(bool includeAlbums = false, int pageIndex = 1, int pageSize = 5)
        {
           // _context.Database.ExecuteSqlCommand("WAITFOR DELAY '00:00:02';");
            IQueryable<Artists> query = FindAll().Include(a => a.ArtistBasicInfo);
            if (includeAlbums)
            {
                query = query.Include(artist => artist.Albums);
            }
            query.OrderBy(a => a.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return query.ToList();
        }

        
        
        
        //public async Task<IEnumerable<Artists>> GetArtistsWithAlbumsAsync(int pageIndex=1, int pageSize=10)
        //{
        //    return await FindAll()
        //        .Include(c => c.Albums)
        //        .Include(c=>c.ArtistBasicInfo)
        //        .OrderBy(c => c.Id)
        //        .Skip((pageIndex - 1) * pageSize)
        //        .Take(pageSize)                
        //        .ToListAsync();            
        //}
        
    }
}
