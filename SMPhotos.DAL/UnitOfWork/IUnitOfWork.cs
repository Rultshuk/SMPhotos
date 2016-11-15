using System;

namespace SMPhotos.DAL
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository Users { get; }
		IRepository<Image> Images { get; }
		IRepository<Album> Albums { get; }
		int Save();
	}
}
