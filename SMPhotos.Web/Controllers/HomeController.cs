using SMPhotos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
		public ActionResult Admin()
		{
			TestData();
			IEnumerable<User> users = db.User;
			ViewBag.User = users;
			//ViewBag.Users = db.Users.ToList();
			//return View(db.Users.ToList());
			//return View(list);
			return View();
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