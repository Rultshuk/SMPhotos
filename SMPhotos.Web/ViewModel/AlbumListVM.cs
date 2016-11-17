using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPhotos.Web.ViewModel
{
	public class AlbumListVM
	{
		public IList<AlbumVM> AllAlbums { get; set; }
		public ICollection<AlbumVM> AllAlbumsC { get; set; }
	}
}