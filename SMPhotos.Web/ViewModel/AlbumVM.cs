using SMPhotos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPhotos.Web.ViewModel
{
	public class AlbumVM
	{
		public AlbumVM()
		{
			Image = new HashSet<Image>();
		}
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Image> Image { get; set; }
	}
}