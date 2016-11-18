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