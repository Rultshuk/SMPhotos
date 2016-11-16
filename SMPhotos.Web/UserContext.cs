using System;

namespace SMPhotos.Web
{
	public class UserContext
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Location { get; set; }
		public DateTime? ActivationDate { get; set; }
		public bool IsAdmin { get; set; }
		public bool IsActive { get; set; }
		public bool IsUploader { get; set; }
	}
}