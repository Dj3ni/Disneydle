
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApi.Mappers;
using WebApi.Models.Character;
using WebApi.Models.Song;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	
	public class SongController : ControllerBase
	{
		//Service injection
		private ISongRepository<Song> _songService;

		public SongController(ISongRepository<Song> songService)
		{
			_songService = songService;
		}


		// GET: api/<SongController>
		[HttpGet]
		[ProducesResponseType<IEnumerable<SongDtoGet>>(200)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]
		public IActionResult GetAll()
		{
			try
			{
				IEnumerable<SongDtoGet> model = _songService.GetAll().Select(bll=>bll.ToDtoGet());
				return Ok(model);
			}
			catch (SqlException){
				return StatusCode(500);
			}
			catch(ArgumentNullException) { return NotFound(); }
		}

		// GET api/<SongController>/5
		[HttpGet("{songId}")]
		[ProducesResponseType<SongDtoGet>(200)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]

		public IActionResult GetById(int songId)
		{
			try
			{
				SongDtoGet model = _songService.GetById(songId).ToDtoGet();
				return Ok(model);
			}
			catch(SqlException){
				return StatusCode(500);
			}
			catch(ArgumentOutOfRangeException) { return NotFound(); }
		}

		// POST api/<SongController>
		[HttpPost]
		[ProducesResponseType<SongDtoGet>(201)]
		[ProducesResponseType(500)]
		public IActionResult Post([FromBody] SongDtoPost song)
		{
			try
			{
				int id = _songService.Insert(song.ToBLL());
				SongDtoGet model = _songService.GetById(id).ToDtoGet();
				return CreatedAtAction(nameof(GetById), new {id}, model);//re-direction doens't work but post action is ok (it gets id and model so should work)
			}
			catch (SqlException) { return StatusCode(500); }

		}

		// PUT api/<SongController>/5
		[HttpPut("{id}")]
		[ProducesResponseType<SongDtoGet>(201)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]
		public IActionResult Put(int id, [FromBody] SongDtoPut song)
		{
			try
			{
				_songService.Update(id,song.ToBLL());
				SongDtoGet model = _songService.GetById(id).ToDtoGet();
				return CreatedAtAction(nameof(GetById), new { id }, model);//re-direction doens't work but post action is ok (it gets id and model so should work)

			}
			catch (SqlException) { return StatusCode(500); }
			catch (ArgumentOutOfRangeException) { return NotFound(); }
		}

		// DELETE api/<SongController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]
		public IActionResult Delete(int id)
		{
			try
			{
				_songService.Delete(id);
				return NoContent();
			}
			catch(SqlException) { return StatusCode(500); }
			catch (ArgumentOutOfRangeException) { return NotFound(); }
		}
	}
}
