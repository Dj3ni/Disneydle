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
		/// Overload of Converter DAL Character to BLL Character
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static BLL.Entities.Character ToBLLShort(this DAL.Entities.Character character)
		{
			if (character is null) throw new ArgumentNullException(nameof(character));
			return new Character(
				character.Character_Id,
				character.Name
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

		/// <summary>
		/// Convert DAL Song to BLL Song
		/// </summary>
		/// <param name="song">DAL Song</param>
		/// <returns>BLL Song</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static BLL.Entities.Song ToBLL(this DAL.Entities.Song song)
		{
			if(song is null) throw new ArgumentNullException( nameof(song));
			return new Song
				(
					song.Song_Id,
					song.Title,
					(song.Content is null)? null : song.Content,
					(song.Clip is null)? null : song.Clip
				);
		}

		public static DAL.Entities.Song ToDAL(this BLL.Entities.Song song)
		{
			if( song is null) throw new ArgumentNullException(nameof (song));
			return new DAL.Entities.Song()
			{
				Song_Id = song.Song_Id,
				Title = song.Title,
				Content = (song.Content is null) ? null : song.Content,
				Clip = (song.Clip is null) ? null : song.Clip
			};
		}
	}
}
