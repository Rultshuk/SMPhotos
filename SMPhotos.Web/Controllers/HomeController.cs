using SMPhotos.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SMPhotos.Web.ViewModel;
using System.Net.Mail;

namespace SMPhotos.Web.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		private readonly IUserRepository _userRepository;
		public HomeController(
			IUserRepository userRepository
		)
		{
			_userRepository = userRepository;
		}
		public ActionResult Index()
		{
			return View();
		}
		[HttpGet]
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
				return RedirectToAction("ChangeProfile");

			userBase.FirstName = userVM.FirstName;
			userBase.LastName = userVM.LastName;
			userBase.Location = userVM.Location;
			userBase.Email = userVM.Email;
			if ((userVM.Password == userBase.Password) && (userVM.NewPassword == userVM.ConfirmNewPassword))
			{
				userBase.Password = userVM.NewPassword;
			}
			_userRepository.UnitOfWork.SaveChanges();
			return RedirectToAction("ChangeProfile");
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

			var newUser = new User
			{
				Email = userVM.Email,
				Password = userVM.Password,
				FirstName = userVM.FirstName,
				LastName = userVM.LastName,
				Location = userVM.Location
			};

			_userRepository.Add(newUser);
			_userRepository.UnitOfWork.SaveChanges();
			return View(userVM);
		}

		private bool ValidateRegisterData(RegisterUserVM userVM)
		{
			bool isValid = true;

			try
			{
				MailAddress email = new MailAddress(userVM.Email);
			}
			catch (Exception)
			{
				isValid = false;
			}

			if (string.IsNullOrWhiteSpace(userVM.Password)
				|| string.IsNullOrWhiteSpace(userVM.PasswordConfirmation)
				|| userVM.Password != userVM.PasswordConfirmation)
			{
				isValid = false;
			}
			return isValid;
		}
		private bool ValidateChangeData(UserVM userVM, User userBase)
		{
			bool isValid = true;

			try
			{
				MailAddress email = new MailAddress(userVM.Email);
			}
			catch (Exception)
			{
				isValid = false;
			}
			if (
				(string.IsNullOrWhiteSpace(userVM.Password)
					&& string.IsNullOrWhiteSpace(userVM.NewPassword)
					&& string.IsNullOrWhiteSpace(userVM.ConfirmNewPassword)
				)
				|| (!string.IsNullOrWhiteSpace(userVM.Password)
					&& userVM.Password == userBase.Password
					&& userVM.NewPassword == userVM.ConfirmNewPassword
				)
			)
			{
				isValid = true;
			}
			else
				isValid = false;
			return isValid;
		}

		public ActionResult Upload()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Admin()
		{
			UsersListsVM usersListsVM = new UsersListsVM();
			IList<User> uslist1 = (IList<User>)_userRepository.GetNotActiveYet().OrderBy(t => t.FirstName).ToList();
			IList<User> uslist2 = (IList<User>)_userRepository.GetWasActivated().OrderBy(t => t.FirstName).ToList();
			usersListsVM.NoActiveUsers = Mapper.Map<IList<User>, IList<UserVM>>(uslist1);
			usersListsVM.AllUsers = Mapper.Map<IList<User>, IList<UserVM>>(uslist2);
			return View("Admin", usersListsVM);
		}

		[HttpPost]
		public ActionResult Admin(UsersListsVM usersLists)
		{
			foreach (var userVM in usersLists.AllUsers)
			{
				var user = _userRepository.Get(userVM.Id);
				user.IsActive = userVM.IsActive;
				user.IsAdmin = userVM.IsAdmin;
				user.IsUploader = userVM.IsUploader;
			}
			_userRepository.UnitOfWork.SaveChanges();

			ICollection<User> users = _userRepository.GetAll().ToList();
			ICollection<UserVM> newUsersVM = Mapper.Map<ICollection<User>, ICollection<UserVM>>(users);

			return RedirectToAction("Admin", newUsersVM);
		}


		[HttpPost]
		public ActionResult RegNewUsers(UsersListsVM usList)
		{
			foreach (var userVM in usList.NoActiveUsers)
			{
				var user = _userRepository.Get(userVM.Id);
				user.IsActive = userVM.IsActive;
				user.IsAdmin = userVM.IsAdmin;
				user.IsUploader = userVM.IsUploader;
				if (userVM.IsActive)
				{
					user.ActivationDate = DateTime.Now;
				}
			}
			_userRepository.UnitOfWork.SaveChanges();

			ICollection<User> users = _userRepository.GetAll().ToList();
			ICollection<UserVM> newUsersVM = Mapper.Map<ICollection<User>, ICollection<UserVM>>(users);

			return RedirectToAction("Admin", newUsersVM);
		}
	}
}