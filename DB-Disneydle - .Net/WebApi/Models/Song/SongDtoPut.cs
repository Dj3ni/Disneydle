namespace WebApi.Models.Song
{
	public class SongDtoPut
	{
		public string Title { get; set; }
		public byte[]? Content { get; set; }
		public string? Clip { get; set; }
	}
}
