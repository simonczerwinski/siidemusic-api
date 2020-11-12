using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Models;
using Api.Models.Music;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : Controller
    {
        private readonly IMusicService _MusicService;
        public MusicController(IMusicService MusicService)
        {
            _MusicService = MusicService;
        }
        [HttpGet("getMusic")]
        [ProducesResponseType(200, Type = typeof(MusicModel))]
        [ProducesResponseType(404)]
        //string queryString
        public IActionResult GetMusic()
        {
            var request = _MusicService.GetMusic();

            if (request != null)
            {
                return Ok(request);
            }

            return NotFound("Something went wrong, could not GET!");
        }


    }
}