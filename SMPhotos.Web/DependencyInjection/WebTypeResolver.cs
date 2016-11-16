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
			container.RegisterType<DbContext, SMPContext>(new InjectionConstructor());
			container.RegisterType<IUnitOfWork, UnitOfWork>();
			container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
		}
	}
}