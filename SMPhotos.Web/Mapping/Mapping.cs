using System;
using AutoMapper;
using SMPhotos.DAL;
using SMPhotos.Web.ViewModel;

namespace SMPhotos.Web
{
	public class MappingProfile : Profile
	{
		[Obsolete]
		protected override void Configure()
		{
			CreateMap<User, UserVM>()
				.ForMember(d => d.NewPassword, o => o.Ignore())
				.ForMember(d => d.Message, o => o.Ignore())
				.ForMember(d => d.ConfirmNewPassword, o => o.Ignore());
			CreateMap<Album, AlbumVM>()
				.ForMember(d => d.Message, o => o.Ignore())
				.ForMember(d => d.PathAlbum, o => o.Ignore());
			CreateMap<Album, PictureVM>()
				.ForMember(d => d.Message, o => o.Ignore())
				.ForMember(d => d.files, o => o.Ignore());
			CreateMap<User, UserContext>();
			CreateMap<Image, ImageVM>();
		}
	}
}