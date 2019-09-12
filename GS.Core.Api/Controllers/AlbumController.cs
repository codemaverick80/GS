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
    [Route("api/album/")]
    public class AlbumController : ControllerBase
    {
        protected readonly IAlbumRepository _albumRepo;
        protected readonly IMapper _mapper;


        public AlbumController(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepo = albumRepository;
            _mapper = mapper;
        }

       
        [HttpGet("get")]        
        public async Task<ActionResult<IEnumerable<AlbumsModel>>> Get()
        {
            var result = await _albumRepo.GetAlbumsAsync(false,1,20);

            return _mapper.Map<AlbumsModel[]>(result);
        }
        
        [HttpGet("get/{album_id}")]
        public async Task<ActionResult<AlbumsModel>> Get(int album_id)
        {
            var result = await _albumRepo.GetAlbumAsync(album_id, true);
            if (result == null) return NotFound();

            return _mapper.Map<AlbumsModel>(result);
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
