using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public partial class Genres
    {
        public Genres()
        {
            TblArtists = new HashSet<Artists>();
            TblSubGenres = new HashSet<TblSubGenres>();
        }

        public long Id { get; set; }
        public string Genreid { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Artists> TblArtists { get; set; }
        public virtual ICollection<TblSubGenres> TblSubGenres { get; set; }
    }
}
