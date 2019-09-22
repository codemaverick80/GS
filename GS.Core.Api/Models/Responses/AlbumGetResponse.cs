using System.Collections.Generic;

namespace GS.Core.Api.Models.Responses
{
    public class AlbumGetResponse
    {
        public long Id { get; set; }
        public string Tag { get; set; }
        public string ReleaseYear { get; set; }
        public string Album { get; set; }
        public string Label { get; set; }
        public string AlbumUrl { get; set; }
       // public virtual  ArtistsModel Artist { get; set; }
        public ICollection<TrackGetResponse> Tracks { get; set; }
    }
}