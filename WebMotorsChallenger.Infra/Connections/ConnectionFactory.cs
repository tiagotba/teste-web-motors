using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace WebMotorsChallenger.Infra.Connections
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = "Server=.;Initial Catalog=Teste_WebMotors;Persist Security Info=True;User ID=sa;Password=123456";

        public IDbConnection GetConnection()
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var conn = factory.CreateConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            return conn;
        }

       
    }
}
