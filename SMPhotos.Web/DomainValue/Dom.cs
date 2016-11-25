using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPhotos.Web
{
	public static class Translation
	{
		public const string FirstName = "First Name";
		public const string LastName = "Last Name";
		public const string Email = "Email";
		public const string Password = "Password";
		public const string NewPassword = "New Password";
		public const string PasswordConfirmation = "Password Confirmation";
		public const string Location = "Country";
		public const string Register = "Register";
		public const string SignIn = "Sign In";
		public const string PleaseSignUp = "Please, Sign Up ";
		public const string ItsFreeJoke = "It's free, don`t be scared.";
		public const string ResetChanges = "Reset changes";
		public const string ApplyChanges = "Apply changes";
		public const string ChangesProfile = "Change your Profile ";
		public const string SelectImages = "Select images, you want to upload.";
		public const string BrowseImages = "Browse Images";
		public const string Upload = "Upload";
		public const string Remove = "Remove";
		public const string Close = "Close";
		public const string Active = "Active";
		public const string Admin = "Admin";
		public const string Uploader = "Uploader";
		public const string AlbumName = "Album Name";
		public const string Description = "Description";
		public const string OurContacts = "Our Contacts";
		public const string AboutUs = "About Us";
		public const string CreateAlbum = "Create New Album";
		public const string ChangeAlbum = "Change Album";
	}
	public static class Navigation
	{
		public const string Home = "Home";
		public const string About = "About";
		public const string Contact = "Contact";
		public const string Settings = "Settings";
		public const string ChangeProfile = "Change Profile";
		public const string AdminTools = "Admin Tools";
		public const string LogOut = "Log Out";
		public const string SMStudents = "SMStudents";
		public const string SMPhotos = "SMPhotos";
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
				public const string name = "home";
				public const string index = "index";
				public const string changeprofile = "changeprofile";
				public const string admin = "admin";
				public const string logout = "logout";
				public const string register = "register";
				public const string about = "about";
				public const string contact = "contact";
			}
			public static class Main
			{
				public const string name = "main";
				public const string album = "album";
				public const string albums = "albums";
				public const string albumaslist = "albumaslist";
				public const string imageload = "imageload";
				public const string createalbum = "createalbum";
				public const string ChangeAlbum = "changealbum";
			}
		}
	}
}