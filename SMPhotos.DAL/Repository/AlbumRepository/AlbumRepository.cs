using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPhotos.DAL
{
	public class AlbumRepository : Repository<Album>, IAlbumRepository
	{
		public AlbumRepository(IUnitOfWork context) : base(context)
		{
		}

		public Album GetAlbumByGuid(Guid Id)
		{
			return _unitOfWork.Context.Album
				.Where(e => e.Guid == Id).FirstOrDefault();
		}
		public override void Remove(Album album)
		{
			_unitOfWork.Context.Image.RemoveRange(album.Image);
			_unitOfWork.Context.Album.Remove(album);

		}
		public void RemoveImage (Album album,Image image)
		{
			_unitOfWork.Context.Image.Remove(image);
			_unitOfWork.Context.Album.Find(album.Id).Image.Remove(_unitOfWork.Context.Image.Find(image.Id));
		}
	}
}
