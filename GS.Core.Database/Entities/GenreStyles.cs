using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public class GenreStyles
    {
        public long Id { get; set; }
        public string Tag { get; set; }
        public long SubGenreId { get; set; }
        public string Style { get; set; }
        public string Description { get; set; }

        public virtual SubGenres SubGenre { get; set; }
    }
}
