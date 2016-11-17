using SMPhotos.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SMPhotos.Web.ViewModel;

namespace SMPhotos.Web.Controllers
{
	public class HomeController : BaseController
	{
		//SMPContext db = new DAL.SMPContext();
		UnitOfWork _unitOfWork = new UnitOfWork(new SMPContext());
		// GET: Home
		List<User> list = new List<User>();
		public ActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public ActionResult ChangeProfile()
		{
			IList<User> uslist1 = (IList<User>)_unitOfWork._userRepository.GetNotActiveYet().OrderBy(t => t.FirstName).ToList();
			var usersVM = Mapper.Map<IList<User>, IList<UserVM>>(uslist1);
			var UserVM= usersVM[1];
			UserVM.Password = "";
			return View(UserVM);
		}
		[HttpPost]
		public ActionResult ChangeProfile(UserVM userVM)
		{
			var user = _unitOfWork._userRepository.Get(userVM.Id);
			user.FirstName = userVM.FirstName;
			user.LastName = userVM.LastName;
			user.Location = userVM.Location;
			user.Email = userVM.Email;
			if ( (userVM.Password==user.Password) && (userVM.NewPassword==userVM.ConfirmNewPassword))
			{
				user.Password = userVM.NewPassword;
			}
			_unitOfWork.Save();
			return RedirectToAction("ChangeProfile");
		}
		public ActionResult Main()
		{
			return View();
		}
		public ActionResult Join()
		{
			return View();
		}
		public ActionResult Upload()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Admin()
		{
			UsersListsVM usersListsVM = new UsersListsVM();

			IList<User> uslist1 = (IList<User>)_unitOfWork._userRepository.GetNotActiveYet().OrderBy(t => t.FirstName).ToList();
			IList<User> uslist2 = (IList<User>)_unitOfWork._userRepository.GetWasActivated().OrderBy(t => t.FirstName).ToList();
			usersListsVM.NoActiveUsers = Mapper.Map<IList<User>, IList<UserVM>>(uslist1);
			usersListsVM.AllUsers = Mapper.Map<IList<User>, IList<UserVM>>(uslist2);
			return View("Admin", usersListsVM);
		}

		[HttpPost]
		public ActionResult Admin(UsersListsVM usersLists)
		{
			foreach (var userVM in usersLists.AllUsers)
			{
				var user = _unitOfWork._userRepository.Get(userVM.Id);
				user.IsActive = userVM.IsActive;
				user.IsAdmin = userVM.IsAdmin;
				user.IsUploader = userVM.IsUploader;
			}
			_unitOfWork.Save();

			ICollection<User> users = _unitOfWork._userRepository.GetAll().ToList();
			ICollection<UserVM> newUsersVM = Mapper.Map<ICollection<User>, ICollection<UserVM>>(users);

			return RedirectToAction("Admin", newUsersVM);
		}


		[HttpPost]
		public ActionResult RegNewUsers(UsersListsVM usList)
		{
			foreach (var userVM in usList.NoActiveUsers)
			{
				var user = _unitOfWork._userRepository.Get(userVM.Id);
				user.IsActive = userVM.IsActive;
				user.IsAdmin = userVM.IsAdmin;
				user.IsUploader = userVM.IsUploader;
				if (userVM.IsActive)
				{
					user.ActivationDate = DateTime.Now;
				}
			}
			_unitOfWork.Save();

			ICollection<User> users = _unitOfWork._userRepository.GetAll().ToList();
			ICollection<UserVM> newUsersVM = Mapper.Map<ICollection<User>, ICollection<UserVM>>(users);

			return RedirectToAction("Admin", newUsersVM);
		}
	}
}