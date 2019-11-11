using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers.V2
{
    [ApiController] /* Very important for api Versioning */
    //[Route("api/values")]//Query String-Based Versioning (http://localhost:6600/api/Values?v=2.0 OR http://localhost:6600/api/Values?api-version=2.0
    [Route("api/v{version:apiVersion}/values")] //URL-Based Versioning (http://localhost:6600/api/2.0/Values)
    [ApiVersion("2.0")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[]
            {
                "Welcome to Api Versioning",
                "Api version 2.0"
            };
        }
    }
}