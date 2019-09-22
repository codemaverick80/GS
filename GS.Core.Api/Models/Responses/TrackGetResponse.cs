namespace GS.Core.Api.Models.Responses
{
    public class TrackGetResponse
    {
        public int TrackId { get; set; }
        public string Title { get; set; }
        public string Composer { get; set; }
        public string Performer { get; set; }
        public string Featuring { get; set; }
        public string Duration { get; set; }
    }
}