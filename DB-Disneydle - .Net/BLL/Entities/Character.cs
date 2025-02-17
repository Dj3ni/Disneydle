using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Character
	{
		
		public int Character_Id { get; set; }
		public string Name { get; set; }
		public string ClothingColor { get; set; }
		public string Role { get; set; }
		public short ParutionYear { get; set; }
		public string Gender { get; set; }
		public string HairColor { get; set; }
		public string Type { get; set; }
		public string Continent { get; set; }

		public Character(int id,string name, string clothingColor, string role, short parutionYear, string gender, string hairColor, string type, string continent)
		{
			Character_Id = id;
			Name = name;
			ClothingColor = clothingColor;
			Role = role;
			ParutionYear = parutionYear;
			Gender = gender;
			HairColor = hairColor;
			Type = type;
			Continent = continent;
		}

		public Character(int id,string name)
		{
			Character_Id = id;
			Name = name;
		}


	}
}
