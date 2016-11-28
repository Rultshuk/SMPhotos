using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPhotos.DAL
{
	public interface IAlbumRepository : IRepository<Album>
	{
		Album GetAlbumByGuid(Guid guid);
		void RemoveImage(Album album, Image image);
	}
}
