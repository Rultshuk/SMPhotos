using System.Web.Mvc;
using AutoMapper;
using SMPhotos.DAL;
using SMPhotos.Web.ViewModel;

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
		[Authorize(Roles = Roles.User)]
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
				userVM.Message = "Something wrong, Your changes were not saved!";
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
			userVM.Message = "Your changes were successfully saved!";
			return View(userVM);
		}
		public ActionResult NotActivated()
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
			return RedirectToAction(MVCManager.Controller.Home.NotActivated, MVCManager.Controller.Home.Name);
		}
	}
}