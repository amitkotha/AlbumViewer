using AlbumViewer.Service.DTO;
using AlbumViewer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumViewer.Controllers
{
    public class AlbumController : Controller
    {
        IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        /// <summary>
        /// A list of albums with detail artist data
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <response code="200">Album List</response>
        /// <response code="500">Failed to retrieve albums</response>
        [HttpGet]
        [Route("api/albums")]
        public async Task<IActionResult> Get(int page = -1, int pageSize = 15)
        {
            return Ok(await _albumService.GetAllAlbums(page, pageSize));
        }

        /// <summary>
        /// Returns an individual album
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("api/album/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _albumService.Load(id));
        }

        /// <summary>
        /// Update or add a new album
        /// </summary>
        /// <param name="postedAlbum"></param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        [HttpPost("api/album")]
        public async Task<IActionResult> Post([FromBody] AlbumRequestDTO postedAlbum)
        {
            if (postedAlbum == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var album = await _albumService.SaveAlbum(postedAlbum);
            return CreatedAtAction("Get", new { id = album.Id }, postedAlbum);
        }


        /// <summary>
        /// Delete a specific album by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ApiException"></exception>
        [HttpDelete("api/album/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var album = await _albumService.Load(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(await _albumService.DeleteAlbum(id));
        }
    }
}
