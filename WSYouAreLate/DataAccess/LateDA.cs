using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSYouAreLate.DTO;
using WSYouAreLate.Entities;

namespace WSYouAreLate.DataAccess
{
    public class LateDA
    {
        
        #region Users
        public List<Users> GetUsers()
        {
            using(ModelLate bdd = new ModelLate())
            {
                try
                {
                    var test = bdd.Users.ToList();
                    return test;
                }
                catch
                {
                    return null;
                }
                
            }
        }
        
        public Users AuthentificateUser(string login, string password)
        {
            using(ModelLate bdd = new ModelLate())
            {
                try
                {
                    return bdd.Users.Where(x => x.identifiant == login && x.password == password).ToList().FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        public Users CreateUser(Users users)
        {
            using(ModelLate bdd = new ModelLate())
            {
                try
                {
                    bdd.Users.Add(users);
                    bdd.SaveChanges();
                    return users;
                }
                catch(Exception e)
                {
                    return null;
                }
            }
        }
        #endregion

        #region LateTicket

        #region CRUD

        public List<LateTicket> GetLateTickets()
        {

            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    return bdd.LateTicket.ToList();
                }
            }
            catch
            {
                return new List<LateTicket>();
            }

        }

        public LateTicket DeleteLateTicket(LateTicket lateTicket)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    LateTicket ticket = bdd.LateTicket.Remove(lateTicket);
                    bdd.SaveChanges();
                    return ticket;
                }
            }
            catch
            {
                return null;
            }
        }

        public LateTicket UpdateLateTicket(LateTicket lateTicket)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    LateTicket ticket = bdd.LateTicket.Where(x => x.id == lateTicket.id).FirstOrDefault();
                    ticket.image = lateTicket.image;
                    ticket.Subject = lateTicket.Subject;
                    bdd.SaveChanges();
                    return ticket;
                }
            }
            catch
            {
                return null;
            }
        }

        public LateTicket CreateLateTicket(LateTicket lateTicket)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    LateTicket ticket = bdd.LateTicket.Add(lateTicket);
                    bdd.SaveChanges();
                    return ticket;
                }
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Vote

        #region Like && DisLike

        public void LikeLateTicket(UserVote usersLate)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    usersLate.Vote = 1;
                    UserVote late = bdd.UserVote.Add(usersLate);
                    bdd.SaveChanges();
                }
            }
            catch(Exception e)
            {

            }
        }

        public void DisLikeLateTicket(UserVote usersLate)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    usersLate.Vote = -1;
                    UserVote late = bdd.UserVote.Add(usersLate);
                    bdd.SaveChanges();
                }
            }
            catch
            {

            }
        }

        #endregion

        #region CRUD

        public int GetCountLikesLate(LateTicket ticket)
        {
            try
            {
                using (ModelLate bdd = new ModelLate())
                {
                    return bdd.UserVote.Where(x => x.idlate == ticket.id && x.Vote == 1).Count();
                }
            }
            catch
            {
                return -1;
            }
        }

        public int GetCountDisLikeLate(LateTicket ticket)
        {
            try
            {
                using (ModelLate bdd = new ModelLate())
                {
                    return bdd.UserVote.Where(x => x.idlate == ticket.id && x.Vote == -1).Count();
                }
            }
            catch
            {
                return -1;
            }
        }

        public UserVote AddLinkUserToVote(UserVote vote)
        {

            try
            {
                using (ModelLate bdd = new ModelLate())
                {
                    UserVote link = bdd.UserVote.Add(vote);
                    bdd.SaveChanges();
                    return link;

                }
            }
            catch
            {
                return null;
            }
        }

        public UserVote DeleteLinkUserToVote(UserVote vote)
        {
            try
            {
                using (ModelLate bdd = new ModelLate())
                {
                    UserVote link = bdd.UserVote.Remove(vote);
                    bdd.SaveChanges();
                    return link;
                }
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #endregion

        #region Commentary

        public Commentary CreateCommentary(Commentary commentary)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    Commentary comment = bdd.Commentary.Add(commentary);
                    bdd.SaveChanges();
                    return comment;
                }
            }
            catch
            {
                return null;
            }
        }

        public void DeleteCommentary(Commentary commentary)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    bdd.Commentary.Remove(commentary);
                    bdd.SaveChanges();
                }
            }
            catch
            {

            }
        }

        #endregion

        #endregion

    }
}