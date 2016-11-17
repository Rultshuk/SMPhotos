using System.Web;

namespace SMPhotos.Web
{
	public static class SessionManager
	{
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
	}
}