using System.Text.Json;
using Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;
using Sln.Publisher.Data.Entities.Realtime;
using Sln.Shared.Common.Abstractions;
using Sln.Shared.Common.Constants;
using Mapster;

namespace Sln.Publisher.Host.Extensions;

public static class ServiceRegisterExtensions
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        // Config custom mapping for model RealtimeItem
        TypeAdapterConfig<RealtimeItem, RealtimeItemGetAllResponseItem>
            .NewConfig().Map(dest => dest.Data, src => Deserialize(src.Data));
        TypeAdapterConfig<RealtimeItem, RealtimeItemCreateResponse>
            .NewConfig().Map(dest => dest.Data, src => Deserialize(src.Data));
        TypeAdapterConfig<RealtimeItem, RealtimeItemGetDetailResponse>
            .NewConfig().Map(dest => dest.Data, src => Deserialize(src.Data));
        TypeAdapterConfig<RealtimeItem, RealtimeItemUpdateResponse>
            .NewConfig().Map(dest => dest.Data, src => Deserialize(src.Data));
        TypeAdapterConfig<RealtimeItem, RealtimeItemRemoveResponse>
            .NewConfig().Map(dest => dest.Data, src => Deserialize(src.Data));
        
        TypeAdapterConfig<RealtimeItemCreateRequest, RealtimeItem>
            .NewConfig().Map(dest => dest.Data, src => Serialize(src.Data));
        TypeAdapterConfig<RealtimeItemUpdateRequest, RealtimeItem>
            .NewConfig().Map(dest => dest.Data, src => Serialize(src.Data));
        
        
    }
    
    private static object? Deserialize(string? jsonString)
    {
        return JsonSerializer.Deserialize<object?>(jsonString ?? "");
    }
    private static string? Serialize(object? obj)
    {
        return JsonSerializer.Serialize(obj ?? "");
    }
}