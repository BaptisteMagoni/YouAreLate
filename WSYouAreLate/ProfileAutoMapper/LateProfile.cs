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
            CreateMap<Users, UserDTO>();
            CreateMap<UserDTO, Users>();

            CreateMap<UsersLate, UserLateDTO>();
            CreateMap<UserLateDTO, UsersLate>();

            CreateMap<LateTicket, LateTicketDTO>();
            CreateMap<LateTicketDTO, LateTicket>();
        }
    }
}