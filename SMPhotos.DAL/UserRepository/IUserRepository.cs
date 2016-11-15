using System.Collections.Generic;

namespace SMPhotos.DAL
{
	public interface IUserRepository : IRepository<User>
	{
		IEnumerable<User> GetAdmin();
		IEnumerable<User> GetUploader();
		IEnumerable<User> GetActive();
		IEnumerable<User> GetNotActive();
	}
}
