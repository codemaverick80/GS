using AutoMapper;
using GS.Core.Api.Models;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers
{
    [Route("api/Synchronousgenres/")]

    public class SynchronousGenresController : ControllerBase
    {
        private readonly IGenresRepository _genresRepository;
        private readonly IMapper _mapper;
        public SynchronousGenresController(IGenresRepository genresRepository, IMapper mapper)
        {
            _genresRepository = genresRepository;
            _mapper = mapper;
        }
        
        
        // GET api/values/5
        [HttpGet("get/{genre_id}")]
        public ActionResult<GenresModel> Get(int genre_id)
        {
            var result =  _genresRepository.GetGenre(genre_id, true);
            if (result == null) return NotFound();
            return _mapper.Map<GenresModel>(result);
        }
    }
}