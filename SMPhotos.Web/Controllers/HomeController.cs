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
		// GET: Home
		private IUserRepository _userRepository;
		List<User> list = new List<User>();
		public HomeController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public ActionResult Index()
		{
			return View();
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