using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GS.Core.Api.Models;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        private readonly IArtistRepository _artistRepo;
        private readonly IMapper _mapper;

        public ArtistController(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepo = artistRepository;
            _mapper = mapper;
        }

        // GET: api/artist
        [HttpGet]
        public async Task<ActionResult<ArtistsModel[]>> Get()
        {            
            var dbReults = await _artistRepo.GetArtistsWithAlbumsAsync(1, 10);
            //var art=  _artistRepo.FindByCondition(a => a.Id.Equals(107)).ToList();
            return _mapper.Map<ArtistsModel[]>(dbReults);
        }

        // GET api/artist/107
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistsModel>> Get(int id)
        {
            
                var dbresult = await _artistRepo.GetArtistByIdAsync(id, true);
                if (dbresult == null) return NotFound();
                return _mapper.Map<ArtistsModel>(dbresult);
            
        }


        // GET api/artist/107
        [HttpGet("search")]
        public async Task<ActionResult<ArtistsModel>> SearchById(int id)
        {
            try
            {
                var dbresult = await _artistRepo.GetArtistByIdAsync(id, true);
                if (dbresult == null) return NotFound();
                return _mapper.Map<ArtistsModel>(dbresult);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        // POST api/artist
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/artist/107
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/artist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



    }
}
