using System;
using System.Web.Mvc;

namespace SMPhotos.Web.Controllers
{
	public class BaseController : Controller
	{
		private UserContext _userContext;
		protected UserContext CurentUserContext
		{
			get
			{
				throw new NotImplementedException();
				//TODO return user context, tie with session )
			}
		}

		protected void SaveCurentUserContext(UserContext userContext)
		{
			throw new NotImplementedException();
			//TODO save user context to session or something like that
		}
	}

}