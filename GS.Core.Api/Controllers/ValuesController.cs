using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Api.Services.LoggerService;
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
        private readonly IArtistRepository _artistRepo;
        private ILoggerManager _logger;

        public ValuesController(IGenresRepository genresRepository
            ,IArtistRepository artistRepository
            ,ILoggerManager logger)
        {
            _genresRepo = genresRepository;
            _artistRepo = artistRepository;
            _logger = logger;
        }
        // GET api/values
        //[HttpGet]
        //public List<ActionResult<Genres>> Get()
        //{
        //    //var genre = _genresRepo.GetAll().ToList();

        //    //var g = await _genresRepo.GetAllAsync();
        //    var find = _genresRepo.FindWithSubGenres(gen => gen.Id == 12).ToList(); 
        //    var allwithSubgenres = _genresRepo.GetAllWithSubGenres().ToList();
        //    return Ok(find);

        //    //return find;
        //}

        [HttpGet]
        public  ActionResult<IEnumerable<string>> Get()
        {
            //try
            //{
            //    var genres =await _genresRepo.GetGenresByIdAsync(12,true);

            //    //var genre = _genresRepo.GetAll().ToList();
            //    ////var result = await  _genresRepo.GetAllAsync();
            //    ////var find = _genresRepo.FindWithSubGenres(gen => gen.Id == 12).ToList();              

            //   // return Ok(new string[] { "value1", "value2" });
            //    return Ok(genres);
            //}
            //catch (Exception ex)
            //{
            //    // TODO Add Logging
            //    return null;
            //}

            _logger.LogInfo("Fetching all the Students from the storage");

            throw new Exception("Exception while fetching all the students from the storage.");

            return Ok();
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
