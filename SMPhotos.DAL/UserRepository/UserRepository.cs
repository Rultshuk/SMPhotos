using System.Collections.Generic;
using System.Linq;

namespace SMPhotos.DAL
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(SMPContext context) : base(context)
		{
		}
		public IEnumerable<User> GetActive()
		{
			return _dbContext.Users
				.Where(e => e.IsActive)
				.AsEnumerable<User>();
		}
		public IEnumerable<User> GetAdmin()
		{
			return _dbContext.Users
				.Where(e => e.IsAdmin)
				.AsEnumerable<User>();
		}
		public IEnumerable<User> GetNotActive()
		{
			return _dbContext.Users
				.Where(e => e.IsActive)
				.AsEnumerable<User>();
		}
		public IEnumerable<User> GetUploader()
		{
			return _dbContext.Users
				.Where(e => e.IsUploader)
				.AsEnumerable<User>();
		}
	}
}
