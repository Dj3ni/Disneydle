using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
using DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.Services
{
	public class CharacterService : BaseService, ICharacterRepository<Character>
	{
		//Services
		private ICharacterRepository<Character> _characterService;

		// Constructor
		public CharacterService(IConfiguration config) : base(config, "Main-DB") { }

		IEnumerable<Character> ICrudRepository<Character, int>.GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "";
					command.CommandType = CommandType.StoredProcedure;
				}
			}
		}

		public Character GetById(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "";
					command.CommandType = CommandType.StoredProcedure;
				}
			}
		}

		public int Insert(Character character)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Character_Insert";
					command.CommandType = CommandType.StoredProcedure;
					// Parameters
					command.Parameters.AddWithValue(nameof(Character.Name), character.Name);
					command.Parameters.AddWithValue(nameof(Character.ClothingColor), character.ClothingColor);
					command.Parameters.AddWithValue(nameof(Character.ParutionYear), character.ParutionYear);
					command.Parameters.AddWithValue(nameof(Character.HairColor), character.HairColor);
					command.Parameters.AddWithValue(nameof(Character.Gender), character.Gender);
					command.Parameters.AddWithValue(nameof(Character.Type), character.Type);
					command.Parameters.AddWithValue(nameof(Character.Role), character.Role);
					command.Parameters.AddWithValue(nameof(Character.Continent), character.Continent);

					connection.Open();

					return (int)command.ExecuteScalar();
				}
			}
		}

		public void Update(int id, Character character)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "";
					command.CommandType = CommandType.StoredProcedure;
				}
			}
		}

		public void Delete(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "";
					command.CommandType = CommandType.StoredProcedure;
				}
			}
		}

	}
}
