using System.Collections.Generic;

namespace SMPhotos.Web.ViewModel
{
	public class UsersListsVM
	{
		public IList<UserVM> NoActiveUsers { get; set; }
		public IList<UserVM> AllUsers { get; set; }
	}
}