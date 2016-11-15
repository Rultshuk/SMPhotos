namespace SMPhotos.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SMPContext _dbContext;

		public UnitOfWork(SMPContext dbcontext)
		{
			_dbContext = dbcontext;
			Users = new UserRepository(_dbContext);
			Images = new Repository<Image>(_dbContext);
			Albums = new Repository<Album>(_dbContext);
		}

		public IUserRepository Users { get; private set; }
		public IRepository<Image> Images { get; private set; }
		public IRepository<Album> Albums { get; private set; }

		public int Save()
		{
			return _dbContext.SaveChanges();
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
