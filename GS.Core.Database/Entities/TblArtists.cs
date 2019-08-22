using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public partial class TblArtists
    {
        public TblArtists()
        {
            TblAlbums = new HashSet<TblAlbums>();
        }

        public long Id { get; set; }
        public string Artistid { get; set; }
        public long GenreId { get; set; }
        public string Artist { get; set; }
        public string YearsActive { get; set; }
        public string Biography { get; set; }
        public string SmallThumbnail { get; set; }
        public string BigThumbnail { get; set; }

        public virtual TblGenres Genre { get; set; }
        public virtual TblArtistBasicInfo TblArtistBasicInfo { get; set; }
        public virtual ICollection<TblAlbums> TblAlbums { get; set; }
    }
}
