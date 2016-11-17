using System.Collections.Generic;
using System.Linq;

namespace SMPhotos.DAL
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly IUnitOfWork _unitOfWork;
		public Repository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IUnitOfWork UnitOfWork
		{
			get { return _unitOfWork; }
		}

		public TEntity Get(int id)
		{
			return _unitOfWork.Context.Set<TEntity>().Find(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _unitOfWork.Context.Set<TEntity>().ToList();
		}

		public void Add(TEntity entity)
		{
			_unitOfWork.Context.Set<TEntity>().Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			_unitOfWork.Context.Set<TEntity>().AddRange(entities);
		}

		public void Remove(TEntity entity)
		{
			_unitOfWork.Context.Set<TEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_unitOfWork.Context.Set<TEntity>().RemoveRange(entities);
		}
	}
}
