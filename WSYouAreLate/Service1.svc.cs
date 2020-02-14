using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WSYouAreLate.BusinessRules;
using WSYouAreLate.DTO;
using WSYouAreLate.Entities;

namespace WSYouAreLate
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        #region Users

        public Users AuthentificateUser(string login, string password)
        {
            ServiceLate service = new ServiceLate();
            return service.AuthentificationUser(login, password);
        }

        public List<UserDTO> GetUser()
        {
            ServiceLate service = new ServiceLate();
            return service.GetUsers();
        }

        public UserDTO CreateUser(UserDTO user)
        {
            ServiceLate service = new ServiceLate();
            return service.CreateUser(user);
        }

        #endregion

        public void CreateCommentary()
        {
            throw new NotImplementedException();
        }

        public void DeleteCommentary()
        {
            throw new NotImplementedException();
        }

        #region LateTicket

        public List<LateTicketDTO> GetLateTickets()
        {
            ServiceLate service = new ServiceLate();
            return service.GetLateTickets();

        }

        public LateTicketDTO DeleteLateTicket(LateTicketDTO lateTicket)
        {
            ServiceLate service = new ServiceLate();
            return service.DeleteLateTicket(lateTicket);
        }

        public LateTicketDTO UpdateLateTicket(LateTicketDTO lateTicket)
        {
            ServiceLate service = new ServiceLate();
            return service.UpdateLateTicket(lateTicket);
        }

        public LateTicketDTO CreateLateTicket(LateTicketDTO lateTicket)
        {
            ServiceLate service = new ServiceLate();
            return service.CreateLateTicket(lateTicket);
        }

        #endregion

        public void LikeLateTicket(LateTicketDTO lateTicket)
        {
            throw new NotImplementedException();
        }

        public void DisLikeLateTicket(LateTicketDTO lateTicketDTO)
        {
            throw new NotImplementedException();
        }


    }
}
