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
                    ticket = bdd.LateTicket.Add(ticket);
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

    }
}