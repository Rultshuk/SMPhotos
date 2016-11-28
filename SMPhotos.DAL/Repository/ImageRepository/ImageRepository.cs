using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPhotos.DAL
{
	public class ImageRepository : Repository<Image>, IImageRepository
	{
		public ImageRepository(IUnitOfWork context) : base(context)
		{
		}
	}
}
