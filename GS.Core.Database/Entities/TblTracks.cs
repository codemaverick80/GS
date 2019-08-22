﻿using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public partial class TblTracks
    {
        public int Id { get; set; }
        public string Trackid { get; set; }
        public long AlbumId { get; set; }
        public string Title { get; set; }
        public string Composer { get; set; }
        public string Performer { get; set; }
        public string Featuring { get; set; }
        public string Duration { get; set; }

        public virtual TblAlbums Album { get; set; }
    }
}