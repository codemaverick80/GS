using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GS.Core.Api.Contracts.V1.Responses;
using GS.Core.Api.Models;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GS.Core.Api.Controllers
{
    [Route("api/artist/")]
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
        [HttpGet("get")]
        public async Task<ActionResult<ArtistGetResponse[]>> Get()
        {
            var dbReults = await _artistRepo.GetArtistsAsync(true, 1, 5);
            return _mapper.Map<ArtistGetResponse[]>(dbReults);
        }

        // GET api/artist/107
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ArtistGetResponse>> Get(int id)
        {
            var dbresult = await _artistRepo.GetArtistAsync(id, true);
            if (dbresult == null) return NotFound();
            return _mapper.Map<ArtistGetResponse>(dbresult);
        }


        //// POST api/artist
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/artist/107
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/artist/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}



    }
}
