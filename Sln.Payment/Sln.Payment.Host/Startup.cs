using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.Extensions.FileProviders;
using Sln.Payment.Data;
// using Sln.Payment.Host.Filters;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Data.Interfaces;
using Sln.Shared.Host.Extensions;

namespace Sln.Payment.Host
{
    public record Startup(IConfiguration Configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddHealthChecks();
            services.AddDbContext<PaymentDbContext>();
            services.AddMediatR((configs) =>
            {
                configs.RegisterServicesFromAssemblyContaining<Startup>();
            });
            services.AddCurrentAccount();
            services.AddScoped(typeof(IRepository<>), typeof(PaymentRepository<>));
            services.AddScoped<IUnitOfWork, PaymentUnitOfWork>();
            services.AddMapster();
            // services.RegisterMapsterConfiguration();
            services.AddHttpClient();
            services.AddRedisCache();
            services.AddDapperService();
            services.AddCacheService();
            services.AddApplicationService();
            services.AddDomainService();
            services.AddReportService();
            // services.AddScoped<CacheResourceFilter>();
            // services.AddScoped<DateTimeToLocalTimeFilter>();
            services.AddAuthenticationService();
            services.AddEndpointsApiExplorer();
            services.AddSwagger();
            // services.AddControllers(options =>
            // {
            //     options.Filters.Add<>();
            // });
        }

        public void Configure(IApplicationBuilder app)
        {
            var isProduction = Environment.GetEnvironmentVariable(EnvConstants.IS_PRODUCTION);
            if (isProduction == null)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            // app.UseStaticFiles(new StaticFileOptions
            // {
            //     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Files")),
            //     RequestPath = "/Files"
            // });

            app.UseHealthChecks("/healthz");

            app.UseCurrentAccount();
            app.UseGlobalExceptionHandler();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }

    }
}