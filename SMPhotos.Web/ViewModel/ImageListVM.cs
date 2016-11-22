using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPhotos.Web.ViewModel
{
	public class ImageListVM
	{
		public IList<ImageVM> AlbumImages { get; set; }
	}
}