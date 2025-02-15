using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApi.Mappers;
using WebApi.Models.Quote;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuoteController : ControllerBase
	{
		// Services injections
		private IQuoteRepository<Quote> _quoteService;

		public QuoteController(IQuoteRepository<Quote> quoteService)
		{
			_quoteService = quoteService;
		}

		//Crud methods

		// GET: api/<QuoteController>
		[HttpGet]
		[ProducesResponseType<IEnumerable<QuoteDtoGet>>(200)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]
		public IActionResult GetAll()
		{
			try
			{
				IEnumerable<QuoteDtoGet> model = _quoteService.GetAll().Select(bll => bll.ToGetDto());
				return Ok(model);
			}
			catch (SqlException) { return StatusCode(500); }
			catch (ArgumentNullException) { return NotFound(); }
		}

		// GET api/<QuoteController>/5
		[HttpGet("{id}")]
		[ProducesResponseType<QuoteDtoGet>(200)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]
		public IActionResult GetById([FromQuery] int id)
		{
			try
			{
				QuoteDtoGet model = _quoteService.GetById(id).ToGetDto();
				return Ok(model);
			}
			catch (SqlException) { return StatusCode(500); }
			catch (ArgumentNullException) { return NotFound(); }
		}

		// POST api/<QuoteController>
		[HttpPost]
		[ProducesResponseType<QuoteDtoGet>(201)]
		[ProducesResponseType(500)]
		public IActionResult Post([FromBody] QuoteDtoPush quote)
		{
			try
			{
				int id = _quoteService.Insert(quote.ToBLL());
				QuoteDtoGet model= _quoteService.GetById(id).ToGetDto();
				return CreatedAtAction(nameof(GetById),new {id},model);
			}
			catch (SqlException) { return StatusCode(500); }

		}

		// PUT api/<QuoteController>/5
		[HttpPut("{id}")]
		[ProducesResponseType<QuoteDtoGet>(201)]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]
		public IActionResult Put(int id, [FromBody] QuoteDtoPush quote)
		{
			try
			{
				_quoteService.Update(id, quote.ToBLL());
				QuoteDtoGet model = _quoteService.GetById(id).ToGetDto();
				return CreatedAtAction(nameof(GetById), new { id }, model);
			}
			catch (SqlException) { return StatusCode(500); }
			catch (ArgumentOutOfRangeException) { return NotFound(); }
		}

		// DELETE api/<QuoteController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(204)]//No Content
		[ProducesResponseType (500)]
		[ProducesResponseType(404)]
		public IActionResult Delete(int id)
		{
			try
			{
				_quoteService.Delete(id);
				return NoContent();
			}
			catch (SqlException) { return StatusCode(500); }
			catch (ArgumentOutOfRangeException) { return NotFound(); }

		}
	}
}
