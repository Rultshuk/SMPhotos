using Microsoft.Practices.Unity;

namespace SMPhotos.Web.DependencyInjection
{
	public class WebTypeResolver : IWebTypeResolver
	{
		public void RegisterType(IUnityContainer container)
		{
			//container.RegisterInstance<IMapper>(Mapper.Configuration.CreateMapper());
			//container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
		}
	}
}