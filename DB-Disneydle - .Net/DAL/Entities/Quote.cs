using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Quote
	{
		public int Quote_Id {  get; set; }
		public string Language {  get; set; }
		public string Content { get; set; }
		public int? Character_Id {  get; set; }
		public string? Clip {  get; set; }
	}
}
