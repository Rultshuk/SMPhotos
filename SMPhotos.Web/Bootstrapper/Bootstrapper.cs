using AutoMapper;
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

			Mapper.Initialize(config =>
			{
				config.AddProfile(new MappingProfile());
			});
			Mapper.AssertConfigurationIsValid();

		}
	}
}