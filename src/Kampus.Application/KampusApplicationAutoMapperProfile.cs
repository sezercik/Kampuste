using System;
using AutoMapper;
using Kampus.Posts;
using Kampus.PostsLikes;
using Kampus.Users;
using Kampus.UserSettings;
using Volo.Abp.Account;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace Kampus;

public class KampusApplicationAutoMapperProfile : Profile
{
    public KampusApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        // CreateMap<Book, BookDto>();
        // CreateMap<CreateUpdateBookDto, Book>();
        // typeof(IdentityUserDto),
        //                         typeof(ProfileDto),
        //                         typeof(UserData),
        //                         typeof(UpdateProfileDto),
        //                         typeof(RegisterDto),
        //                         typeof(IdentityUserCreateDto),
        //                         typeof(IdentityUserUpdateDto)
        //
        // context.MapperConfiguration.CreateMap<ProfileDto, CustomProfileDto>();
        // context.MapperConfiguration.CreateMap<UpdateProfileDto, CustomProfileDto>();
        // context.MapperConfiguration.CreateMap<IdentityUserCreateOrUpdateDtoBase, CustomProfileDto>();

        CreateMap<UserSettings.UserSetting, UserSettingDto>();
        CreateMap<CreateUserSettingDto, UserSetting>();
        CreateMap<UpdateUserSettingDto, UserSetting>();

        CreateMap<Post, PostDto>();
        CreateMap<CreatePostDto, Post>();

        CreateMap<PostLike, PostLikeDto>();
        CreateMap<CreatePostLikeDto, PostLike>();
        
        
        CreateMap<UpdateProfileDto, CustomUpdateProfileDto>()
            .ForMember(dest => dest.TcKimlikNo, opt => opt.MapFrom(src => src.GetProperty<string>("TcKimlikNo","1111111111")))
            .ForMember(dest => dest.UniversityEmail, opt => opt.MapFrom(src => src.GetProperty<string>("UniversityEmail","girilmedi@none.edu.tr")))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.GetProperty<DateTime?>("BirthDate",DateTime.Today))); // Nullable DateTime
        CreateMap<IdentityUserCreateOrUpdateDtoBase, CustomIdentityUserCreateOrUpdateDtoBase>()
            .ForMember(dest => dest.TcKimlikNo, opt => opt.MapFrom(src => src.GetProperty<string>("TcKimlikNo","1111111111")))
            .ForMember(dest => dest.UniversityEmail, opt => opt.MapFrom(src => src.GetProperty<string>("UniversityEmail","girilmedi@none.edu.tr")))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.GetProperty<DateTime?>("BirthDate",DateTime.Today))); // Nullable DateTime
        CreateMap<ProfileDto, CustomProfileDto>()
            .ForMember(dest => dest.TcKimlikNo, opt => opt.MapFrom(src => src.GetProperty<string>("TcKimlikNo","1111111111")))
            .ForMember(dest => dest.UniversityEmail, opt => opt.MapFrom(src => src.GetProperty<string>("UniversityEmail","girilmedi@none.edu.tr")))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.GetProperty<DateTime?>("BirthDate",DateTime.Today))); // Nullable DateTime

        CreateMap<IdentityUserDto, CustomIdentityUserDto>()
            .ForMember(dest => dest.TcKimlikNo, opt => opt.MapFrom(src => src.GetProperty<string>("TcKimlikNo","1111111111")))
            .ForMember(dest => dest.UniversityEmail, opt => opt.MapFrom(src => src.GetProperty<string>("UniversityEmail","girilmedi@none.edu.tr")))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.GetProperty<DateTime?>("BirthDate",DateTime.Today))); // Nullable DateTime

        CreateMap<RegisterDto, CustomRegisterDto>()
            .ForMember(dest => dest.TcKimlikNo, opt => opt.MapFrom(src => src.GetProperty<string>("TcKimlikNo","1111111111")))
            .ForMember(dest => dest.UniversityEmail, opt => opt.MapFrom(src => src.GetProperty<string>("UniversityEmail","girilmedi@none.edu.tr")))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.GetProperty<DateTime?>("BirthDate",DateTime.Today))); // Nullable DateTime

    }
}
