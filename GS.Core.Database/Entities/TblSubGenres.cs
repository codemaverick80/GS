using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public partial class TblSubGenres
    {
        public TblSubGenres()
        {
            TblGenreStyles = new HashSet<TblGenreStyles>();
        }

        public long Id { get; set; }
        public string Subgenreid { get; set; }
        public long GenreId { get; set; }
        public string SubGenre { get; set; }
        public string Description { get; set; }

        public virtual TblGenres Genre { get; set; }
        public virtual ICollection<TblGenreStyles> TblGenreStyles { get; set; }
    }
}
