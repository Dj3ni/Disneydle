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
		private ICharacterSongRepository<DAL.Entities.Character, DAL.Entities.Song> _characterSongService;

		public CharacterSongService(ICharacterSongRepository<DAL.Entities.Character, DAL.Entities.Song> characterSongService)
		{
			_characterSongService = characterSongService;
		}

		public void AddSinger(int characherId, int songId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Character> GetAllSingers(int songId)
		{
			return _characterSongService.GetAllSingers(songId).Select(dal => dal.ToBLLShort());
		}

		public IEnumerable<Song> GetByCharacterId(int characterId)
		{
			return _characterSongService.GetByCharacterId(characterId).Select(dal => dal.ToBLL());
		}

		public void RemoveSinger(int characherId, int songId)
		{
			throw new NotImplementedException();
		}
	}
}
