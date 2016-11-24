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
				return RedirectToAction(MVCManager.Controller.Main.albums, MVCManager.Controller.Main.Name);
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
		public ActionResult CreateAlbum()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateAlbum(AlbumVM albumVM)
		{
			Album album = new Album();
			album.Name = albumVM.Name;
			album.Description = albumVM.Description;
			album.Guid = Guid.NewGuid();
			album.Path = album.Guid.ToString();
			Directory.CreateDirectory(Path.Combine(Server.MapPath("~/App_Data"), album.Path));
			_albumRepository.Add(album);
			_albumRepository.UnitOfWork.SaveChanges();
			//return RedirectToAction("albums");
			return View();
		}
		[HttpGet]
		public ActionResult albumtext(int? id)
		{
			var albums = (IList<Album>)_albumRepository.GetAll();
			var album = albums.FirstOrDefault(x => x.Id == id);
			if (album == null)
			{
				return RedirectToAction(MVCManager.Controller.Main.albums, MVCManager.Controller.Main.Name);
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
			var album = _albumRepository.GetAlbumByGuid(picture.Guid);
			InitImages(picture, album);
			return View();
		}

		void InitImages(PictureVM pictureVM, Album album)
		{
			string datetimeff = null;
			foreach (var file in pictureVM.files)
			{
				Image image = new Image();
				image.Name = Path.GetFileName(file.FileName);
				datetimeff = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "_";
				var filePath = Path.Combine(Server.MapPath("~/App_Data/"+pictureVM.Guid.ToString()), datetimeff + Path.GetFileName(file.FileName));
				file.SaveAs(filePath);
				album.Image.Add(image);
			}
			_albumRepository.UnitOfWork.SaveChanges();
		}
	}
}