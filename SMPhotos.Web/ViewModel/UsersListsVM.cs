using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPhotos.Web.ViewModel
{
	public class UsersListsVM
	{
		public IList<UserVM> NoActiveUsers { get; set; }
		public IList<UserVM> AllUsers { get; set; }
	}
}