using System;

namespace SMPhotos.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SMPContext _dbContext;

		public UnitOfWork(SMPContext dbcontext)
		{
			_dbContext = dbcontext;
		}
		public SMPContext Context
		{
			get { return _dbContext; }
		}
		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}

		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
				disposedValue = true;
			}
		}
		public void Dispose()
		{

			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
