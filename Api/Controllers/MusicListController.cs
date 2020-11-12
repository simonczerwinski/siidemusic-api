using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Music;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MusicListController : Controller
    {
        private readonly IMusicListService _MusicListService;
        public MusicListController(IMusicListService MusicListService)
        {
            _MusicListService = MusicListService;
        }

        [HttpPost("{id}/saveMusic")]
        [ProducesResponseType(200, Type = typeof(MusicModel))]
        [ProducesResponseType(404)]
        //string queryString
        public IActionResult GetMusic()
        {
            var request = _MusicListService.SaveMusic();

            if (request != null)
            {
                return Ok(request);
            }

            return NotFound("Something went wrong, could not POST!");
        }
        //[HttpPut("{id}/updateMusic")]
        //[ProducesResponseType(200, Type = typeof(MusicModel))]
        //[ProducesResponseType(404)]
        //string queryString
        //public IActionResult GetMusic()
        //{
        //    var request = _MusicListService.SaveMusic();

        //    if (request != null)
        //    {
        //        return Ok(request);
        //    }

        //    return NotFound("Something went wrong, could not POST drink!");
        //}


    }
}