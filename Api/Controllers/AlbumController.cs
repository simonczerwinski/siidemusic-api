using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Album;
using Api.Services.Album;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet("getAlbum")]
        [ProducesResponseType(200, Type = typeof(Album))]
        [ProducesResponseType(404)]
        //string queryString
        public IActionResult GetAlbum(string trackID)
        {
            var request = _albumService.GetAlbum(trackID);

            if (request != null)
            {
                return Ok(request);
            }

            return NotFound("Something went wrong, could not GET!");
        }

        //[ProducesResponseType(200, Type = typeof(Album))]
        //[ProducesResponseType(404)]
        //[HttpDelete("{id}")]
        //public async Task GetAlbumAsync(int id)
        //{
        //    await _mediator.Send(new Delete.Command(id));
        //}


    }
}