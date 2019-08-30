using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GS.Core.Api.Models;
using GS.Core.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/values
        [HttpGet("get")]
        public async Task<ActionResult<GenresModel[]>> Get()
        {
            var result =await _genresRepository.GetAllGenresAsync(true, 1, 5);
            return _mapper.Map<GenresModel[]>(result);
        }

        // GET api/values/5
        [HttpGet("get/{genre_id}")]
        public async Task<ActionResult<GenresModel>> Get(int genre_id)
        {
            var result =await _genresRepository.GetGenresByIdAsync(genre_id, true);
            if (result == null) return NotFound();
            return _mapper.Map<GenresModel>(result);            
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
