using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.AppUserRegisterDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();
            CreateMap<AppUser, AppUserRegisterAddDTOs>().ReverseMap();


            CreateMap<AppUser, AppUserLoginAddDTOs>().ReverseMap();


            CreateMap<Announcement, AnnouncementListDTO>().ReverseMap();


            CreateMap<Announcement, AnnouncementUpdateDto>().ReverseMap();

            CreateMap<SendMessageDto, ContactUs>().ReverseMap();
        }
    }
}
