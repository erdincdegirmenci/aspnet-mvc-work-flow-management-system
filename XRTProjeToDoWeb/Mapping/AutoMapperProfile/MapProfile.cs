using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XRTProje.ToDo.DTO.DTOs.AppUserDTOs;
using XRTProje.ToDo.DTO.DTOs.DutyDTOs;
using XRTProje.ToDo.DTO.DTOs.NotificationDTOs;
using XRTProje.ToDo.DTO.DTOs.ReportDTOS;
using XRTProje.ToDo.DTO.DTOs.UrgencyDTOs;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Urgency-UrgencyDto
            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();
            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();
            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();
            #endregion

            #region AppUser-AppUserDto
            CreateMap<AppUserSignUpDto, AppUser>();
            CreateMap<AppUser, AppUserSignUpDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region Notification-NotificationDto
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Duty-DutyDto
            CreateMap<DutyAddDto, Duty>();
            CreateMap<Duty, DutyAddDto>();
            CreateMap<DutyListDto, Duty>();
            CreateMap<Duty, DutyListDto>();
            CreateMap<DutyUpdateDto, Duty>();
            CreateMap<Duty, DutyUpdateDto>();
            CreateMap<DutyListAllDto, Duty>();
            CreateMap<Duty, DutyListAllDto>();
            #endregion

            #region Report-ReportDto
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>();
            CreateMap<Report, ReportFileDto>();
            CreateMap<ReportFileDto, Report>();
            #endregion

        }
    }
}
