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
		public const string PasswordConfirmation = "Password Confirmation";
		public const string Location = "Country";
		public const string Register = "Register";
		public const string SignIn = "Sign In";
		public const string PleaseSignUp = "Please Sign Up ";
		public const string ItsFreeJoke = "It's free, don`t be scare.";
	}
	public static class Navigation
	{
		public const string Home = "Home";
		public const string About = "About SMPhotos";
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
	}

	public static class MVCManager
	{
		public static class SessionData
		{
			public const string UserContext = "UserContext";
		}

		public static class Controller
		{
			public static class User
			{
				public const string Name = "User";
			}
			public static class Home
			{
				public const string Name = "Home";
				public const string Index = "Index";
			}
			public static class Main
			{
				public const string Name = "Main";
				public const string main = "Main";
			}

		}
		public static class View
		{
			public static class User
			{
			}
		}
	}
}