using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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

        #region User

        [OperationContract]
        void AuthentificateUser();

        [OperationContract]
        void CreateUser();

        [OperationContract]
        void CreateCommentary();

        [OperationContract]
        void DeleteCommentary();
        #endregion

        #region LateNotification

        #region CRUD Notification

        [OperationContract]
        void GetLateNotification();

        [OperationContract]
        void DeleteLateNotification();

        [OperationContract]
        void UpdateLateNotification();

        [OperationContract]
        void CreateLateNotification();

        #endregion

        #region Option Notification

        [OperationContract]
        void LikeLateNotification();

        [OperationContract]
        void DisLikeLateNotification();

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
