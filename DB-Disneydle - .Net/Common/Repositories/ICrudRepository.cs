using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
	public  interface ICrudRepository<TEntity, TId>
	{
		TEntity GetById(TId id);
		IEnumerable<TEntity> GetAll();
		TId Insert(TEntity entity);
		void Update(TId id ,TEntity entity);
		void Delete(TId id);

	}
}
