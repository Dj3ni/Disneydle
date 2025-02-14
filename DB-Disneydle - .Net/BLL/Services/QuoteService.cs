using BLL.Entities;
using BLL.Mapper;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class QuoteService : IQuoteRepository<Quote>
	{
		// Services Injection
		private IQuoteRepository<DAL.Entities.Quote> _quotesService;
		
		public QuoteService(IQuoteRepository<DAL.Entities.Quote> quoteService)
		{
			_quotesService = quoteService;
		}

		//Crud Methods

		public IEnumerable<Quote> GetAll()
		{
			return _quotesService.GetAll().Select(dal => dal.ToBLL());		
		}

		public Quote GetById(int id)
		{
			return _quotesService.GetById(id).ToBLL();
		}

		public int Insert(Quote quote)
		{
			return _quotesService.Insert(quote.ToDAL());
		}

		public void Update(int id, Quote quote)
		{
			_quotesService.Update(id, quote.ToDAL());
		}

		public void Delete(int id)
		{
			_quotesService.Delete(id);
		}
	}
}
