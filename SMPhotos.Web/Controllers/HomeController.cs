using SMPhotos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SMPhotos.Web.ViewModel;
using System.Net.Mail;

namespace SMPhotos.Web.Controllers
{
	public partial class HomeController : Controller
	{
		// GET: Home
		private readonly IUserRepository _userRepository;
		public HomeController(
			IUserRepository userRepository
		)
		{
			_userRepository = userRepository;
		}
		[HttpGet]
		[Authorize(Roles = "User")]
		public ActionResult ChangeProfile()
		{
			IList<User> uslist1 = (IList<User>)_userRepository.GetNotActiveYet().OrderBy(t => t.FirstName).ToList();
			var usersVM = Mapper.Map<IList<User>, IList<UserVM>>(uslist1);
			var UserVM = usersVM[1];
			UserVM.Password = "";
			return View(UserVM);
		}
		[HttpPost]
		public ActionResult ChangeProfile(UserVM userVM)
		{
			User userBase = _userRepository.Get(userVM.Id);
			if (!ValidateChangeData(userVM, userBase))
			{
				userVM.Message = "Your changes are not successful!";
				return View(userVM);
			}

			userBase.FirstName = userVM.FirstName;
			userBase.LastName = userVM.LastName;
			userBase.Location = userVM.Location;
			userBase.Email = userVM.Email;
			if ((userVM.Password == userBase.Password) && (userVM.NewPassword == userVM.ConfirmNewPassword))
			{
				userBase.Password = userVM.NewPassword;
			}
			_userRepository.UnitOfWork.SaveChanges();
			userVM.Message = "Your changes are successful!";
			return View(userVM);
		}
		public ActionResult Main()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Register(RegisterUserVM userVM)
		{
			if (!ValidateRegisterData(userVM))
				return View();

			User newUser = new User
			{
				Email = userVM.Email,
				Password = userVM.Password,
				FirstName = userVM.FirstName,
				LastName = userVM.LastName,
				Location = userVM.Location
			};

			_userRepository.Add(newUser);
			_userRepository.UnitOfWork.SaveChanges();
			return View();
		}
		
		public ActionResult Upload()
		{
			return View();
		}
	}
}