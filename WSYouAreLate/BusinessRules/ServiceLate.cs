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

        public List<UserDTO> GetUsers()
        {
            try
            {
                List<users> users = _lateDA.GetUsers();
                List<UserDTO> usersDTO = _mapper.Map<List<UserDTO>>(users);
                return usersDTO;
            }
            catch
            {
                return null;
            }
            
        }

        public users AuthentificationUser(string login, string password)
        {
            return _lateDA.AuthentificateUser(login , password);
        }

        public UserDTO CreateUser(users user)
        {
            users u = _lateDA.CreateUser(user);
            UserDTO userDTO = _mapper.Map<UserDTO>(u);
            return userDTO;
        }
    }
}