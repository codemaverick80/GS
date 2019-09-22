using System.Collections.Generic;

namespace GS.Core.Api.Models.Responses
{
    public class GenreGetResponse
    {
        public long Id { get; set; }
        public string Tag { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public ICollection<ArtistGetResponse> Artists { get; set; }
    }
}