namespace SMPhotos.DAL
{
	public partial class User
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Location { get; set; }
		public bool? IsAdmin { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsUploader { get; set; }
	}
}
