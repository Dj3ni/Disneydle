using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
	internal static class Mapper
	{
		/// <summary>
		/// Convert a DAL Character to a BLL Character
		/// </summary>
		/// <param name="character">DAL Character</param>
		/// <returns>BLL Character</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static BLL.Entities.Character ToBLL(this DAL.Entities.Character character)
		{
			if(character is null) throw new ArgumentNullException(nameof(character));
			return new Character(
				character.Character_Id,
					character.Name,
					character.ClothingColor,
					character.Role,
					character.ParutionYear,
					character.Gender,
					character.HairColor,
					character.Type,
					character.Continent
				);
		}

		/// <summary>
		/// Convert a BLL Character to a DAL Character
		/// </summary>
		/// <param name="character">BLL Character</param>
		/// <returns>DAL Character</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static DAL.Entities.Character ToDAL(this BLL.Entities.Character character)
		{
			if(character is null) throw new ArgumentNullException( nameof(character));
			return new DAL.Entities.Character()
			{
				Character_Id = character.Character_Id,
				Name = character.Name,
				ClothingColor = character.ClothingColor,
				Role = character.Role,
				ParutionYear = character.ParutionYear,
				Gender = character.Gender,
				HairColor = character.HairColor,
				Type = character.Type,
				Continent = character.Continent
			};
		}

		/// <summary>
		/// Convert DAL Quote to BLL Quote
		/// </summary>
		/// <param name="quote">DAL Quote</param>
		/// <returns>BLL Quote</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static BLL.Entities.Quote ToBLL(this DAL.Entities.Quote quote)
		{
			if (quote is null) throw new ArgumentNullException(nameof(quote));
			return new Quote(
				quote.Quote_Id,
				quote.Language,
				quote.Content,
				(quote.Character_Id is null)? null : quote.Character_Id,
				(quote.Clip is null)? null : quote.Clip
				);
		}

		/// <summary>
		/// Convert BLL Quote to DAL Quote
		/// </summary>
		/// <param name="quote">BLL Quote</param>
		/// <returns>DAL Quote</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static DAL.Entities.Quote ToDAL(this BLL.Entities.Quote quote)
		{
			if (quote is null) throw new ArgumentNullException(nameof(quote));
			return new DAL.Entities.Quote()
			{
				Quote_Id = quote.Quote_Id,
				Language = quote.Language,
				Content = quote.Content,
				Character_Id = quote.Character_Id,
				Clip = quote.Clip,
			};
		}

	}
}
