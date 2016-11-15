namespace SMPhotos.DAL
{
	public class Image:Base
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int AlbumId { get; set; }
		public virtual Album Album { get; set; }
	}
}
