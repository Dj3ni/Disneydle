using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
using DAL.Entities;
using DAL.Mapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.Services
{
	public class CharacterService : BaseService, ICharacterRepository<Character>
	{

		// Constructor
		public CharacterService(IConfiguration config) : base(config, "Main-DB") { }

		IEnumerable<Character> ICrudRepository<Character, int>.GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Character_GetAll";
					command.CommandType =CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToCharacter();
						}
					}
				}
			}
		}

		public Character GetById(int character_id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Character_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(Character.Character_Id), character_id);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if(reader.Read()) return reader.ToCharacter();
						else throw new ArgumentException(nameof(character_id));
					}
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
					command.CommandText = "SP_Character_Update";
					command.CommandType = CommandType.StoredProcedure;
					//Parameters
					command.Parameters.AddWithValue(nameof(Character.Character_Id),id);
					command.Parameters.AddWithValue(nameof(Character.Name), character.Name);
					command.Parameters.AddWithValue(nameof(Character.ClothingColor), character.ClothingColor);
					command.Parameters.AddWithValue(nameof(Character.ParutionYear), character.ParutionYear);
					command.Parameters.AddWithValue(nameof(Character.HairColor), character.HairColor);
					command.Parameters.AddWithValue(nameof(Character.Gender), character.Gender);
					command.Parameters.AddWithValue(nameof(Character.Type), character.Type);
					command.Parameters.AddWithValue(nameof(Character.Role), character.Role);
					command.Parameters.AddWithValue(nameof(Character.Continent), character.Continent);
					
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
					command.CommandText = "SP_Character_Delete";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(Character.Character_Id), id);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

	}
}
