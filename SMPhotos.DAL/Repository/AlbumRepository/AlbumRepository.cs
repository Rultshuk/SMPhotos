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

		public IList<Image> GetImagesByIdAlbum(int Id)
		{
			return _unitOfWork.Context.Image
				.Where(e => e.AlbumId == Id)
				.ToList<Image>();
		}
	}
}
