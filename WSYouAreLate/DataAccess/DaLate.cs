using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSYouAreLate.Entities;

namespace WSYouAreLate.DataAccess
{
    public class DaLate
    {

        public List<users> GetUsers()
        {
            using(ModelLate bdd = new ModelLate())
            {
                try
                {
                    return bdd.users.ToList();
                }
                catch
                {
                    return null;
                }
                
            }
        }
        
        public users AuthentificateUser(string login, string password)
        {
            using(ModelLate bdd = new ModelLate())
            {
                try
                {
                    return bdd.users.Where(x => x.identifiant == login && x.password == password).ToList().FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        public users CreateUser(users users)
        {
            using(ModelLate bdd = new ModelLate())
            {
                try
                {
                    bdd.users.Add(users);
                    bdd.SaveChanges();
                    return users;
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}