using BLL.Entities;
using BLL.Mapper;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class SongService : ISongRepository<Song, Character>
	{
		// Service injection
		private ISongRepository<DAL.Entities.Song,DAL.Entities.Character> _songService;

		public SongService(ISongRepository<DAL.Entities.Song, DAL.Entities.Character> songService)
		{
			_songService = songService;
		}

		// Crud Methods

		public IEnumerable<Song> GetAll()
		{
			return _songService.GetAll().Select(dal=>dal.ToBLL());
		}

		public IEnumerable<Character> GetAllSingers(int songId)
		{
			return _songService.GetAllSingers(songId).Select(dal=>dal.ToBLL());
		}

		public IEnumerable<Song> GetByCharacterId(int characterId)
		{
			return _songService.GetByCharacterId(characterId).Select(dal=>dal.ToBLL());
		}

		public Song GetById(int id)
		{
			return _songService.GetById(id).ToBLL();
		}

		public int Insert(Song song)
		{
			return _songService.Insert(song.ToDAL());
		}

		public void Update(int id, Song song)
		{
			_songService.Update(id, song.ToDAL());
		}

		public void Delete(int id)
		{
			_songService.Delete(id);
		}
	}
}
