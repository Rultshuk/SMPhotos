using System;
using System.Collections.Generic;
using System.Web;
using SMPhotos.DAL;

namespace SMPhotos.Web.ViewModel
{
	public class PictureVM : Base
	{
		public Guid Guid { get; set; }
		public string Message { get; set; }
		public IEnumerable<HttpPostedFileBase> files { get; set; }
	}
}