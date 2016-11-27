using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SMPhotos.DAL;
using SMPhotos.Web.ViewModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

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

		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[Authorize(Roles = Roles.User)]
		public ActionResult Albums()
		{
			AlbumListVM viewModel = new AlbumListVM();
			var albums = (IList<Album>)_albumRepository.GetAll();
			viewModel.AllAlbums = Mapper.Map<IList<AlbumVM>>(albums);
			foreach (var album in viewModel.AllAlbums)
			{
				album.PathAlbum = album.Path + album.Guid + '/';
			}
			return View(viewModel);
		}

		[HttpGet]
		[Authorize(Roles = Roles.User)]
		public ActionResult Album(int? id)
		{
			var albums = (IList<Album>)_albumRepository.GetAll();
			var album = albums.FirstOrDefault(x => x.Id == id);
			if (album == null)
			{
				return RedirectToAction(MVCManager.Controller.Main.Albums, MVCManager.Controller.Main.Name);
			}
			else
			{
				AlbumVM albumVM = Mapper.Map<AlbumVM>(album);
				albumVM.PathAlbum = albumVM.Path + albumVM.Guid + '/';
				return View(albumVM);
			}
		}

		[HttpGet]
		[Authorize(Roles = Roles.User)]
		public ActionResult ChangeAlbum(int id)
		{
			AlbumVM albumVM = Mapper.Map<AlbumVM>(_albumRepository.Get(id));
			return View(albumVM);
		}

		[HttpPost]
		[Authorize(Roles = Roles.User)]
		public ActionResult ChangeAlbum(AlbumVM albumVM)
		{
			if (!string.IsNullOrWhiteSpace(albumVM.Name))
			{
				Album album = _albumRepository.Get(albumVM.Id);
				album.Name = albumVM.Name;
				album.Description = albumVM.Description;
				_albumRepository.UnitOfWork.SaveChanges();
				albumVM.Message = "Your changes were successfully saved!";
			}
			else
			{
				albumVM.Message = "Something wrong, Your changes were not saved!";
			}
			return View(albumVM);
		}

		[HttpGet]
		[Authorize(Roles = Roles.User)]
		public ActionResult CreateAlbum()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = Roles.User)]
		public ActionResult CreateAlbum(AlbumVM albumVM)
		{
			Album album = new Album();
			album.Name = albumVM.Name;
			album.Description = albumVM.Description;
			album.Guid = Guid.NewGuid();
			album.Path = MVCManager.Controller.Main.DefaultAlbumsPath;
			Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, album.Path, album.Guid.ToString()));
			_albumRepository.Add(album);
			_albumRepository.UnitOfWork.SaveChanges();
			return RedirectToAction(MVCManager.Controller.Main.Album, MVCManager.Controller.Main.Name, new { _albumRepository.Get(_albumRepository.GetAll().ToList().Count()).Id });
		}

		[HttpGet]
		[Authorize(Roles = Roles.User)]
		public ActionResult AlbumAsList(int? id)
		{
			var albums = (IList<Album>)_albumRepository.GetAll();
			var album = albums.FirstOrDefault(x => x.Id == id);
			if (album == null)
			{
				return RedirectToAction(MVCManager.Controller.Main.Albums, MVCManager.Controller.Main.Name);
			}
			else
			{
				AlbumVM albumVM = Mapper.Map<AlbumVM>(album);
				albumVM.PathAlbum = albumVM.Path + albumVM.Guid + '/';
				return View(albumVM);
			}
		}

		[HttpGet]
		[Authorize(Roles = Roles.Uploader)]
		public ActionResult ImageLoad(int id)
		{
			var album = _albumRepository.Get(id);
			PictureVM picture = Mapper.Map<PictureVM>(album);
			picture.Guid = album.Guid;
			return View(picture);
		}

		[HttpPost]
		[Authorize(Roles = Roles.Uploader)]
		public ActionResult ImageLoad(PictureVM picture)
		{
			var album = _albumRepository.GetAlbumByGuid(picture.Guid);
			if (InitImages(picture, album))
			{
				picture.Message = "Your photos have successfully uploaded";
			}
			else
			{
				picture.Message = "Something wrong, Your upload is not successful!";
			}
			return View(picture);
		}

		bool InitImages(PictureVM pictureVM, Album album)
		{
			if (pictureVM == null || album == null || pictureVM.files == null)
			{
				return false;
			}
			string datetimeff = null;
			foreach (var file in pictureVM.files)
			{
				DAL.Image image = new DAL.Image();
				datetimeff = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_";
				image.Name = datetimeff + Path.GetFileName(file.FileName.Replace(" ", string.Empty));
				var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, album.Path, album.Guid.ToString(), image.Name);

				using (var originalImage = System.Drawing.Image.FromStream(file.InputStream, true, true)) /* Creates Image from specified data stream */
				{
					int newWidth = 200;
					int newHeight = 200;
					float aspectRatio = originalImage.Width / (float)originalImage.Height;
					if (originalImage.Width > originalImage.Height)
					{
						newWidth = (int)(200 * aspectRatio);
					}
					else
					{
						newHeight = (int)(200 / aspectRatio);
					}
					using (var thumb = originalImage.GetThumbnailImage(
						 newWidth, /* width*/
						 newHeight, /* height*/
						 () => false,
						 IntPtr.Zero))
					{
						var jpgInfo = ImageCodecInfo.GetImageEncoders().Where(codecInfo => codecInfo.MimeType == "image/png").First(); /* Returns array of image encoder objects built into GDI+ */
						using (var encParams = new EncoderParameters(1))
						{
							var appDataThumbnailPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, MVCManager.Controller.Main.DefaultThumbnailsPath, album.Guid.ToString());
							if (!Directory.Exists(appDataThumbnailPath))
							{
								Directory.CreateDirectory(appDataThumbnailPath);
							}
							string outputPath = Path.Combine(appDataThumbnailPath, image.Name);
							long quality = 100;
							encParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
							thumb.Save(outputPath, jpgInfo, encParams);
						}
					}
				}
				file.SaveAs(filePath);
				album.Image.Add(image);
			}
			_albumRepository.UnitOfWork.SaveChanges();
			return true;
		}
	}
}