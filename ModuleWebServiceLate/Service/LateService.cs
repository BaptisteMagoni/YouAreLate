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

        public List<UserDTO> GetUser()
        {
            try
            {
                return new List<UserDTO>(service.GetUser());
            }
            catch
            {
                return new List<UserDTO>();
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

        #region Like && DisLike

        public void LikeLateTicket(VoteDTO vote)
        {
            try
            {
                service.LikeLateTicket(vote);
            }
            catch
            {
                throw new Exception();
            }
        }

        public void DisLikeLateTicket(VoteDTO vote)
        {
            try
            {
                service.DisLikeLateTicket(vote);
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
            try
            {
                return service.GetCountLikesLate(ticket);
            }
            catch
            {
                return -1;
            }
        }

        public int GetCountDisLikeLate(LateTicketDTO ticket)
        {
            try
            {
                return service.GetCountDisLikeLate(ticket);
            }
            catch
            {
                return -1;
            }
        }

        public VoteDTO AddLinkUserToVote(VoteDTO vote)
        {
            try
            {
                return service.AddLinkUserToVote(vote);
            }
            catch
            {
                return null;
            }
        }

        public VoteDTO DeleteLinkUserToVote(VoteDTO vote)
        {
            try
            {
                return service.DeleteLinkUserToVote(vote);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #endregion

        #region Commentary

        public List<CommentaryDTO> GetCommentariesTicketLate(LateTicketDTO lateTicket)
        {
            try
            {
                return new List<CommentaryDTO>(service.GetCommentariesTicketLate(lateTicket));
            }
            catch
            {
                return new List<CommentaryDTO>();
            }
        }

        public CommentaryDTO CreateCommentary(CommentaryDTO commentary)
        {
            try
            {
                return service.CreateCommentary(commentary);
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
                service.DeleteCommentary(commentary);
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
