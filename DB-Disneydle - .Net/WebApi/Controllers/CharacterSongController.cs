using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApi.Mappers;
using WebApi.Models.CharacterSong;
using WebApi.Models.Song;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterSongController : ControllerBase
	{
		//Service injection
		private readonly ICharacterSongRepository<Character,Song> _characterService;

		public CharacterSongController(ICharacterSongRepository<Character, Song> characterService)
		{
			_characterService = characterService;
		}

		//// GET api/singers/5 --> problem with conversion to DAL Character 
		[HttpGet("singers/{songId}")]
		[ProducesResponseType<IEnumerable<CharacterShortDtoGet>>(200)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]

		public IActionResult GetAllSingers(int songId)
		{
			try
			{
				IEnumerable<CharacterShortDtoGet> model = _characterService.GetAllSingers(songId).Select(bll => bll.ToDtoGet());
				return Ok(model);
			}
			catch (SqlException)
			{
				return StatusCode(500);
			}
			catch (ArgumentOutOfRangeException) { return NotFound(); }
		}

		//// GET api/<SongController>/5
		[HttpGet("GetByCharacterId/{characterId}")]
		[ProducesResponseType<IEnumerable<SongDtoGet>>(200)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]

		public IActionResult GetByChatacterId(int characterId)
		{
			try
			{
				IEnumerable<SongDtoGet> model = _characterService.GetByCharacterId(characterId).Select(bll => bll.ToDtoGet());
				return Ok(model);
			}
			catch (SqlException)
			{
				return StatusCode(500);
			}
			catch (ArgumentOutOfRangeException) { return NotFound(); }
		}

	}
}
