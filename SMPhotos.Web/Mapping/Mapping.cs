using AutoMapper;
using SMPhotos.DAL;
using SMPhotos.Web.ViewModel;
using System;

namespace SMPhotos.Web
{
	public class MappingProfile : Profile
	{
		[Obsolete]
		protected override void Configure()
		{
			CreateMap<User, UserVM>()
				.ForMember(d => d.NewPassword, o => o.Ignore())
				.ForMember(d => d.ConfirmNewPassword, o => o.Ignore());
			CreateMap<Album, AlbumVM>();
			CreateMap<User, UserContext>();
		}
	}
}