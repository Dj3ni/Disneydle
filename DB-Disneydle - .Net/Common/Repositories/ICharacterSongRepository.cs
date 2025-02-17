using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
	public interface ICharacterSongRepository<TCharacter, TSong>
	{
		void AddSinger(int characherId, int songId);
		void RemoveSinger(int characherId, int songId);
		IEnumerable<TCharacter> GetAllSingers(int songId);
		IEnumerable<TSong> GetByCharacterId(int characterId);
	}
}
