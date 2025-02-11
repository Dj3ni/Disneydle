using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
	internal static class Mapper
	{
		public static Character ToCharacter(this IDataRecord record)
		{
			if(record is null) throw new ArgumentNullException(nameof(record));

			return new Character()
			{
				Character_Id = (int)record[nameof(Character.Character_Id)],
				Name = (string)record[nameof(Character.Name)],
				ClothingColor = (string)record[nameof(Character.ClothingColor)],
				Role = (string)record[nameof(Character.Role)],
				Gender = (string)record[nameof(Character.Gender)],
				Type = (string)record[nameof(Character.Type)],
				ParutionYear = (short)record[nameof(Character.ParutionYear)],
				HairColor = (string)record[nameof(Character.HairColor)],
				Continent = (string)record[nameof(Character.Continent)],
			};
		}
	}
}
