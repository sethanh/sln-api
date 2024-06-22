using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sln.Shared.Business.Abstractions;
using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Business
{
    public abstract class ApplicationServiceBase(IServiceProvider serviceProvider) : IApplicationService
    {
        private IServiceProvider ServiceProvider { get; } = serviceProvider;
        // protected IMapper Mapper => _serviceProvider.GetRequiredService<IMapper>();
        protected IUnitOfWork UnitOfWork => ServiceProvider.GetRequiredService<IUnitOfWork>();

        public TService GetService<TService>() where TService : class
        {
            return ServiceProvider.GetRequiredService<TService>();
        }

    }
}