using SMPhotos.DAL;

namespace SMPhotos.Web.ViewModel
{
	public class ImageVM : Base
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int AlbumId { get; set; }
		public virtual Album Album { get; set; }
	}
}