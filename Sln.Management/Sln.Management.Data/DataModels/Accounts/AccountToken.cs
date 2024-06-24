using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Management.Data.DataModels.Accounts
{
    public class AccountToken
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}