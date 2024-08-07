using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Management.Common.Models;
using Sln.Shared.Business;

namespace Sln.Management.Business
{
    public class ManagementApplicationService( IServiceProvider serviceProvider) 
        : ApplicationServiceBase(serviceProvider)
    {
        public CurrentManagementAccount CurrentAccount => GetService<CurrentManagementAccount>();
    }
}