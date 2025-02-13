using BLL.Entities;
using Common.Repositories;
using BLL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class CharacterService : ICharacterRepository<Character>
	{
		//Services injection
		private ICharacterRepository<DAL.Entities.Character> _characterService;

		public CharacterService(ICharacterRepository<DAL.Entities.Character> characterService)
		{
			_characterService = characterService;
		}

		//Crud Methods
		public IEnumerable<Character> GetAll()
		{
			return _characterService.GetAll().Select(dal => dal.ToBLL());
		}

		public Character GetById(int id)
		{
			return _characterService.GetById(id).ToBLL();
		}

		public int Insert(Character character)
		{
			return _characterService.Insert(character.ToDAL());
		}

		public void Update(int id, Character character)
		{
			_characterService.Update(id, character.ToDAL());
		}

		public void Delete(int id)
		{
			_characterService.Delete(id);
		}
	}
}
