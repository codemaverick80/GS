using AutoMapper;
using GS.Core.Api.Models;
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
        public ActionResult<ArtistsModel> Get(int id)
        {
            var result =  _artistRepository.GetArtist(id, true);
            if (result == null) return NotFound();
            return _mapper.Map<ArtistsModel>(result);
        }
        [HttpGet("get")]
        public ActionResult<ArtistsModel[]> Get()
        {
            var dbReults =  _artistRepository.GetArtists(true, 1, 5);
            return _mapper.Map<ArtistsModel[]>(dbReults);
        }
    }
}