using System;
using System.Collections.Generic;

namespace GS.Core.Api.Models
{
    public class GenresModel
    {
        public long Id { get; set; }
        public string Genreid { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public ICollection<ArtistsModel> Artists { get; set; }
    }
}
