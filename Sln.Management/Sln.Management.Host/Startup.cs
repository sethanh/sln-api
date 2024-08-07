using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Sln.Management.Data;
using Sln.Shared.Business.Abstractions;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Data.Abstractions;
using Sln.Shared.Host.Extensions;

namespace Sln.Management.Host
{
    public record Startup(IConfiguration Configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddHealthChecks();
            services.AddDbContext<ManagementDbContext>();
            services.AddMediatR((configs) =>
            {
                configs.RegisterServicesFromAssemblyContaining<Startup>();
            });
            services.AddCurrentAccount();
            services.AddScoped(typeof(IRepository<>), typeof(ManagementRepository<>));
            services.AddScoped<IUnitOfWork, ManagementUnitOfWork>();
            services.AddMapster();
            // services.RegisterMapsterConfiguration();
            services.AddHttpClient();
            services.AddRedisCache();
            services.AddAssignInterfaceServices<IDapperQuery>();
            services.AddAssignInterfaceServices<ICache>();
            services.AddAssignInterfaceServices<IApplicationService>();
            services.AddAssignInterfaceServices<IDomainService>();
            services.AddAssignInterfaceServices<IReportService>();
            services.AddAuthenticationService();
            services.AddEndpointsApiExplorer();
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            var isProduction = Environment.GetEnvironmentVariable(EnvConstants.IS_PRODUCTION);
            if (isProduction == null)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandler(options => { });

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseHealthChecks("/healthz");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCurrentAccount();
            app.UseGlobalExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }

    }
}