using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPhotos.Web.ViewModel
{
	public class UserVM
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Location { get; set; }
		public bool IsAdmin { get; set; }
		public bool IsActive { get; set; }
		public bool IsUploader { get; set; }
		public DateTime ActivationDate { get; set; }
	}
}