using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPhotos.Web
{
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