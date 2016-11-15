using AutoMapper;
using Microsoft.Practices.Unity;
using SMPhotos.DAL;
using System.Data.Entity;


namespace SMPhotos.Web.DependencyInjection
{
	public class WebTypeResolver : IWebTypeResolver
	{
		public void RegisterType(IUnityContainer container)
		{
			/*container.RegisterInstance<IMapper>(Mapper.Configuration.CreateMapper());

			container.RegisterType<DbContext, SMPContext>(new InjectionConstructor(string.Format("name={0}", DbConnection.SMPContext)));
			container.RegisterType<IUnitOfWork, UnitOfWork>();
			container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());*/
		}
	}
}