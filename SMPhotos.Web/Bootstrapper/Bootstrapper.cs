using SMPhotos.Web.DependencyInjection;

namespace SMPhotos.Web
{
	public static class Bootstrapper
	{
		public static void Initialize()
		{
			DependencyResolverConfig.RegisterType(
				new WebTypeResolver()
			);
		}
	}
}