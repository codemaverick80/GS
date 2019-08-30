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
        public AlbumRepository(SGDbContext context):base(context)
        {
        }

        public async Task<Albums> GetAlbumByIdAsync(int id,bool includeTracks = false)
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

        public async Task<IEnumerable<Albums>> GetAlbumsWithTracksAsync(bool includeTracks = false, int pageIndex = 1, int pageSize = 10)
        {
            return await FindAll()
                .Include(c => c.Tracks)                
                .OrderBy(c => c.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        //public async Task<IEnumerable<Albums>> GetAllAlbumsAsync(bool includeTracks = false, int pageIndex = 1, int pageSize = 10)
        //{
        //    IQueryable<Albums> query = FindAll();
        //    if (includeTracks)
        //    {
        //        query = query.Include(a => a.Tracks);
        //    }
        //    //Query It
        //    query.OrderBy(a => a.Id).Skip((pageIndex-1) * pageSize).Take(pageSize);

        //    return await query.ToListAsync();           
        //}
    }
}
