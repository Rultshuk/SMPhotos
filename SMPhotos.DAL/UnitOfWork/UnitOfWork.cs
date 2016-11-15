namespace SMPhotos.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SMPContext Context;

		public UnitOfWork(SMPContext context)
		{
			Context = context;
			Users = new UserRepository(Context);
			Images = new Repository<Image>(Context);
			Albums = new Repository<Album>(Context);
		}

		public IUserRepository Users { get; private set; }
		public IRepository<Image> Images { get; private set; }
		public IRepository<Album> Albums { get; private set; }

		public int Save()
		{
			return Context.SaveChanges();
		}
		public void Dispose()
		{
			Context.Dispose();
		}
	}
}
