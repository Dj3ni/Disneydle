using Common.Repositories;
using DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.Mapper;

namespace DAL.Services
{
	public class SongService : BaseService, ISongRepository<Song, Character>
	{
		public SongService(IConfiguration config) : base(config, "Main-DB"){}

		public IEnumerable<Song> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Song_GetAll";
					command.CommandType = CommandType.StoredProcedure;
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
							yield return reader.ToCharacter();
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

		public Song GetById(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Song_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(Song.Song_Id), id);
					connection.Open();
					using(SqlDataReader reader = command.ExecuteReader())
					{
						if(reader.Read())
						{
							return reader.ToSong();
						}
						throw new ArgumentOutOfRangeException(nameof(id));
					}

				}
			}
		}

		public int Insert(Song song)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Song_Insert";
					command.CommandType = CommandType.StoredProcedure;
					// Parameters
					command.Parameters.AddWithValue(nameof(Song.Title), song.Title);
					command.Parameters.AddWithValue(nameof(Song.Content),(song.Content is null)? DBNull.Value : song.Content);
					command.Parameters.AddWithValue(nameof(Song.Clip),(song.Clip is null)? DBNull.Value : song.Clip);

					connection.Open();
					return (int)command.ExecuteScalar();

				}
			}
		}

		public void Update(int id, Song song)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Song_Update";
					command.CommandType = CommandType.StoredProcedure;
					//Parameters
					command.Parameters.AddWithValue(nameof(Song.Song_Id), id);
					command.Parameters.AddWithValue(nameof(Song.Title), song.Title);
					command.Parameters.AddWithValue(nameof(Song.Content), (song.Content is null) ? DBNull.Value : song.Content);
					command.Parameters.AddWithValue(nameof(Song.Clip), (song.Clip is null) ? DBNull.Value : song.Clip);

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
					command.CommandText = "SP_Song_Delete";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(Song.Song_Id), id);
					connection.Open();
					command.ExecuteNonQuery();

				}
			}
		}
	}
}
