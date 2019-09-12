using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GS.Core.Database.Repository.Implementation
{
    public class AlbumRepository:Repository<Albums>,IAlbumRepository
    {
        public AlbumRepository(GsDbContext context):base(context)
        {
        }

        public async Task<Albums> GetAlbumAsync(int id,bool includeTracks = false)
        {
            IQueryable<Albums> query = FindAll();

            if (includeTracks)
            {
                query = query.Include(a => a.Tracks);
            }

            //Query it
            query = query.Where(a => a.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Albums>> GetAlbumsAsync(bool includeTracks = false, int pageIndex = 1, int pageSize = 10)
        {
            return await FindAll()
                .Include(c => c.Tracks)                
                .OrderBy(c => c.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public Albums GetAlbum(int id, bool includeTracks = false)
        {
            //_context.Database.ExecuteSqlCommand("WAITFOR DELAY '00:00:02';");
            IQueryable<Albums> query = FindAll();
            if (includeTracks)
            {
                query = query.Include(genre => genre.Tracks);
            }
            query = query.Where(g => g.Id == id);
            return query.SingleOrDefault();
        }

        public IEnumerable<Albums> GetAlbums(bool includeTracks = false, int pageIndex = 1, int pageSize = 5)
        {
            IQueryable<Albums> query = FindAll();
            if (includeTracks)
            {
                query = query.Include(artist => artist.Tracks);
            }
            query.OrderBy(a => a.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return query.ToList();
        }
    }
}
