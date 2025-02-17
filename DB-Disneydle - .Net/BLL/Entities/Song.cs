using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Song
	{
		
		public int Song_Id { get; set; }
		public string Title { get; set; }
		public byte[]? Content { get; set; }
		public string? Clip { get; set; }

		IEnumerable<Character> Singers { get; set; }

		public Song(int song_Id, string title, byte[]? content, string? clip)
		{
			Song_Id = song_Id;
			Title = title;
			Content = content;
			Clip = clip;
		}
	}
}
