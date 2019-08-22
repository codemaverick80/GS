using System;
using System.Collections.Generic;

namespace GS.Core.Database.Entities
{
    public partial class ArtistBasicInfo
    {
        public long ArtistId { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string Aka { get; set; }

        public virtual Artists Artist { get; set; }
    }
}
