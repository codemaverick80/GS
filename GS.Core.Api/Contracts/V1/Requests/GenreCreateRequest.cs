using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS.Core.Api.Contracts.V1.Requests
{
    public class GenreCreateRequest
    {
        public long Id { get; set; }
        public string GenreName { get; set; }
        public string Tag { get; set; } = "GRDEMOGEN0";
        public string Description { get; set; }
    }
}
