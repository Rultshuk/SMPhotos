using System.Collections.Generic;
using System.Linq;

namespace SMPhotos.DAL
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly SMPContext Context;
		public Repository(SMPContext context)
		{
			Context = context;
		}
		public TEntity Get(int id)
		{
			return Context.Set<TEntity>().Find(id);
		}
		public IEnumerable<TEntity> GetAll()
		{
			return Context.Set<TEntity>().ToList();
		}
		public void Add(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}
		public void AddRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().AddRange(entities);
		}
		public void Remove(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}
		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().RemoveRange(entities);
		}
	}
}
