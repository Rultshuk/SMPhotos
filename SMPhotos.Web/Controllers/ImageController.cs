using SMPhotos.DAL;
using SMPhotos.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMPhotos.Web.Controllers
{
    public class ImageController : Controller
    {
		private readonly IAlbumRepository _albumRepository;
		public ImageController(
			IAlbumRepository albumRepository
		)
		{
			_albumRepository = albumRepository;
		}
		// GET: Image
		public ActionResult GetImage(int id, string name)
		{
			AlbumVM album = AutoMapper.Mapper.Map<AlbumVM>(_albumRepository.Get(id));
			string path = Server.MapPath(String.Format("~/App_Data/{0}/{1}", album.Guid, name));
			byte[] imageByteData = System.IO.File.ReadAllBytes(path);
			return File(imageByteData, "image/png");
		}
    }
}