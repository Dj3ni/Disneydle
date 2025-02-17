namespace WebApi.Models.Song
{
	public class SongDtoPost
	{
		public string Title { get; set; }
		public byte[]? Content { get; set; }
		public string? Clip { get; set; }
	}
}
