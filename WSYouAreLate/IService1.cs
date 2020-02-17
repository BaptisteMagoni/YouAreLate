using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WSYouAreLate.DTO;
using WSYouAreLate.Entities;

namespace WSYouAreLate
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici

        #region Users

        [OperationContract]
        List<UserDTO> GetUser();

        [OperationContract]
        UserDTO AuthentificateUser(string login, string password);

        [OperationContract]
        UserDTO CreateUser(UserDTO user);
        
        #endregion

        #region LateTicket

        #region CRUD

        [OperationContract]
        List<LateTicketDTO> GetLateTickets();

        [OperationContract]
        LateTicketDTO DeleteLateTicket(LateTicketDTO lateTicket);

        [OperationContract]
        LateTicketDTO UpdateLateTicket(LateTicketDTO lateTicket);

        [OperationContract]
        LateTicketDTO CreateLateTicket(LateTicketDTO lateTicket);

        #endregion

        #region Vote

        #region Like && DisLike

        [OperationContract]
        void LikeLateTicket(VoteDTO usersLate);

        [OperationContract]
        void DisLikeLateTicket(VoteDTO usersLate);

        #endregion

        #region CRUD

        [OperationContract]
        int GetLikesLate(VoteDTO vote);

        [OperationContract]
        int GetDisLikeLate(VoteDTO vote);

        [OperationContract]
        VoteDTO AddLinkUserToVote(VoteDTO usersLate);

        [OperationContract]
        VoteDTO DeleteLinkUserToVote(VoteDTO usersLate);
        #endregion

        #endregion

        #region Commentary

        [OperationContract]
        CommentaryDTO CreateCommentary(CommentaryDTO commentary);

        [OperationContract]
        void DeleteCommentary(CommentaryDTO commentary);

        #endregion

        #endregion
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
