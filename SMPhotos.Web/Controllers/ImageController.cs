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
		private readonly IImageRepository _imageRepository;
		public ImageController(
			IImageRepository imageRepository
		)
		{
			_imageRepository = imageRepository;
		}

		[Authorize(Roles = Roles.User)]

		public ActionResult GetImage(int ImageId)
		{
			ImageVM image = AutoMapper.Mapper.Map<ImageVM>(_imageRepository.Get(ImageId));
			string[] split = image.Name.Split('.');
			string imageType = "image/" + split[split.Length - 1];
			return File(Server.MapPath(string.Format("~/App_Data/{0}/{1}", image.Album.Guid, image.Name)), imageType);
		}

	}
}