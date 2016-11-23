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
		[HttpGet]
		public ActionResult albums()
		{
			AlbumListVM viewModel = new AlbumListVM();
			var albums = (IList<Album>)_albumRepository.GetAll();
			viewModel.AllAlbums = AutoMapper.Mapper.Map<IList<AlbumVM>>(albums);
			foreach (var alb in viewModel.AllAlbums)
			{
				alb.PathAlbum = alb.Path + alb.Guid + '/';
			}
			return View(viewModel);
		}

		[HttpGet]
		public ActionResult album(int? id)
		{
			var albums = (IList<Album>)_albumRepository.GetAll();
			var album = albums.FirstOrDefault(x => x.Id == id);
			if (album == null)
			{
				return RedirectToAction(MVCManager.Controller.Main.Albums, MVCManager.Controller.Main.Name);
			}
			else
			{
				AlbumVM albumVM = AutoMapper.Mapper.Map<AlbumVM>(album);
				albumVM.PathAlbum = albumVM.Path + albumVM.Guid + '/';
				return View(albumVM);
			}
		}
		//[HttpPost]
		//public ActionResult album(AlbumVM albumVM)
		//{
		//	var album = _albumRepository.Get(albumVM.Id);
		//	//PictureVM picture = new PictureVM();
		//	PictureVM picture = AutoMapper.Mapper.Map<PictureVM>(album);
		//	picture.Guid = album.Guid;
		//	return RedirectToAction("ImageLoad", picture);
		//}

		[HttpGet]
		public ActionResult albumtext(int? id)
		{
			var albums = (IList<Album>)_albumRepository.GetAll();
			var album = albums.FirstOrDefault(x => x.Id == id);
			if (album == null)
			{
				return RedirectToAction(MVCManager.Controller.Main.Albums, MVCManager.Controller.Main.Name);
			}
			else
			{
				AlbumVM albumVM = AutoMapper.Mapper.Map<AlbumVM>(album);
				albumVM.PathAlbum = albumVM.Path + albumVM.Guid + '/';
				return View(albumVM);
			}
		}

		[HttpGet]
		public ActionResult ImageLoad(int id)
		{
			var album = _albumRepository.Get(id);
			PictureVM picture = Mapper.Map<PictureVM>(album);
			picture.Guid = album.Guid;
			return View(picture);
		}
		[HttpPost]
		public ActionResult ImageLoad(PictureVM picture)
		{
			InitImages(picture);
			return View();
		}

		void InitImages(PictureVM pictureVM)
		{
			var album = _albumRepository.GetAlbumByGuid(_albumRepository.Get(1).Guid);
			foreach (var file in pictureVM.files)
			{
				Image image = new Image();
				image.Name = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
				var filePath = Path.Combine(Server.MapPath("~/App_Data/TestAlbum"), image.Name);
				file.SaveAs(filePath);
				album.Image.Add(image);
			}
			_albumRepository.UnitOfWork.SaveChanges();
		}
	}
}