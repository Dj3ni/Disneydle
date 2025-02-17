using BLL.Entities;
using BLL.Mapper;
using Common.Repositories;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class CharacterSongService : ICharacterSongRepository<Character, Song>
	{
		//Service Injection
		private readonly ICharacterSongRepository<DAL.Entities.Character, DAL.Entities.Song> _characterSongService;

		public CharacterSongService(ICharacterSongRepository<DAL.Entities.Character, DAL.Entities.Song> characterSongService)
		{
			_characterSongService = characterSongService;
		}

		public IEnumerable<Character> GetAllSingers(int songId)
		{
			return _characterSongService.GetAllSingers(songId).Select(dal => dal.ToBLLShort());
		}

		public IEnumerable<Song> GetByCharacterId(int characterId)
		{
			return _characterSongService.GetByCharacterId(characterId).Select(dal => dal.ToBLL());
		}

		public void AddSinger(int characherId, int songId)
		{
			_characterSongService.AddSinger(characherId, songId);
		}

		public void RemoveSinger(int characherId, int songId)
		{
			_characterSongService.RemoveSinger(characherId, songId);
		}
	}
}
