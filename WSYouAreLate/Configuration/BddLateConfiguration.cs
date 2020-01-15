using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSYouAreLate.Properties;

namespace WSYouAreLate.Configuration
{

    public class BddLateConfiguration
    {
        public string DataSource { get; set; }

        public string Catalog { get; set; }

        public string UserID { get; set; }

        public string Password { get; set; }

        public uint Port { get; set; }

        public BddLateConfiguration()
        {
            try
            {

                DataSource = Settings.DataSource.ToString();
                Catalog = Settings.Catalog.ToString();
                UserID = Settings.UserID.ToString();
                Password = Settings.Password.ToString();
                Port = uint.Parse(Settings.Port);

            }
            catch
            {
                //Si l'application qui requête est une application web
            }
        }

    }
}