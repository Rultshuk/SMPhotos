using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SMPhotos.DAL;

namespace SMPhotos.Web.ViewModel
{
	public class AlbumVM : Base
	{
		//public AlbumVM()
		//{
		//	Image = new HashSet<Image>();
		//}
		public string Name { get; set; }
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
		public string Path { get; set; }
		public Guid Guid { get; set; }
		public string PathAlbum { get; set; }
		public virtual IList<Image> Image { get; set; }
		public string Message { get; set; }
	}
}