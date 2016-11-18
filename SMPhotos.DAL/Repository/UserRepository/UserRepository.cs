using System.Collections.Generic;
using System.Linq;

namespace SMPhotos.DAL
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(IUnitOfWork context) : base(context)
		{
		}
		public User GetByCredentials(string email,string password)
		{
			return _unitOfWork.Context.User
				.Where(e => e.Email == email && e.Password==password)
				.FirstOrDefault<User>();
		}
		public IEnumerable<User> GetActive()
		{
			return _unitOfWork.Context.User
				.Where(e => e.IsActive)
				.ToList<User>();
		}
		public IEnumerable<User> GetAdmin()
		{
			return _unitOfWork.Context.User
				.Where(e => e.IsAdmin)
				.ToList<User>();
		}
		public IEnumerable<User> GetNotActive()
		{
			return _unitOfWork.Context.User
				.Where(e => e.IsActive)
				.ToList<User>();
		}
		public IEnumerable<User> GetUploader()
		{
			return _unitOfWork.Context.User
				.Where(e => e.IsUploader == true)
				.ToList<User>();
		}
		public IEnumerable<User> GetNotActiveYet()
		{
			return _unitOfWork.Context.User
				.Where(e => e.ActivationDate== null)
				.ToList<User>();
		}
		public IEnumerable<User> GetWasActivated()
		{
			return _unitOfWork.Context.User
				 .Where(e => e.ActivationDate != null)
				 .ToList<User>();
		}
	}
}
