using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebMotorsChallenger.Infra.Connections
{
   public interface IConnectionFactory
    {
        public IDbConnection GetConnection();
    }
}
