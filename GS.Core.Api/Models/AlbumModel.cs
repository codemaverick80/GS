﻿using System;
using System.Collections.Generic;

namespace GS.Core.Api.Models
{
    public class AlbumsModel
    {
        public long AlbumId { get; set; }
        public string Year { get; set; }
        public string Album { get; set; }
        public string Label { get; set; }
        public string Rating { get; set; }
        public string UserRating { get; set; }
        public string ThumbnailS { get; set; }
        public string ThumbnailM { get; set; }
        public string ThumbnailL { get; set; }
        public string AlbumUrl { get; set; }

        public ICollection<TracksModel> Tracks { get; set; }
    }
}
