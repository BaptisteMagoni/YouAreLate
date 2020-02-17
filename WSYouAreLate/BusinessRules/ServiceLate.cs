using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSYouAreLate.DataAccess;
using WSYouAreLate.DTO;
using WSYouAreLate.Entities;
using WSYouAreLate.ProfileAutoMapper;

namespace WSYouAreLate.BusinessRules
{
    public class ServiceLate
    {

        private LateDA _lateDA;
        private readonly IMapper _mapper;

        public ServiceLate()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.AddProfile(typeof(LateProfile)); });
            _mapper = config.CreateMapper(); //Permet de créer un nouveau Mapper
            _lateDA = new LateDA();
        }

        #region Users

        public List<UserDTO> GetUsers()
        {
            try
            {
                List<Users> users = _lateDA.GetUsers();
                List<UserDTO> usersDTO = _mapper.Map<List<UserDTO>>(users);
                return usersDTO;
            }
            catch
            {
                return null;
            }
            
        }

        public UserDTO AuthentificationUser(string login, string password)
        {
            return _mapper.Map<UserDTO>(_lateDA.AuthentificateUser(login, password));
        }

        public UserDTO CreateUser(UserDTO user)
        {
            Users newUser = _mapper.Map<Users>(user);
            Users u = _lateDA.CreateUser(newUser);
            UserDTO userDTO = _mapper.Map<UserDTO>(u);
            return userDTO;
        }

        #endregion

        #region LateTicket

        #region CRUD

        public List<LateTicketDTO> GetLateTickets()
        {
            try
            {
                List<LateTicket> ticket = _lateDA.GetLateTickets();
                return _mapper.Map<List<LateTicketDTO>>(ticket);
            }
            catch
            {
                return new List<LateTicketDTO>();
            }
        }

        public LateTicketDTO DeleteLateTicket(LateTicketDTO lateTicket)
        {
            try
            {
                LateTicket ticket = _mapper.Map<LateTicket>(lateTicket);
                return _mapper.Map<LateTicketDTO>(_lateDA.DeleteLateTicket(ticket));
            }
            catch
            {
                return null;
            }
        }

        public LateTicketDTO UpdateLateTicket(LateTicketDTO lateTicket)
        {
            try
            {
                LateTicket ticket = _mapper.Map<LateTicket>(lateTicket);
                return _mapper.Map<LateTicketDTO>(_lateDA.UpdateLateTicket(ticket));
            }
            catch
            {
                return null;
            }
        }

        public LateTicketDTO CreateLateTicket(LateTicketDTO lateTicket)
        {
            try
            {
                LateTicket ticket = _mapper.Map<LateTicket>(lateTicket);
                return _mapper.Map<LateTicketDTO>(_lateDA.CreateLateTicket(ticket));
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Vote

        #region Like && DisLike

        public void LikeLateTicket(VoteDTO voteDTO)
        {
            try
            {
                UserVote vote = _mapper.Map<UserVote>(voteDTO);
                _lateDA.LikeLateTicket(vote);
            }
            catch
            {
                throw new Exception();
            }
        }

        public void DisLikeLateTicket(VoteDTO userLate)
        {
            try
            {
                UserVote ticket = _mapper.Map<UserVote>(userLate);
                _lateDA.DisLikeLateTicket(ticket);
            }
            catch
            {
                throw new Exception();
            }
        }

        #endregion

        #region CRUD

        public int GetCountLikesLate(LateTicketDTO ticket)
        {
            LateTicket userVote = _mapper.Map<LateTicket>(ticket);
            return _lateDA.GetCountLikesLate(userVote);
        }
        public int GetCountDisLikeLate(LateTicketDTO ticket)
        {
            LateTicket late = _mapper.Map<LateTicket>(ticket);
            return _lateDA.GetCountDisLikeLate(late);
        }

        public VoteDTO DeleteLinkUserToVote(VoteDTO vote)
        {
            UserVote link = _mapper.Map<UserVote>(vote);
            return _mapper.Map<VoteDTO>(_lateDA.DeleteLinkUserToVote(link));
        }

        public VoteDTO AddLinkUserToVote(VoteDTO vote)
        {
            UserVote link = _mapper.Map<UserVote>(vote);
            return _mapper.Map<VoteDTO>(_lateDA.AddLinkUserToVote(link));
        }


        #endregion

        #endregion

        #region Commentary

        public CommentaryDTO CreateCommentary(CommentaryDTO commentary)
        {
            try
            {
                Commentary comment = _mapper.Map<Commentary>(commentary);
                return _mapper.Map<CommentaryDTO>(_lateDA.CreateCommentary(comment));
            }
            catch
            {
                return null;
            }
        }

        public void DeleteCommentary(CommentaryDTO commentary)
        {
            try
            {
                Commentary comment = _mapper.Map<Commentary>(commentary);
                _lateDA.DeleteCommentary(comment);
            }
            catch
            {
                throw new Exception();
            }
        }

        #endregion

        #endregion
    }
}