using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public partial class TblGenres
    {
        public TblGenres()
        {
            TblArtists = new HashSet<TblArtists>();
            TblSubGenres = new HashSet<TblSubGenres>();
        }

        public long Id { get; set; }
        public string Genreid { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblArtists> TblArtists { get; set; }
        public virtual ICollection<TblSubGenres> TblSubGenres { get; set; }
    }
}
