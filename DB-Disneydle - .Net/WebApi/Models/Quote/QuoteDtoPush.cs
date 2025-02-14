namespace WebApi.Models.Quote
{
	public class QuoteDtoPush
	{
		public string Language { get; set; }
		public string Content { get; set; }
		public int? Character_Id { get; set; }
		public string? Clip { get; set; }
	}
}
