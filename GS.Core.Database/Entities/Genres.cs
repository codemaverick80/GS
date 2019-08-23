using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public partial class Genres
    {
        public Genres()
        {
            Artists = new HashSet<Artists>();
            SubGenres = new HashSet<SubGenres>();
        }

        public long Id { get; set; }
        public string Genreid { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Artists> Artists { get; set; }
        public virtual ICollection<SubGenres> SubGenres { get; set; }
    }
}
