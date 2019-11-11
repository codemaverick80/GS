using AutoMapper;
using GS.Core.Api.Contracts.V1;
using GS.Core.Api.Contracts.V1.Requests;
using GS.Core.Api.Contracts.V1.Responses;
using GS.Core.Database.Entities;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace GS.Core.Api.Controllers
{
    [ApiController]
   // [Route("api/v{version:apiVersion}/genres/")]
   //[Route(ApiRoutes.Genre.GetAll)]
    [ApiVersion("1.0")]
    public class GenresController : ControllerBase
    {

        private readonly IGenresRepository _genresRepository;
        private readonly IMapper _mapper;
        public GenresController(IGenresRepository genresRepository, IMapper mapper)
        {
            _genresRepository = genresRepository;
            _mapper = mapper;
        }
       
        [HttpGet(ApiRoutes.Genre.GetAll)]
        public async Task<ActionResult<GenreGetResponse[]>> Get()
        {
            var result = await _genresRepository.GetGenresAsync(false, 1, 5);
            //return _mapper.Map<GenreGetResponse[]>(result);
            return Ok(_mapper.Map<GenreGetResponse[]>(result));
;        }
        
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet(ApiRoutes.Genre.Get,Name = "Get")]
        public async Task<ActionResult<GenreGetResponse>> Get(int id)
        {
            var result = await _genresRepository.GetGenreAsync(id, true);
            if (result == null) return NotFound();

           // return _mapper.Map<GenreGetResponse>(result);
            return Ok(_mapper.Map<GenreGetResponse>(result));
        }

        [HttpPost(ApiRoutes.Genre.Create)]
        public async Task<ActionResult<GenreGetResponse>> Post([FromBody]GenreCreateRequest createRequest)
        {

            var genreEntity = _mapper.Map<Genres>(createRequest);
            _genresRepository.Add(genreEntity);
           await _genresRepository.SaveChangesAsync();
            
            var genreToReturn = _mapper.Map<GenreGetResponse>(genreEntity);

            ////return CreatedAtRoute("Get", new {id=genreToReturn.Id},genreToReturn);
            
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Genre.Get.Replace("{id}", genreToReturn.Id.ToString());
            return Created(locationUrl, genreToReturn);
        }

       
    }
}
