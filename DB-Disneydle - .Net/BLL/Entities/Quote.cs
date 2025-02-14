using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Quote
	{
		public int Quote_Id { get; set; }
		public string Language { get; set; }
		public string Content { get; set; }
		public int? Character_Id { get; set; }
		public string? Clip { get; set; }

		public Quote(int quote_Id, string language, string content, int? character_Id, string? clip)
		{
			Quote_Id = quote_Id;
			Language = language;
			Content = content;
			Character_Id = character_Id;
			Clip = clip;
		}


	}
}
