
using Common.Repositories;
using DAL.Services;

namespace WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			// Personalized services
				// CHARACTER
				builder.Services.AddScoped<ICharacterRepository<DAL.Entities.Character>,
				DAL.Services.CharacterService >();
				builder.Services.AddScoped<ICharacterRepository<BLL.Entities.Character>, BLL.Services.CharacterService>();

				// QUOTE
				builder.Services.AddScoped<IQuoteRepository<DAL.Entities.Quote>, DAL.Services.QuoteService >();
				builder.Services.AddScoped<IQuoteRepository<BLL.Entities.Quote>, BLL.Services.QuoteService >();

				// SONG
				builder.Services.AddScoped<ISongRepository<DAL.Entities.Song>, DAL.Services.SongService >();
				builder.Services.AddScoped<ISongRepository<BLL.Entities.Song>, BLL.Services.SongService >();

				//CharacterSong
				builder.Services.AddScoped<ICharacterSongRepository<DAL.Entities.Character, DAL.Entities.Song>, DAL.Services.CharacterSongService>();
				builder.Services.AddScoped<ICharacterSongRepository<BLL.Entities.Character, BLL.Entities.Song>, BLL.Services.CharacterSongService>();


			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// CORS
			builder.Services.AddCors(
				options =>
				{
					//options.AddDefaultPolicy(policy =>
					//{
					//	policy.AllowAnyOrigin()
					//			.AllowAnyMethod()
					//			.AllowAnyHeader();

					//});

					options.AddPolicy("CorsPolicy",
						policy =>
						{
							policy.WithOrigins("http://127.0.0.1:5500")
									.AllowAnyMethod()
									.AllowAnyHeader();
						}
					);
				}
			);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			//Cors policy
			//app.UseCors();
			app.UseCors("CorsPolicy");

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
