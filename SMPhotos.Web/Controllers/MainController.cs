using SMPhotos.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SMPhotos.Web.ViewModel;
using System.IO;

namespace SMPhotos.Web.Controllers
{
	public class MainController : Controller
	{
		private readonly IAlbumRepository _albumRepository;
		public MainController(
			IAlbumRepository albumRepository
		)
		{
			_albumRepository = albumRepository;
		}

		// GET: Main
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Main()
		{
			AlbumListVM viewModel = new AlbumListVM();
			var albums = (IList<Album>)_albumRepository.GetAll();
			viewModel.AllAlbums = AutoMapper.Mapper.Map<IList<AlbumVM>>(albums);
			foreach (var alb in viewModel.AllAlbums)
			{
				alb.PathAlbum = alb.Path + alb.Guid + '/' + alb.Image[0].Name;
			}
			return View(viewModel);
		}

		public ActionResult Album()
		{
			return View();
		}
		[HttpGet]
		public ActionResult ImageLoad()
		{

			return View();
		}
		[HttpPost]
		public ActionResult ImageLoad(PictureVM picture)
		{
			foreach (var file in picture.files)
			{
				if (file.ContentLength > 0)
				{
					var fileName = Path.GetFileName(file.FileName);
					var filePath = Path.Combine(Server.MapPath("~/App_Data/TestAlbum"), fileName);
					file.SaveAs(filePath);
				}
			}
			return View();
		}
	}
}