using ServiceReferenceLate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ModuleWebServiceLate.Service
{
    public class LateService
    {

        private Service1Client service;

        public LateService()
        {
            service = new Service1Client();
        }

        #region Users

        public List<UserDTO> GetUser()
        {
            try
            {
                return new List<UserDTO>(service.GetUser());
            }
            catch
            {
                return null;
            }
        }

        public UserDTO AuthentificateUser(string login, string password)
        {
            try
            {
                return service.AuthentificateUser(login, password);
            }
            catch
            {
                return null;
            }
        }

        public UserDTO CreateUser(UserDTO user)
        {
            try
            {
                return service.CreateUser(user);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region LateTicket

        #region CRUD

        public List<LateTicketDTO> GetLateTickets()
        {
            try
            {
                return new List<LateTicketDTO>(service.GetLateTickets());
            }
            catch
            {
                return new List<LateTicketDTO>();
            }
        }

        public LateTicketDTO UpdateLateTicket(LateTicketDTO lateTicket)
        {
            try
            {
                return service.UpdateLateTicket(lateTicket);
            }
            catch
            {
                return null;
            }
        }

        public LateTicketDTO DeleteLateTicket(LateTicketDTO lateTicket)
        {
            try
            {
                return service.DeleteLateTicket(lateTicket);
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
                return service.CreateLateTicket(lateTicket);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Vote

        public void LikeLateTicket(UserLateDTO usersLate)
        {
            try
            {
                service.LikeLateTicket(usersLate);
            }
            catch
            {

            }
        }

        public void DisLikeLateTicket(UserLateDTO usersLate)
        {
            try
            {
                service.DisLikeLateTicket(usersLate);
            }
            catch
            {

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

        #region Links

        public List<UserLateDTO> GetLinks()
        {
            try
            {
                return new List<UserLateDTO>(service.GetLinks());
            }
            catch
            {
                return new List<UserLateDTO>();
            }
        }

        public UserLateDTO AddLinkUserToVote(UserLateDTO userLate)
        {
            try
            {
                return service.AddLinkUserToVote(userLate);
            }
            catch
            {
                return null;
            }
        }

        public UserLateDTO DeleteLinkUserToVote(UserLateDTO userLate)
        {
            try
            {
                return service.DeleteLinkUserToVote(userLate);
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
