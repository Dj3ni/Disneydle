using BLL.Entities;
using WebApi.Models.Quote;

namespace WebApi.Mappers
{
	internal static class QuoteMapper
	{
		/// <summary>
		/// Convert BLL Quote to readable data for API (with model QuoteDtoGet
		/// </summary>
		/// <param name="quote">BLL Quote</param>
		/// <returns>QuoteDtoGet</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static QuoteDtoGet ToGetDto(this Quote quote)
		{
			if (quote is null) throw new ArgumentNullException(nameof(quote));

			return new QuoteDtoGet()
			{
				Quote_Id = quote.Quote_Id,
				Language = quote.Language,
				Content = quote.Content,
				Character_Id = (quote.Character_Id is null)? 0 : quote.Character_Id,
				Clip = (quote.Clip is null)? "null": quote.Clip,				
			};
		}

		/// <summary>
		/// Convert Data from ApiPost to Bll Quote
		/// </summary>
		/// <param name="quote">QuoteDtoPush</param>
		/// <returns>BLL Quote</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Quote ToBLL(this QuoteDtoPush quote)
		{
			if(quote is null) throw new ArgumentNullException(nameof (quote));
			return new Quote(
				0,
				quote.Language,
				quote.Content,
				quote.Character_Id,
				quote.Clip				
				);
		}

		/// <summary>
		/// Convert Data from Api Put to BLL Quote
		/// </summary>
		/// <param name="quote">QuoteDtoPut</param>
		/// <returns>BLL Quote</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Quote ToBLL(this QuoteDtoPut quote)
		{
			if (quote is null) throw new ArgumentNullException(nameof(quote));
			return new Quote(
				0,
				quote.Language,
				quote.Content,
				quote.Character_Id,
				quote.Clip
				);
		}
	}
}
