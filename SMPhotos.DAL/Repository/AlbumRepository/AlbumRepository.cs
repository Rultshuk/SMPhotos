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
	}
}
