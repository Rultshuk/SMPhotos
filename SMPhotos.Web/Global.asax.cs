using Guestbook;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SMPhotos.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			Bootstrapper.Initialize();
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
