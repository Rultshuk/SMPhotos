using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPhotos.DAL
{
	class ImageRepository : Repository<Image>, IImageRepository
	{
		public ImageRepository(IUnitOfWork context) : base(context)
		{
		}
	}
}
