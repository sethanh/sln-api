using Microsoft.Extensions.DependencyInjection;

namespace Sln.Management.Business.Extensions
{
    public static class RegisterCustomMappingExtensions
    {
        public static IServiceCollection RegisterMapsterConfiguration(this IServiceCollection services)
        {
            // Config custom mapping for model RealtimeItem
            // TypeAdapterConfig<IntegrationEmailSettingDetailResponse, IntegrationSetting>
            //     .NewConfig().Map(dest => dest.Configuration, src => CommonHelper.Serialize(src.Configuration));


            return services;
        }
    }
}