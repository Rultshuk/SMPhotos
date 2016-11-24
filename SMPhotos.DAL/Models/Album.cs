using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMPhotos.DAL
{
	public class Album:Base
	{

		public Album()
		{
			Image = new HashSet<Image>();
		}
		public string Name { get; set; }
		//[DataType(DataType.MultilineText)]
		public string Description { get; set; }
		public string Path { get; set; }
		public Guid Guid { get; set; }
		public virtual ICollection<Image> Image { get; set; }
	}
}
