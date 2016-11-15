using Microsoft.Practices.Unity;

namespace SMPhotos.Web.DependencyInjection
{
	public interface IWebTypeResolver
	{
		void RegisterType(IUnityContainer container);
	}
}
