namespace SMPhotos.DAL
{
	using System.Collections.Generic;

	public partial class Album
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Album()
		{
			Image = new HashSet<Image>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Image> Image { get; set; }
	}
}
