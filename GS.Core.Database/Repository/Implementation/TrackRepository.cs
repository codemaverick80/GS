using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GS.Core.Database.Repository.Implementation
{
    public class TrackRepository:Repository<Tracks>,ITrackRepository
    {
        public TrackRepository(GsDbContext context) : base(context)
        {
        }
     

        public async Task<Tracks> GetTrackAsync(int id)
        {
            IQueryable<Tracks> query = FindAll();

            //Query It
            var result = query.Where(t => t.Id == id);

            return await result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tracks>> GetTracksAsync(int albumId)
        {
            IQueryable<Tracks> query = FindAll();
            //Query It
            var result = query.Where(t => t.AlbumId==albumId);
            return await result.ToListAsync();
        }
        
        
         
        #region "Disposing"

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    //_context = null;
                }
            }
        }


        #endregion
    }
}