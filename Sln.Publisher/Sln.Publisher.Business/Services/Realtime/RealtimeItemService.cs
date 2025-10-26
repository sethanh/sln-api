using System.Text.Json;
using Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;
using Sln.Publisher.Data.Entities.Realtime;
using Sln.Publisher.Business.Managers.Realtime;
using Sln.Shared.Common.Abstractions;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Business;
using Sln.Shared.Contract.Models;
using Microsoft.EntityFrameworkCore;

namespace Sln.Publisher.Business.Services.Realtime;

public class RealtimeItemService(IServiceProvider serviceProvider, IRedisCacheService cacheService) : ApplicationServiceBase(serviceProvider)
{
    private RealtimeItemManager RealtimeItemManager => GetService<RealtimeItemManager>();

    public async Task<RealtimeItemGetAllResponse> GetAll(RealtimeItemGetAllRequest request)
    {
        var realtimeItems = RealtimeItemManager.GetAll();
        if (!string.IsNullOrEmpty(request.ParentKey))
        {
            realtimeItems = realtimeItems.Where(e => e.ParentKey == request.ParentKey);
        }

        var paginationResponse = PaginationResponse<RealtimeItem>.Create(
            realtimeItems,
            request
        );

        return Mapper.Map<RealtimeItemGetAllResponse>(paginationResponse);
    }

    public async Task<RealtimeItemGetDetailResponse> GetDetail(RealtimeItemGetDetailRequest request)
    {
        Console.WriteLine("Getting detail ");
        Console.WriteLine(JsonSerializer.Serialize(request));
        var cacheKey = RealtimeItemManager.GetCacheKey(request.Key);
        var realtimeItem = cacheService.Get<RealtimeItem>(cacheKey);
        if (realtimeItem == null)
        {   Console.WriteLine("Cache miss, fetching from database");
            realtimeItem = await RealtimeItemManager.GetAll()
                .FirstOrDefaultAsync(e=>e.Key == request.Key);
            cacheService.Add(cacheKey, realtimeItem, DateTimeOffset.Now.AddMinutes(15));
        }

        if (realtimeItem == null)
        {
            var item = await Create(new RealtimeItemCreateRequest()
            {
                ParentKey = request.ParentKey,
                Key = request.Key,
                Data = string.Empty
            });
            realtimeItem = new RealtimeItem()
            {
                ParentKey = item.ParentKey,
                Key = item.Key,
                Data = JsonSerializer.Serialize(item.Data ?? "")
            };
        }
        Console.WriteLine("Realtime Item Detail: ");
        Console.WriteLine(JsonSerializer.Serialize(realtimeItem));

        try
        {
            Mapper.Map<RealtimeItemGetDetailResponse>(realtimeItem);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error parsing realtime item data: " + ex.Message);
        }

        return Mapper.Map<RealtimeItemGetDetailResponse>(realtimeItem);
    }

    public async Task<RealtimeItemCreateResponse> Create(RealtimeItemCreateRequest request)
    {
        var realtimeItem = Mapper.Map<RealtimeItem>(request);
        if (!request.IsBypassCheckExist)
        {
            var exist = await RealtimeItemManager.GetAll()
                .FirstOrDefaultAsync(e => e.Key == request.Key);
        
            // if key already exist, update the exist one
            if (exist != null)
            {
                exist.ParentKey = realtimeItem.ParentKey;
                exist.Data = realtimeItem.Data;
                await RealtimeItemManager.Update(exist);
                await UnitOfWork.SaveChangesAsync();
                return Mapper.Map<RealtimeItemCreateResponse>(exist);
            }   
        }
        realtimeItem = await RealtimeItemManager.AddAsync(realtimeItem);
        await UnitOfWork.SaveChangesAsync();
        return Mapper.Map<RealtimeItemCreateResponse>(realtimeItem);
    }

    public async Task<RealtimeItemUpdateResponse> Update(RealtimeItemUpdateRequest request)
    {
        var cacheKey = RealtimeItemManager.GetCacheKey(request.Key);
        var exist = await RealtimeItemManager
            .GetAll()
            .FirstOrDefaultAsync(e => e.Key == request.Key);
        var realtimeItem = Mapper.Map<RealtimeItem>(request);
        if (exist == null)
        {
            exist = new RealtimeItem()
            {
                Key = request.Key,
            };
        }
        exist.ParentKey = realtimeItem.ParentKey;
        exist.Data = realtimeItem.Data;

        var updatedRealtimeItem = await RealtimeItemManager.Update(exist);

        await UnitOfWork.SaveChangesAsync();
        cacheService.Remove(cacheKey);
        return Mapper.Map<RealtimeItemUpdateResponse>(updatedRealtimeItem);
    }

    public async Task<RealtimeItemRemoveResponse>  Delete(RealtimeItemDeleteRequest request)
    {
        var cacheKey = RealtimeItemManager.GetCacheKey(request.Key);
        var item = await RealtimeItemManager.GetAll().FirstOrDefaultAsync(e => e.Key == request.Key);
        if (item == null)
        {
            return null!;
        }

        RealtimeItemManager.Delete(item.Id);
        
        //remove all child item of current items
        var childs = await RealtimeItemManager.GetAll()
            .Where(e => e.ParentKey != null && e.ParentKey == request.Key)
            .ToListAsync();
        if (childs.Count > 0)
        {
            RealtimeItemManager.DeleteRange(childs);   
        }
        await UnitOfWork.SaveChangesAsync();
        cacheService.Remove(cacheKey);
        if (childs.Count > 0)
        {
            foreach (var realtimeItem in childs)
            {
                cacheKey = RealtimeItemManager.GetCacheKey(realtimeItem.Key);
                cacheService.Remove(cacheKey);
            }
        }
        return Mapper.Map<RealtimeItemRemoveResponse>(item);
    }
    
}
