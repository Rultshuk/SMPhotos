namespace SMPhotos.DAL
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class SMPContext : DbContext
	{
		public SMPContext()
			: base("name=SMPContext")
		{
		}

		public virtual DbSet<Album> Albums { get; set; }
		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Album>()
				.HasMany(e => e.Images)
				.WithRequired(e => e.Album)
				.WillCascadeOnDelete(false);
		}
	}
}
