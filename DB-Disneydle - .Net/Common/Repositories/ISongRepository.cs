using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.Repositories
{
	public interface ISongRepository<TSong, TCharacter> : ICrudRepository<TSong,int>
	{
		IEnumerable<TSong> GetByCharacterId(int characterId);
		IEnumerable<TCharacter> GetAllSingers(int songId);
	}
}
