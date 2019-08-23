using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IGenresRepository _genresRepo;


        public ValuesController(IGenresRepository genresRepository)
        {
            _genresRepo = genresRepository;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var genre = _genresRepo.GetAll().ToList();

            var g = await _genresRepo.GetAllAsync();
            //var subGenres = _context.SubGenres.ToList();
            return Ok(g);

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
