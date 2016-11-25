using System;

namespace SMPhotos.Web.ViewModel
{
	public class UserVM
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string NewPassword { get; set; }
		public string ConfirmNewPassword { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Location { get; set; }
		public string Message { get; set; }
		public bool IsAdmin { get; set; }
		public bool IsActive { get; set; }
		public bool IsUploader { get; set; }
		public DateTime? ActivationDate { get; set; }
	}
}