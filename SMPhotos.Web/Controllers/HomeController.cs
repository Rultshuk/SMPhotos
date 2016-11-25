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
			UserVM userVM = Mapper.Map<UserVM>(_userRepository.GetByEmail(User.Identity.Name));
			userVM.Password = "";
			return View(userVM);
		}
		[HttpPost]
		public ActionResult ChangeProfile(UserVM userVM)
		{
			User userBase = _userRepository.GetByEmail(userVM.Email);
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
		public ActionResult about()
		{
			return View();
		}
		public ActionResult contact()
		{
			return View();
		}
	}
}