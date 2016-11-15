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
			ICollection<User> users = db.User.ToList();
			//ViewBag.User = users;
			//ViewBag.Users = db.Users.ToList();
			//return View(db.Users.ToList());
			//return View(list);
			//db.SaveChanges();

			ICollection<UserVM> usersVM = Mapper.Map<ICollection<User>, ICollection<UserVM>>(users);

			return View(usersVM);
		}

		[HttpPost]
		public ActionResult Admin(ICollection<UserVM> users)
		{
			foreach(var user in users)
			{
				var us = db.User.Find(user.Id);
				us.IsActive = user.IsActive;
				us.IsAdmin = user.IsAdmin;
				us.IsUploader = user.IsUploader;
				db.Entry(us).State = EntityState.Modified;
			}
			db.SaveChanges();
			return RedirectToAction("Admin", db.User.ToList());
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