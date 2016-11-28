using System.Web.Mvc;
using SMPhotos.DAL;
using SMPhotos.Web.ViewModel;
using System.IO;

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
		[HttpGet]
		public ActionResult GetImage(int id)
		{
			ImageVM image = AutoMapper.Mapper.Map<ImageVM>(_imageRepository.Get(id));
			//return File(
			//	Server.MapPath(string.Format("~/App_Data/{0}/{1}", image.Album.Guid, image.Name)),
			//	string.Format("image/{0}", Path.GetExtension(image.Name))
			//);
			string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, image.Album.Path, image.Album.Guid.ToString(), image.Name);
			if (System.IO.File.Exists(path))
			{
				FileStream stream = new FileStream(path, FileMode.Open);
				FileStreamResult result = new FileStreamResult(stream, string.Format("image/{0}", Path.GetExtension(image.Name)));
				result.FileDownloadName = image.Name;
				return result;
			}
			else
			{
				return new EmptyResult();
			}
			
		}

		[Authorize(Roles = Roles.User)]
		[HttpGet]
		public ActionResult GetThumbnail(int id)
		{
			ImageVM image = AutoMapper.Mapper.Map<ImageVM>(_imageRepository.Get(id));
			string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, MVCManager.Controller.Main.DefaultThumbnailsPath, image.Album.Guid.ToString(), image.Name);
			FileStream stream = new FileStream(path, FileMode.Open);
			FileStreamResult result = new FileStreamResult(stream, string.Format("thumbnails/{0}", Path.GetExtension(image.Name)));
			result.FileDownloadName = image.Name;
			return result;
		}

	}
}