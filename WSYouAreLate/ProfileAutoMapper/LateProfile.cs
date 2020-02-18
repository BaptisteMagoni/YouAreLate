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

            CreateMap<UserVote, VoteDTO>();
            CreateMap<VoteDTO, UserVote>();

            CreateMap<LateTicket, LateTicketDTO>();
            CreateMap<LateTicketDTO, LateTicket>();

            CreateMap<Commentary, CommentaryDTO>();
            CreateMap<CommentaryDTO, Commentary>();
        }
    }
}