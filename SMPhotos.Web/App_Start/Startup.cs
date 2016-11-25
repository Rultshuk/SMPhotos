using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(SMPhotos.Web.Startup))]

namespace SMPhotos.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/home/index"),
				SlidingExpiration = false,
				ExpireTimeSpan = TimeSpan.FromDays(20)
			});
		}
	}
}
