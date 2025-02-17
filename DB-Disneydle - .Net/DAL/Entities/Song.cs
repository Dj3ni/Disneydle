using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Song
	{
		public int Song_Id { get; set; }
		public string Title { get; set; }
		public byte[]? Content { get; set; }
		public string? Clip {  get; set; }
	}
}
