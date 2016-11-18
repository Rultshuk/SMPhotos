﻿using System.Collections.Generic;

namespace SMPhotos.DAL
{
	public interface IUserRepository : IRepository<User>
	{
		User GetByCredentials(string email, string password);
		IEnumerable<User> GetAdmin();
		IEnumerable<User> GetUploader();
		IEnumerable<User> GetActive();
		IEnumerable<User> GetNotActive();
		IEnumerable<User> GetNotActiveYet();
		IEnumerable<User> GetWasActivated();
	}
}
