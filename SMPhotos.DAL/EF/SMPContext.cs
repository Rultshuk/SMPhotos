using System.Data.Entity;
using SMPhotos.DAL;


namespace SMPhotos.DAL
{
	public class SMPContext : DbContext
	{
		public SMPContext() : base(string.Format("name={0}", DbConnection.SMPContext)) { }

		public virtual DbSet<Album> Album { get; set; }
		public virtual DbSet<Image> Image { get; set; }
		public virtual DbSet<User> User { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new ImageMap());
			modelBuilder.Configurations.Add(new AlbumMap());
		}
	}
}
