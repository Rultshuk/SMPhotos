using AutoMapper;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using SMPhotos.DAL;
using System.Data.Entity;
using System.Web.Mvc;

namespace SMPhotos.Web.DependencyInjection
{
	public class WebTypeResolver : IWebTypeResolver
	{
		public void RegisterType(IUnityContainer container)
		{
			container.RegisterType<DbContext, SMPContext>(new InjectionConstructor());
			container.RegisterType<IUnitOfWork, UnitOfWork>();
			container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
			container.RegisterType<IAlbumRepository, AlbumRepository>(new HierarchicalLifetimeManager());
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}