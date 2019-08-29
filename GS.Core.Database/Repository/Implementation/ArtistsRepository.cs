﻿using System;
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
        public ArtistsRepository(SGDbContext context):base(context)
        {
        }

        public async Task<IEnumerable<Artists>> GetAllArtistAsync(bool includeAlbums = false)
        {
            IQueryable<Artists> query = _context.Artists.Include(a => a.ArtistBasicInfo);

            if (includeAlbums)
            {
                query = query
                  .Include(artist => artist.Albums.Select(album => album.Album));
            }

            // Order It
            query = query.OrderByDescending(artist => artist.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Artists> GetArtistAsync(int id, bool includeAlbums = false)
        {
            IQueryable<Artists> query = _context.Artists.Include(a=>a.ArtistBasicInfo);


            if (includeAlbums)
            {
                query = query.Include(artist => artist.Albums.Select(album => album.Album));
            }

            // Query It
            query = query.Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Artists>> GetArtistsWithAlbumsAsync(int pageIndex=1, int pageSize=10)
        {
            return await _context.Artists
                .Include(c => c.Albums)
                .Include(c=>c.ArtistBasicInfo)
                .OrderBy(c => c.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)                
                .ToListAsync();            
        }
        
    }
}
