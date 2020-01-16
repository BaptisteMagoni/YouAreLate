using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSYouAreLate.DataAccess;
using WSYouAreLate.Entities;

namespace WSYouAreLate.BusinessRules
{
    public class ServiceLate
    {

        private DaLate da;

        public ServiceLate()
        {
            da = new DaLate();
        }

        public List<users> GetUsers()
        {
            return da.GetUsers();
        }

        public users AuthentificationUser(string login, string password)
        {
            return da.AuthentificateUser(login , password);
        }

        public users CreateUser(users users)
        {
            return da.CreateUser(users);
        }

    }
}