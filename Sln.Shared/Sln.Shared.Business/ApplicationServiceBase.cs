using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Business
{
    public abstract class ApplicationServiceBase(IServiceProvider serviceProvider) : IApplicationService
    {
        private IServiceProvider ServiceProvider { get; } = serviceProvider;
        protected IMapper Mapper => ServiceProvider.GetRequiredService<IMapper>();
        protected IUnitOfWork UnitOfWork => ServiceProvider.GetRequiredService<IUnitOfWork>();

        public TService GetService<TService>() where TService : class
        {
            return ServiceProvider.GetRequiredService<TService>();
        }

    }
}