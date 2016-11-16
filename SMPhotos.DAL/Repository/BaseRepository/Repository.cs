using System.Collections.Generic;
using System.Linq;

namespace SMPhotos.DAL
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly SMPContext _dbContext;
		public Repository(SMPContext dbContext)
		{
			_dbContext = dbContext;
		}

		public TEntity Get(int id)
		{
			return _dbContext.Set<TEntity>().Find(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().ToList();
		}

		public void Add(TEntity entity)
		{
			_dbContext.Set<TEntity>().Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			_dbContext.Set<TEntity>().AddRange(entities);
		}

		public void Remove(TEntity entity)
		{
			_dbContext.Set<TEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_dbContext.Set<TEntity>().RemoveRange(entities);
		}
	}
}
