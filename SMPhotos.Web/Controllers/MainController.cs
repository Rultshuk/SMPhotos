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
			return View(viewModel);
		}

	}
}