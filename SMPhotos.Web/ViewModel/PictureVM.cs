using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPhotos.Web.ViewModel
{
	public class PictureVM
	{
		public IEnumerable<HttpPostedFileBase> files { get; set; }

	}
}