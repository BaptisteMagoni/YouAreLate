using ServiceReferenceLate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleWebServiceLate.Service
{
    public class LateService
    {

        private Service1Client service;

        public LateService()
        {
            service = new ServiceReferenceLate.Service1Client();
        }


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

        public users AuthentificateUser(string login, string password)
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


    }
}
