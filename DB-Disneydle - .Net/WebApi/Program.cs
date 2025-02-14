
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
				builder.Services.AddScoped<ICharacterRepository<BLL.Entities.Character>, BLL.Services.CharacterService >();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// CORS
			builder.Services.AddCors(
				options =>
				{
					options.AddDefaultPolicy(policy =>
					{
						policy.AllowAnyOrigin()
								.AllowAnyMethod()
								.AllowAnyHeader();

					});

					//options.AddPolicy("CorsPolicy",
					//	policy =>
					//	{
					//		policy	.WithOrigins("https://localhost:7050")
					//				.AllowAnyMethod()
					//				.AllowAnyHeader();
					//	}
					//);
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
			app.UseCors();
			//app.UseCors("CorsPolicy");

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
