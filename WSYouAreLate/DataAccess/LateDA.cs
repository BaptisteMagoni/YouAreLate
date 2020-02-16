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

        public void LikeLateTicket(UsersLate usersLate)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    UsersLate late = bdd.UsersLate.Where(x => x.iduser == usersLate.iduser && x.idlate == usersLate.idlate).FirstOrDefault();
                    late.Vote = 1;
                }
            }
            catch
            {

            }
        }

        public void DisLikeLateTicket(UsersLate usersLate)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    UsersLate late = bdd.UsersLate.Where(x => x.iduser == usersLate.iduser && x.idlate == usersLate.idlate).FirstOrDefault();
                    late.Vote = -1;
                }
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

        #region UsersLate

        public List<UsersLate> GetLinks()
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    return bdd.UsersLate.ToList();
                }
            }
            catch
            {
                return new List<UsersLate>();
            }
        }

        public UsersLate AddLinkUserToVote(UsersLate usersLate)
        {

            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    UsersLate link = bdd.UsersLate.Add(usersLate);
                    bdd.SaveChanges();
                    return link;

                }
            }
            catch
            {
                return null;
            }
        }

        public UsersLate DeleteLinkUserToVote(UsersLate usersLate)
        {
            try
            {
                using(ModelLate bdd = new ModelLate())
                {
                    UsersLate link = bdd.UsersLate.Remove(usersLate);
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
    }
}