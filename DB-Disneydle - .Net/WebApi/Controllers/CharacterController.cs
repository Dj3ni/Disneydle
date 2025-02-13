using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApi.Mappers;
using WebApi.Models.Character;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterController : ControllerBase
	{
		// Services injection
		private ICharacterRepository<Character> _characterService;
		public CharacterController(ICharacterRepository<Character> characterService)
		{
			_characterService = characterService;
		}


		// GET: api/<CharacterController>
		[HttpGet]
		[ProducesResponseType<IEnumerable<CharacterDtoGet>>(200)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]
		public IActionResult GetAll()
		{
			try
			{
				IEnumerable<CharacterDtoGet> model = _characterService.GetAll().Select(bll=>bll.ToGetDto()); //We have to cast because GetAll return an Ienumerable
				return Ok(model);
			}
			catch(SqlException)
			{
				return StatusCode(500);
			}
			catch (ArgumentOutOfRangeException)
			{
				return NotFound();
			}
		}

		// GET api/<CharacterController>/5
		[HttpGet("{id}")]
		[ProducesResponseType<CharacterDtoGet>(200)] //Succes
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]
		public IActionResult Get(int id)
		{
			try
			{
				Character character = _characterService.GetById(id);
				return Ok(character);
			}
			catch (SqlException)
			{
				return StatusCode(500);
			}
			catch (ArgumentOutOfRangeException)
			{
				return NotFound();
			}
		}

		// POST api/<CharacterController>
		[HttpPost]
		[ProducesResponseType<CharacterDtoGet>(201)] // Created
		[ProducesResponseType(500)]
		public IActionResult Post([FromBody] CharacterDtoPost character)
		{
			try
			{
				int id =_characterService.Insert(character.ToBLL());
				CharacterDtoGet model = _characterService.GetById(id).ToGetDto();

				// When done set a link to the data inserted (we need the id for the route and give a way to read the data)
				return CreatedAtAction(nameof(Get),new { id }, model);
			}
			catch (SqlException)
			{
				return StatusCode(500);
			}
		}

		// PUT api/<CharacterController>/5
		[HttpPut("{id}")]
		[ProducesResponseType<CharacterDtoGet>(201)]//created
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult Put(int id, [FromBody] CharacterDtoPut character)
		{
			try
			{
				CharacterDtoGet model = _characterService.GetById(id).ToGetDto();
				_characterService.Update(id, character.ToBLL());
				return CreatedAtAction(nameof(Get), new { id },model);
			}
			catch(SqlException)
			{
				return StatusCode(500);
			}
			catch(ArgumentOutOfRangeException)
			{
				return NotFound();
			}
		}

		// DELETE api/<CharacterController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(204)]// deleted
		[ProducesResponseType(404)]
		[ProducesResponseType(500)]
		public IActionResult Delete(int id)
		{
			try
			{
				_characterService.Delete(id);
				return NoContent();
			}
			catch (SqlException)
			{
				return StatusCode(500);
			}
			catch (ArgumentOutOfRangeException)
			{
				return NotFound();
			}

		}
	}
}
