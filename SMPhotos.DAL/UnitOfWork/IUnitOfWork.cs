using System;

namespace SMPhotos.DAL
{
	public interface IUnitOfWork : IDisposable
	{
		SMPContext Context { get; }
		void SaveChanges();
	}
}
