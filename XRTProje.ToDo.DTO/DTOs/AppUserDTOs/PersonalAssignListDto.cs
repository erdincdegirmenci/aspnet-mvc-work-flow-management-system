using System;
using System.Collections.Generic;
using System.Text;
using XRTProje.ToDo.DTO.DTOs.DutyDTOs;

namespace XRTProje.ToDo.DTO.DTOs.AppUserDTOs
{
    public class PersonalAssignListDto
    {
        public AppUserListDto AppUser { get; set; }
        public DutyListDto Duty { get; set; }

    }
}
