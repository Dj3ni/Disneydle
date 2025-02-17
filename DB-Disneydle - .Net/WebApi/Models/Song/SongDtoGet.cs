namespace WebApi.Models.Song
{
	public class SongDtoGet
	{
		public int Song_Id { get; set; }
		public string Title { get; set; }
		public byte[]? Content { get; set; }
		public string? Clip { get; set; }

	}
}
