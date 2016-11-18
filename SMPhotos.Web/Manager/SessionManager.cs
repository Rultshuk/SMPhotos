using System.Web;

namespace SMPhotos.Web
{
	public static class SessionManager
	{
		private static UserContext _userContext;
		public static void SetSessionData<T>(string key, object value) where T : class
		{
			HttpContext.Current.Session[key] = value;
		}

		public static T GetSessionData<T>(string key) where T : class
		{
			var value = HttpContext.Current.Session[key];
			if (value != null && value is T)
				return value as T;
			else
				return null;
		}
		//public static UserContext CurentUserContext
		//{
		//	get { return _userContext; }
		//	set { _userContext = value; }
		//}
		public static UserContext CurentUserContext
		{
			get { return GetSessionData<UserContext>(MVCManager.SessionData.UserContext); }
			set { SetSessionData<UserContext>(MVCManager.SessionData.UserContext, value); }
		}

	}
}