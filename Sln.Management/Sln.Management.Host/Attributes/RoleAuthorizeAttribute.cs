using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sln.Management.Host.Filters;

namespace Sln.Management.Host.Attributes
{
    public class RoleAuthorizeAttribute : TypeFilterAttribute
    {
        public RoleAuthorizeAttribute(string role) : base(typeof(RoleAuthorizationFilter))
        {
            Arguments = [role];
        }
    }
}