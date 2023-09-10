using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrate;
using NetCore_TraversalApp.Areas.Admin.Models;

namespace NetCore_TraversalApp.Mapping.MapProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTOs, Announcement>();
            CreateMap<Announcement, AnnouncementAddDTOs>();

            CreateMap<AppUserRegisterDTOs, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTOs>();

            CreateMap<AppUserSignInDTOs, AppUser>();
            CreateMap<AppUser, AppUserSignInDTOs>();

            CreateMap<AnnouncementListDTOs, Announcement>();
            CreateMap<Announcement, AnnouncementListDTOs>();

            CreateMap<AnnouncementUpdateDTOs, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDTOs>();


        }
    }
}
