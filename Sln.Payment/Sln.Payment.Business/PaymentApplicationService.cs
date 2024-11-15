using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sln.Payment.Common.Models;
using Sln.Shared.Business;

namespace Sln.Payment.Business
{
    public class PaymentApplicationService( IServiceProvider serviceProvider) 
        : ApplicationServiceBase(serviceProvider)
    {
        public CurrentPaymentAccount CurrentAccount => GetService<CurrentPaymentAccount>();
    }
}