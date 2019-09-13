using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers.V2
{
    [ApiController] /* Very important for api Versioning */
    [ApiVersion("2.0")]
    //[Route("api/values")]//Query String-Based Versioning (http://localhost:6600/api/Values?v=2.0 OR http://localhost:6600/api/Values?api-version=2.0
   [Route("api/{v:apiVersion}/Values")] //URL-Based Versioning (http://localhost:6600/api/2.0/Values)
    public class ValuesV2Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[]
            {
                "Value1 from version 2.0",
                "Values2 from version 2.0"
            };
        }
    }
}