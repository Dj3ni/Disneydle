using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	
	public class Character
	{
		public int Character_Id { get; set; }
		public string Name { get; set; }
		public string ClothingColor { get; set; }
		public string Role { get; set; }
		public short ParutionYear {  get; set; }
		public string Gender { get; set; }
		public string HairColor { get; set; }
		public string Type { get; set; }
		public string Continent { get; set; }
	}
}
