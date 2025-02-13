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
	}
}
