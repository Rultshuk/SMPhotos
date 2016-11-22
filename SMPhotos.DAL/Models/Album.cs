using System;
using System.Collections.Generic;
namespace SMPhotos.DAL
{
	public class Album:Base
	{

		public Album()
		{
			Image = new HashSet<Image>();
		}
		public string Name { get; set; }
		public string Description { get; set; }
		public string Path { get; set; }
		public Guid Guid { get; set; }
		public virtual ICollection<Image> Image { get; set; }
	}
}
