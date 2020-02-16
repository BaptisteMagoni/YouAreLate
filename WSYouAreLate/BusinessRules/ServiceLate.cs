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

        public Users AuthentificationUser(string login, string password)
        {
            return _lateDA.AuthentificateUser(login , password);
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

        public void LikeLateTicket(UserLateDTO userLate)
        {
            try
            {
                UsersLate ticket = _mapper.Map<UsersLate>(userLate);
                _lateDA.LikeLateTicket(ticket);
            }
            catch
            {
                throw new Exception();
            }
        }

        public void DisLikeLateTicket(UserLateDTO userLate)
        {
            try
            {
                UsersLate ticket = _mapper.Map<UsersLate>(userLate);
                _lateDA.DisLikeLateTicket(ticket);
            }
            catch
            {
                throw new Exception();
            }
        }

        #endregion

        #region Commentary

        public void CreateCommentary()
        {
            throw new NotImplementedException();
        }

        public void DeleteCommentary()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region UsersLate

        public List<UserLateDTO> GetLinks()
        {
            return _mapper.Map<List<UserLateDTO>>(_lateDA.GetLinks());
        }

        public UserLateDTO DeleteLinkUserToVote(UserLateDTO usersLate)
        {
            UsersLate link = _mapper.Map<UsersLate>(usersLate);
            return _mapper.Map<UserLateDTO>(_lateDA.DeleteLinkUserToVote(link));
        }

        public UserLateDTO AddLinkUserToVote(UserLateDTO usersLate)
        {
            UsersLate link = _mapper.Map<UsersLate>(usersLate);
            return _mapper.Map<UserLateDTO>(_lateDA.AddLinkUserToVote(link));
        }

        #endregion
    }
}