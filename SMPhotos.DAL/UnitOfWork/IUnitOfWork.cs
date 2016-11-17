using System;

namespace SMPhotos.DAL
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository _userRepository { get; }
		IRepository<Image> Images { get; }
		IRepository<Album> Albums { get; }
		int Save();
	}
}
