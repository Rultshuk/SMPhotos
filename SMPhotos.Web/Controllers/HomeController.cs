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
	public class HomeController : Controller
	{
		SMPContext db = new DAL.SMPContext();
	
		// GET: Home
		List<User> list = new List<User>();
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
			TestData();
			ICollection<User> users = db.Users.ToList();
			ICollection<UserVM> usersVM = Mapper.Map<ICollection<User>, ICollection<UserVM>>(users);
			return View(usersVM);
		}

		[HttpPost]
		public ActionResult Admin(ICollection<UserVM> usersVM)
		{
			foreach(var userVM in usersVM)
			{
				var user = db.Users.Find(userVM.Id);
				user.IsActive = userVM.IsActive;
				user.IsAdmin = userVM.IsAdmin;
				user.IsUploader = userVM.IsUploader;
				db.Entry(user).State = EntityState.Modified;
			}
			db.SaveChanges();

			ICollection<User> users = db.Users.ToList();
			ICollection<UserVM> newUsersVM = Mapper.Map<ICollection<User>, ICollection<UserVM>>(users);

			return RedirectToAction("Admin", newUsersVM);
		}
		public void TestData()
		{
			for (int i = 0; i < 10; i++)
			{
				list.Add(new User() { Id = 1,LastName="SomeLastName", FirstName = "SomeName", IsActive = false, Email="somemail@gmail.com" });
			}
		}
		public ActionResult Partial()
		{
			//ViewBag.Message = "Это частичное представление.";
			return PartialView();
		}
	}
}