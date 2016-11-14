using System.Data.Entity.ModelConfiguration;

namespace SMPhotos.DAL
{
	public class AlbumMap : EntityTypeConfiguration<Album>
	{
		public AlbumMap()
		{
			ToTable("Album", "smp").HasKey(t => t.Id);
			Property(t => t.Name).HasMaxLength(128).IsRequired();
			Property(t => t.Description).HasMaxLength(64);
			HasMany(e => e.Image).WithRequired(e => e.Album).WillCascadeOnDelete(false);
		}
	}
}
