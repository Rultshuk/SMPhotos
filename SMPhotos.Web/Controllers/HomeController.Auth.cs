using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using SMPhotos.Web.ViewModel;
using SMPhotos.DAL;

namespace SMPhotos.Web.Controllers
{
	public partial class HomeController
	{
		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
				if (User.IsInRole("User"))
					return RedirectToAction(MVCManager.Controller.Main.albums, MVCManager.Controller.Main.Name);
				else 
					return View("NotActivated");
			return View();

		}

		[HttpPost]
		public ActionResult Index(UserCredentialsVM userCredentialsVM)
		{
			if (!ValidateCredentials(userCredentialsVM))
				return View();
			User user = _userRepository.GetByCredentials(userCredentialsVM.Email, userCredentialsVM.Password);
			if (user == null)
			{
				ModelState.AddModelError("credentials", "Invalid username or password");
				return View();
			}
			SessionManager.CurentUserContext = Mapper.Map<User, UserContext>(user);
			List<Claim> claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.Name, SessionManager.CurentUserContext.FirstName));
			if (SessionManager.CurentUserContext.IsAdmin)
				claims.Add(new Claim(ClaimTypes.Role, "Admin"));
			if (SessionManager.CurentUserContext.IsActive)
				claims.Add(new Claim(ClaimTypes.Role, "User"));
			var identity = new ClaimsIdentity(claims.ToArray<Claim>(), DefaultAuthenticationTypes.ApplicationCookie);
			HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = userCredentialsVM.RememberMe }, identity);
			return RedirectToAction(MVCManager.Controller.Home.Index);
		}

		public ActionResult Logout()
		{
			HttpContext.GetOwinContext().Authentication.SignOut();
			return RedirectToAction(MVCManager.Controller.Home.Index);
		}
	}
}