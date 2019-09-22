using AutoMapper;
using GS.Core.Api.Models;
using GS.Core.Api.Models.Responses;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers
{
    [Route("api/Synchronousartist/")]
    public class SynchronousArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public SynchronousArtistController(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }
        
        // GET api/values/5
        [HttpGet("get/{id}")]
        public ActionResult<ArtistGetResponse> Get(int id)
        {
            var result =  _artistRepository.GetArtist(id, true);
            if (result == null) return NotFound();
            return _mapper.Map<ArtistGetResponse>(result);
        }
        [HttpGet("get")]
        public ActionResult<ArtistGetResponse[]> Get()
        {
            var dbReults =  _artistRepository.GetArtists(true, 1, 5);
            return _mapper.Map<ArtistGetResponse[]>(dbReults);
        }
    }
}