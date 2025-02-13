using BLL.Entities;
using WebApi.Models.Character;

namespace WebApi.Mappers
{
	internal static class CharacterMapper
	{
		/// <summary>
		///  Conversion between Data from de Post api to a BLL object
		/// </summary>
		/// <param name="character"></param>
		/// <returns>BLL Object</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Character ToBLL(this CharacterDtoPost character)
		{
			if(character is null) throw new ArgumentNullException(nameof(character));
			return new Character(
				0,
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
		/// Conversion between Data from de Put api to a BLL object
		/// </summary>
		/// <param name="character"></param>
		/// <returns>BLL Object Character</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Character ToBLL(this CharacterDtoPut character)
		{
			if (character is null) throw new ArgumentNullException(nameof(character));
			return new Character(
				0,
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
		/// Conversion between BLL Object Character for the Get api
		/// </summary>
		/// <param name="character"></param>
		/// <returns>GetDto object</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static CharacterDtoGet ToGetDto(this Character character) 
		{
			if( character is null) throw new ArgumentNullException( nameof(character));
			return new CharacterDtoGet()
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

	}
}

