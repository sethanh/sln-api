using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Data;

namespace Sln.Payment.Business
{
    public class PaymentDapperQuery : DapperQueryBase
    {
        public PaymentDapperQuery() 
        {
            this.ConnectionString = GetConnectionString();
        }

        public static string GetConnectionString()
        {
            var connectionName = EnvConstants.PAYMENT_CONNECTION;
            if (string.IsNullOrEmpty(connectionName))
            {
                throw new Exception($"Connection name environment variable is not set.");
            }
            var connectionString = Environment.GetEnvironmentVariable(connectionName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception($"Connection value environment variable is not set.");
            }

            return connectionString;
        }
    }
}