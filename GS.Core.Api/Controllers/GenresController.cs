using System.Threading.Tasks;
using AutoMapper;
using GS.Core.Api.Models;
using GS.Core.Api.Models.Responses;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace GS.Core.Api.Controllers
{
    [Route("api/genres/")]
    public class GenresController : ControllerBase
    {

        private readonly IGenresRepository _genresRepository;
        private readonly IMapper _mapper;
        public GenresController(IGenresRepository genresRepository, IMapper mapper)
        {
            _genresRepository = genresRepository;
            _mapper = mapper;
        }

        // GET: api/artist/get
        [HttpGet("get")]
        public async Task<ActionResult<GenreGetResponse[]>> Get()
        {
            var result =await _genresRepository.GetGenresAsync(false, 1, 5);
            return _mapper.Map<GenreGetResponse[]>(result);
        }

        //// GET api/genres/get/109
        [HttpGet("get/{id}")]
        public async Task<ActionResult<GenreGetResponse>> Get(int id)
        {
            
            var result = await _genresRepository.GetGenreAsync(id, true);
            if (result == null) return NotFound();
            return _mapper.Map<GenreGetResponse>(result);
        }
        



        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
