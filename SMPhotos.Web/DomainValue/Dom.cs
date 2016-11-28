namespace SMPhotos.Web
{
	public static class Translation
	{
		public const string FirstName = "First name";
		public const string LastName = "Last name";
		public const string Email = "Email";
		public const string Password = "Password";
		public const string NewPassword = "New password";
		public const string PasswordConfirmation = "Password confirmation";
		public const string Location = "country";
		public const string Register = "Register";
		public const string SignIn = "Sign in";
		public const string PleaseSignUp = "Please, sign up ";
		public const string ResetChanges = "Reset changes";
		public const string ApplyChanges = "Save changes";
		public const string ChangesProfile = "Change your profile ";
		public const string SelectImages = "Select images, you want to upload.";
		public const string BrowseImages = "Browse images";
		public const string Upload = "Upload";
		public const string Remove = "Remove";
		public const string Close = "Close";
		public const string Active = "Active";
		public const string Admin = "Admin";
		public const string Uploader = "Uploader";
		public const string AlbumName = "Album name";
		public const string Description = "Description";
		public const string OurContacts = "Our contacts";
		public const string AboutUs = "About us";
		public const string CreateAlbum = "Create new album";
		public const string ChangeAlbum = "Change album";
		public const string BackToAlbum = "Back to album";
		public const string PasswordId = "password";
		public const string PasswordConfirmId = "confirm_password";
	}
	public static class Navigation
	{
		public const string Home = "Home";
		public const string About = "About";
		public const string Contact = "Contact";
		public const string Settings = "Settings";
		public const string ChangeProfile = "Change profile";
		public const string AdminTools = "Admin tools";
		public const string LogOut = "Log out";
		public const string SMStudents = "SMStudents";
		public const string SMPhotos = "SMPhotos";
		public const string Admin = "Admin";
		public const string NotActivated = "NotActivated";
	}
	public static class View
	{
		public const string Index = "Index";
		public const string Admin = "Admin";
		public const string ChangeProfile = "ChangeProfile";
		public const string Register = "Register";
		public const string Upload = "Upload";
		public const string ImageLoad = "ImageLoad";
	}
	public static class Roles
	{
		public const string User = "User";
		public const string Admin = "Admin";
		public const string Uploader = "Uploader";
	}

	public static class MVCManager
	{
		public static class SessionData
		{
			public const string UserContext = "UserContext";
		}

		public static class Controller
		{
			public static class Home
			{
				public const string Name = "home";
				public const string Index = "index";
				public const string ChangeProfile = "changeprofile";
				public const string Admin = "admin";
				public const string LogOut = "logout";
				public const string Register = "register";
				public const string About = "about";
				public const string Contact = "contact";
				public const string RegNewUsers = "regnewusers";
				public const string NotActivated = "notactivated";
			}
			public static class Main
			{
				public const string Name = "main";
				public const string Album = "album";
				public const string Albums = "albums";
				public const string AlbumAsList = "albumaslist";
				public const string ImageLoad = "imageload";
				public const string CreateAlbum = "createalbum";
				public const string ChangeAlbum = "changealbum";
				public const string DefaultAlbumsPath = "App_Data";
				public const string DefaultThumbnailsPath = "images/thumbnails";
				public const string RemoveAlbum = "removealbum";
				public const string RemoveImage = "removeimage";
			}

			public static class Image
			{
				public const string Name = "image";
				public const string GetImage = "getimage";
				public const string GetThumbnail = "getthumbnail";
			}
		}
	}
}