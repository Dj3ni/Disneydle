using Common.Repositories;
using DAL.Entities;
using DAL.Mapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
	public class QuoteService : BaseService, IQuoteRepository<Quote>
	{
		// Connection string injection
		public QuoteService(IConfiguration config) : base(config, "Main-DB") {}

		public IEnumerable<Quote> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Quote_GetAll";
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToQuote();
						}
					}
				}
			}
		}

		public Quote GetById(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Quote_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(Quote.Quote_Id), id);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToQuote();
						}
						throw new ArgumentOutOfRangeException(nameof(Quote.Quote_Id));
					}
					
				}
			}
		}

		public int Insert(Quote quote)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Quote_Insert";
					command.CommandType = CommandType.StoredProcedure;
					// Parameters
					command.Parameters.AddWithValue(nameof(Quote.Language), quote.Language);
					command.Parameters.AddWithValue(nameof(Quote.Content), quote.Content);
					command.Parameters.AddWithValue(nameof(Quote.Clip), quote.Clip);
					command.Parameters.AddWithValue(nameof(Quote.Character_Id), quote.Character_Id);

					connection.Open();
					return (int)command.ExecuteScalar(); // We have to cast because execute scalar always return type 'object'

				}
			}
		}

		public void Update(int id, Quote quote)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Quote_Update";
					command.CommandType = CommandType.StoredProcedure;
					//Parameters
					command.Parameters.AddWithValue(nameof(Quote.Quote_Id),id);
					command.Parameters.AddWithValue(nameof(Quote.Language),quote.Language);
					command.Parameters.AddWithValue(nameof(Quote.Content),quote.Content);
					command.Parameters.AddWithValue(nameof(Quote.Clip),quote.Clip);
					command.Parameters.AddWithValue(nameof(Quote.Character_Id), quote.Character_Id);
					
					connection.Open();
					command.ExecuteNonQuery();

				}
			}
		}
		public void Delete(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Quote_Delete";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(Quote.Quote_Id), id);
					connection.Open();
					command.ExecuteNonQuery();

				}
			}
		}
	}
}
