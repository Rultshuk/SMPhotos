namespace SMPhotos.DAL
{
	using System.Data.Entity;

	public partial class SMPContext : DbContext
	{
		public SMPContext()
			: base("name=SMPContext")
		{
		}

		public virtual DbSet<Album> Album { get; set; }
		public virtual DbSet<Image> Image { get; set; }
		public virtual DbSet<User> User { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("smp");

			modelBuilder.Entity<Image>().ToTable("Image").HasKey(t => t.Id);
			modelBuilder.Entity<Image>().Property(t => t.Name).HasMaxLength(128).IsRequired();
			modelBuilder.Entity<Image>().Property(t => t.Name).HasMaxLength(64);

			modelBuilder.Entity<User>().ToTable("User").HasKey(t => t.Id);
			modelBuilder.Entity<User>().Property(t => t.Email).HasMaxLength(128).IsRequired();
			modelBuilder.Entity<User>().Property(t => t.Password).HasMaxLength(128).IsRequired();
			modelBuilder.Entity<User>().Property(t => t.FirstName).HasMaxLength(64);
			modelBuilder.Entity<User>().Property(t => t.LastName).HasMaxLength(64);
			modelBuilder.Entity<User>().Property(t => t.Location).HasMaxLength(64);

			modelBuilder.Entity<Album>().ToTable("Album").HasKey(t => t.Id);
			modelBuilder.Entity<Album>().Property(t => t.Name).HasMaxLength(128).IsRequired();
			modelBuilder.Entity<Album>().Property(t => t.Description).HasMaxLength(64);
			modelBuilder.Entity<Album>()
				.HasMany(e => e.Image)
				.WithRequired(e => e.Album)
				.WillCascadeOnDelete(false);
		}
	}
}
