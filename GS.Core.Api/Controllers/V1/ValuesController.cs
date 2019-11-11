using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers.V1
{
    // #region "Query String-Based versioning"
    //Endpoint: http://localhost:6600/api/Values?v=1.0   OR
    //Endpoint: http://localhost:6600/api/Values?api-version=1.0
   
    [ApiController] /* Very important for api Versioning */
   // [Route("api/values")]
   [Route("api/v{version:apiVersion}/values")] //URL-Based Versioning (http://localhost:6600/api/2.0/Values)
    [ApiVersion("1.0")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[]
            {
            "Welcome to Api Versioning",
            "Api version 1.0" 
            };
        }
    }
    
//    #endregion
    
    
    #region "URL-Based Versioning"
//    //Endpoint: http://localhost:6600/api/2.0/Values
//    [ApiController] /* Very important for api Versioning */
//    [ApiVersion("1.0")]
//    [Route("api/{v:apiVersion}/Values")] 
//    public class ValuesV1Controller : ControllerBase
//    {
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[]
//            {
//                "Welcome to Api Versioning",
//                "Api version 1.0"
//            };
//        }
//    }
    
    #endregion
    
}