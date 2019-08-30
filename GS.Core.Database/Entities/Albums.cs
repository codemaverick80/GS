using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public class Albums
    {
        public Albums()
        {
            Tracks = new HashSet<Tracks>();
        }

        public long Id { get; set; }
        public string Albumid { get; set; }
        public long ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Year { get; set; }
        public string Album { get; set; }
        public string Label { get; set; }
        public string Rating { get; set; }
        public string UserRating { get; set; }
        public string ThumbnailS { get; set; }
        public string ThumbnailM { get; set; }
        public string ThumbnailL { get; set; }
        public string AlbumUrl { get; set; }

        public virtual  Artists Artist { get; set; }
        public virtual ICollection<Tracks> Tracks { get; set; }
    }
}
