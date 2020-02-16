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

        public UserDTO AuthentificateUser(string login, string password)
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

        #region LateTicket

        #region CRUD

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

        #region Vote

        public void LikeLateTicket(UserLateDTO userLate)
        {
            ServiceLate service = new ServiceLate();
            service.LikeLateTicket(userLate);
        }

        public void DisLikeLateTicket(UserLateDTO userLate)
        {
            ServiceLate service = new ServiceLate();
            service.DisLikeLateTicket(userLate);
        }

        #endregion

        #region Commentary

        public void CreateCommentary()
        {
            ServiceLate service = new ServiceLate();
            service.CreateCommentary();
        }

        public void DeleteCommentary()
        {
            ServiceLate service = new ServiceLate();
            service.DeleteCommentary();
        }

        #endregion

        #endregion

        #region Links

        public List<UserLateDTO> GetLinks()
        {
            ServiceLate service = new ServiceLate();
            return service.GetLinks();
        }

        public UserLateDTO AddLinkUserToVote(UserLateDTO usersLate)
        {
            ServiceLate service = new ServiceLate();
            return service.AddLinkUserToVote(usersLate);
        }

        public UserLateDTO DeleteLinkUserToVote(UserLateDTO usersLate)
        {
            ServiceLate service = new ServiceLate();
            return service.DeleteLinkUserToVote(usersLate);
        }

        #endregion

    }
}
