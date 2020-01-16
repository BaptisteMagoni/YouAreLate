using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSYouAreLate.DTO;
using WSYouAreLate.Entities;

namespace WSYouAreLate.ProfileAutoMapper
{
    public class LateProfile : Profile
    {
        public LateProfile()
        {
            CreateMap<users, UserDTO>();
            CreateMap<UserDTO, users>();

            CreateMap<users_late, UserLateDTO>();
            CreateMap<UserLateDTO, users_late>();

            CreateMap<lateticket, LateTicketDTO>();
            CreateMap<LateTicketDTO, lateticket>();
        }
    }
}