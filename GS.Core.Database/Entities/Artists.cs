using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public partial class Artists
    {
        public Artists()
        {
            Albums = new HashSet<Albums>();
        }

        public long Id { get; set; }
        public string Artistid { get; set; }
        public long GenreId { get; set; }
        public string Artist { get; set; }
        public string YearsActive { get; set; }
        public string Biography { get; set; }
        public string SmallThumbnail { get; set; }
        public string BigThumbnail { get; set; }

        public virtual Genres Genre { get; set; }
        public virtual ArtistBasicInfo ArtistBasicInfo { get; set; }
        public virtual ICollection<Albums> Albums { get; set; }
    }
}
