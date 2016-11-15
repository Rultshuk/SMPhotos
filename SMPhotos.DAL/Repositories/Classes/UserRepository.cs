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
			return Context.User.Where(e => e.IsActive == true).AsEnumerable<User>();
		}
		public IEnumerable<User> GetAdmin()
		{
			return Context.User.Where(e => e.IsAdmin == true).AsEnumerable<User>();
		}
		public IEnumerable<User> GetNotActive()
		{
			return Context.User.Where(e => e.IsActive == false).AsEnumerable<User>();
		}
		public IEnumerable<User> GetUploader()
		{
			return Context.User.Where(e => e.IsUploader == true).AsEnumerable<User>();
		}
	}
}
