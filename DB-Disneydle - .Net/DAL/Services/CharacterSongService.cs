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
	public class CharacterSongService : BaseService, ICharacterSongRepository<Character, Song>
	{
		public CharacterSongService(IConfiguration config) : base(config, "Main-DB"){}

		public void AddSinger(int characherId, int songId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Character> GetAllSingers(int songId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Song_GetAllSingers";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(Song.Song_Id), songId);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToCharacterShort();
						}
					}

				}
			}
		}

		public IEnumerable<Song> GetByCharacterId(int characterId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Song_GetByCharacterId";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("character_id", characterId);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToSong();
						}
					}

				}
			}
		}

		public void RemoveSinger(int characherId, int songId)
		{
			throw new NotImplementedException();
		}
	}
}
