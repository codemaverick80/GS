using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers.V1
{
    [ApiController] /* Very important for api Versioning */
    [ApiVersion("1.0", Deprecated = true)]
    //[Route("api/values")]//Query String-Based Versioning
    [Route("api/{v:apiVersion}/Values")] //URL-Based Versioning
     public class ValuesV1Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[]
            {
            "Value1 from version 1.0",
            "Values2 from version 1.0"
            };
        }
    }
}