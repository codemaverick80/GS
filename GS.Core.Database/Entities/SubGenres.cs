using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public class SubGenres
    {
        public SubGenres()
        {
            GenreStyles = new HashSet<GenreStyles>();
        }

        public long Id { get; set; }
        public string Subgenreid { get; set; }
        public long GenreId { get; set; }
        public string SubGenre { get; set; }
        public string Description { get; set; }

        public virtual Genres Genre { get; set; }
        public virtual ICollection<GenreStyles> GenreStyles { get; set; }
    }
}
