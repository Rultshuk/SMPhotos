using System.Web;

namespace SMPhotos.Web
{
	public class SessionManager
	{
		private UserContext _userContext;
		public UserContext CurrentUserContext
		{
			get { return _userContext ?? (_userContext = HttpContext.Current.Session["UserContext"] as UserContext); }
			private set { HttpContext.Current.Session["UserContext"] = value; }
		}
		public void UpdateSession()
		{
			CurrentUserContext = _userContext;
		}
	}
}