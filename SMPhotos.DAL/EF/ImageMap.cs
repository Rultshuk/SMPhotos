using System.Data.Entity.ModelConfiguration;

namespace SMPhotos.DAL
{
	public class ImageMap : EntityTypeConfiguration<Image>
	{
		public ImageMap()
		{
			ToTable("Image", "smp").HasKey(t => t.Id);
			Property(t => t.Name).HasMaxLength(128).IsRequired();
			Property(t => t.Name).HasMaxLength(64);
		}
	}
}
