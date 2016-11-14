using System.Data.Entity.ModelConfiguration;

namespace SMPhotos.DAL
{
	public class UserMap : EntityTypeConfiguration<User>
	{
		public UserMap()
		{
			ToTable("User", "smp").HasKey(t => t.Id);
			Property(t => t.Email).HasMaxLength(128).IsRequired();
			Property(t => t.Password).HasMaxLength(128).IsRequired();
			Property(t => t.FirstName).HasMaxLength(64);
			Property(t => t.LastName).HasMaxLength(64);
			Property(t => t.Location).HasMaxLength(64);
		}
	}
}
