using System.Web.Mvc;
using SMPhotos.DAL;
using SMPhotos.Web.ViewModel;

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
			string[] split = image.Name.Split('.');
			string type = "image/" + split[split.Length - 1];
			return File(
				Server.MapPath(string.Format("~/App_Data/{0}/{1}", image.Album.Guid, image.Name)), 
				type);
		}

	}
}