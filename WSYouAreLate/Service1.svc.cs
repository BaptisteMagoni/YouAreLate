using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSYouAreLate
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public void AuthentificateUser()
        {
            throw new NotImplementedException();
        }

        public void CreateCommentary()
        {
            throw new NotImplementedException();
        }

        public void CreateLateNotification()
        {
            throw new NotImplementedException();
        }

        public void CreateUser()
        {
            throw new NotImplementedException();
        }

        public void DeleteCommentary()
        {
            throw new NotImplementedException();
        }

        public void DeleteLateNotification()
        {
            throw new NotImplementedException();
        }

        public void DisLikeLateNotification()
        {
            throw new NotImplementedException();
        }

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

        public void GetLateNotification()
        {
            throw new NotImplementedException();
        }

        public void LikeLateNotification()
        {
            throw new NotImplementedException();
        }

        public void UpdateLateNotification()
        {
            throw new NotImplementedException();
        }
    }
}
