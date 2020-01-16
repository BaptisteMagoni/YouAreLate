using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WSYouAreLate.Configuration
{
    public class ConnectionStringConfig
    {

        private static BddLateConfiguration config;

        public static string LoadConnectionString()
        {
            config = new BddLateConfiguration();

            return new MySqlConnectionStringBuilder()
            {
                Server = config.DataSource,
                Database = config.Catalog,
                UserID = config.UserID,
                Password = config.Password,
                Port = config.Port,
            }.ConnectionString;

        }

    }
}