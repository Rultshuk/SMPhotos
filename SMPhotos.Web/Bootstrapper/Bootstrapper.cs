using AutoMapper;
using Microsoft.Practices.Unity.Mvc;
using SMPhotos.Web.DependencyInjection;
using System.Web.Mvc;

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