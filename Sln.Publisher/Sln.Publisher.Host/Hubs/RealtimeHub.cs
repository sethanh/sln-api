using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Sln.Publisher.Host.Hubs.Models;
using Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;
using Sln.Publisher.Data.Enums;
using Sln.Shared.Contract.Models;

namespace Sln.Publisher.Host.Hubs;
public class RealtimeHub(IMediator mediator, IMapper mapper, IMemoryCache memoryCache) : Hub
{
    /**
     * Subscribe channel base on {key}
     */
    public async Task Subscribe(GetItemRealtimeHubModel request)
    {
        try
        {
            request = await ParseRequest<GetItemRealtimeHubModel>(request);
            if (!IsProcessConnect(request.Key ?? ""))
            {
                throw new Exception($"You already subscribe this {request.Key} node");
            }
            ProcessConnect(request.Key ?? "");

            var realtimeItem = await mediator.Send(new RealtimeItemGetDetailRequest()
            {
                Key = request.Key ?? ""
            });
            object? data;
            if (string.IsNullOrEmpty(realtimeItem.Key))
            {
                var item = await mediator.Send(new RealtimeItemCreateRequest()
                {
                    ParentKey = request.ParentKey,
                    Key = request.Key ?? "",
                    Data = request.Data,
                });
                item.ChangeType = RealtimeChangeType.Added.ToString();
                data = item;
            }
            else
            {
                realtimeItem.ChangeType = RealtimeChangeType.UnChange.ToString();
                data = realtimeItem;
            }

            if (!request.OnlyWatchForDataChange)
            {
                await Clients.Caller
                    .SendCoreAsync(RealtimeEvents.DataFetched.ToString(), [data]);
            }
        }
        catch (Exception e)
        {
            await SendError(e);
        }
    }

    /**
     * Update item base on {key}
     */
    public async Task Update(UpdateItemRealtimeHubModel request)
    {
        try
        {
            Console.WriteLine($"Data request");
            Console.WriteLine(request);
            request = await ParseRequest<UpdateItemRealtimeHubModel>(request);
            Console.WriteLine($"Parse request");
            Console.WriteLine(request);

            var realtimeItem = await mediator.Send(new RealtimeItemGetDetailRequest()
            {
                ParentKey = request.ParentKey,
                Key = request.Key ?? ""
            });
            object? data;
            if (string.IsNullOrEmpty(realtimeItem.Key))
            {
                var item = await mediator.Send(new RealtimeItemCreateRequest()
                {
                    ParentKey = request.ParentKey,
                    Key = request.Key ?? "",
                    Data = request.Data
                });
                item.ChangeType = RealtimeChangeType.Modified.ToString(); // trigger as modified
                data = item;
            }
            else
            {
                var item = await mediator.Send(new RealtimeItemUpdateRequest()
                {
                    ParentKey = request.ParentKey,
                    Key = request.Key ?? "",
                    Data = request.Data
                });
                item.ChangeType = RealtimeChangeType.Modified.ToString();
                data = item;
            }
            Console.WriteLine($"Data updated for key: {request.Key}");

            var groupName = request.GetGroupName();
            Console.WriteLine($"Data updated for groupName: {groupName}");

            await Clients.Groups(groupName)
                .SendCoreAsync(RealtimeEvents.DataModified.ToString(), new[] { data });

            // notify to parent
            if (!string.IsNullOrEmpty(request.ParentKey))
            {
                var groupNameParent = request.GetGroupName(true);
                await Clients.Groups(groupNameParent)
                    .SendCoreAsync(RealtimeEvents.ChildDataModified.ToString(), new[] { data });
            }
        }
        catch (Exception e)
        {
            await SendError(e);
        }
    }

    /**
     * Remove data current {key}
     */
    public async Task Remove(RemoveItemRealtimeHubModel request)
    {
        try
        {
            request = await ParseRequest<RemoveItemRealtimeHubModel>(request);
            var realtimeItem = await mediator.Send(new RealtimeItemGetDetailRequest()
            {
                Key = request.Key ?? ""
            });

            if (string.IsNullOrEmpty(realtimeItem.Key))
            {
                await Clients.Groups(request.GetGroupName())
                    .SendCoreAsync(RealtimeEvents.DataRemoved.ToString(), new object?[] { request });
                await Clients.Caller
                    .SendCoreAsync(RealtimeEvents.DataRemoved.ToString(), new object?[] { request });
                return;
            }

            var item = await mediator.Send(new RealtimeItemDeleteRequest()
            {
                Key = request.Key ?? ""
            });
            item.ChangeType = RealtimeChangeType.Removed.ToString();
            // Send events to client
            await Clients.Groups(request.GetGroupName())
                .SendCoreAsync(RealtimeEvents.DataRemoved.ToString(), new object?[] { item });

            // Notify to parent node
            if (!string.IsNullOrEmpty(item.ParentKey))
            {
                request.ParentKey = item.ParentKey;
                await Clients.Groups(request.GetGroupName(true))
                    .SendCoreAsync(RealtimeEvents.ChildDataRemoved.ToString(), new object?[] { item });
            }
        }
        catch (Exception e)
        {
            await SendError(e);
        }
    }

    /**
     * Add child data to current {key}
     */
    public async Task AddChild(UpdateItemRealtimeHubModel request)
    {
        try
        {
            request = await ParseRequest<UpdateItemRealtimeHubModel>(request);
            var item = await mediator.Send(new RealtimeItemCreateRequest()
            {
                ParentKey = !string.IsNullOrEmpty(request.ParentKey) ? request.ParentKey : request.Key,
                Key = !string.IsNullOrEmpty(request.ParentKey) ? request.Key ?? "" : Guid.NewGuid().ToString(),
                Data = request.Data,
                IsBypassCheckExist = true
            });
            item.ChangeType = RealtimeChangeType.Added.ToString();
            object data = item;
            request.ParentKey = item.ParentKey;
            request.Key = item.Key;


            await Clients.Groups(request.GetGroupName())
                .SendCoreAsync(RealtimeEvents.DataAdded.ToString(), [data]);

            // notify to parent node
            await Clients.Groups(request.GetGroupName(true))
                .SendCoreAsync(RealtimeEvents.ChildDataAdded.ToString(), [data]);
        }
        catch (Exception e)
        {
            await SendError(e);
        }
    }

    /**
     * Update child item base on {key} {parentKey}
     * {key} : Child item key
     * {parentKey}: current item {key}
     */
    public async Task UpdateChild(UpdateItemRealtimeHubModel request)
    {
        try
        {
            request = await ParseRequest<UpdateItemRealtimeHubModel>(request, request.Key ?? "");

            if (string.IsNullOrEmpty(request.ParentKey))
            {
                throw new Exception("You have to pass {ParentKey} to perform this action");
            }
            var realtimeItem = await mediator.Send(new RealtimeItemGetDetailRequest()
            {
                ParentKey = request.ParentKey,
                Key = request.Key ?? ""
            });
            object? data;
            if (string.IsNullOrEmpty(realtimeItem.Key))
            {
                var item = await mediator.Send(new RealtimeItemCreateRequest()
                {
                    ParentKey = request.ParentKey,
                    Key = request.Key ?? "",
                    Data = request.Data
                });
                item.ChangeType = RealtimeChangeType.Modified.ToString(); // trigger as modified
                data = item;
            }
            else
            {
                var item = await mediator.Send(new RealtimeItemUpdateRequest()
                {
                    ParentKey = request.ParentKey,
                    Key = request.Key ?? "",
                    Data = request.Data
                });
                item.ChangeType = RealtimeChangeType.Modified.ToString();
                data = item;
            }

            var groupName = request.GetGroupName();

            await Clients.Groups(groupName)
                .SendCoreAsync(RealtimeEvents.DataModified.ToString(), [data]);

            // notify to parent
            if (!string.IsNullOrEmpty(request.ParentKey))
            {
                var groupNameParent = request.GetGroupName(true);
                await Clients.Groups(groupNameParent)
                    .SendCoreAsync(RealtimeEvents.ChildDataModified.ToString(), [data]);
            }
        }
        catch (Exception e)
        {
            await SendError(e);
        }
    }
    /**
     * Get child items data of current {key}
     */
    public async Task GetChild(GetItemRealtimeHubModel request)
    {

        try
        {
            request = await ParseRequest<GetItemRealtimeHubModel>(request);
            // get all child items
            var childItems = await mediator.Send(new RealtimeItemGetAllRequest()
            {
                Page = request.Page,
                PageSize = request.PageSize,
                ParentKey = request.Key,
                UseCountTotal = true,
                OrderBy = "CreationTime",
                OrderDirection = "asc"
            });
            childItems.Items.ForEach(s => { s.ChangeType = RealtimeChangeType.UnChange.ToString(); });
            if (!request.OnlyWatchForDataChange)
            {
                await Clients.Caller
                    .SendCoreAsync(RealtimeEvents.ChildDataFetched.ToString(), [childItems]);
            }
        }
        catch (Exception e)
        {
            await SendError(e);
        }
    }

    /**
     * Remove child item of current {parentKey}
     */
    public async Task RemoveChild(RemoveItemRealtimeHubModel request)
    {
        try
        {
            request = await ParseRequest<RemoveItemRealtimeHubModel>(request, request.Key ?? "");
            var realtimeItem = await mediator.Send(new RealtimeItemGetDetailRequest()
            {
                Key = request.Key ?? ""
            });

            if (string.IsNullOrEmpty(realtimeItem.Key))
            {
                await Clients.Groups(request.GetGroupName())
                    .SendCoreAsync(RealtimeEvents.DataRemoved.ToString(), new object?[] { request.Key });
                await Clients.Caller
                    .SendCoreAsync(RealtimeEvents.DataRemoved.ToString(), new object?[] { request.Key });
                return;
            }

            var item = await mediator.Send(new RealtimeItemDeleteRequest()
            {
                Key = request.Key ?? ""
            });
            item.ChangeType = RealtimeChangeType.Removed.ToString();
            // Send events to client
            await Clients.Groups(request.GetGroupName())
                .SendCoreAsync(RealtimeEvents.DataRemoved.ToString(), new object?[] { item });

            // Notify to parent node
            if (!string.IsNullOrEmpty(item.ParentKey))
            {
                request.ParentKey = item.ParentKey;
                await Clients.Groups(request.GetGroupName(true))
                    .SendCoreAsync(RealtimeEvents.ChildDataRemoved.ToString(), new object?[] { item });
            }
        }
        catch (Exception e)
        {
            await SendError(e);
        }

    }

    /**
     * Get help show all supported methods, events
     */
    public async Task Help()
    {
        var supportedMethods = new object[]
        {
            new
            {
                name = "Subscribe" ,
                payload = new GetItemRealtimeHubModel
                {
                    Key = "required"
                }
            },
            new
            {
                name = "Update",
                payload = new UpdateItemRealtimeHubModel
                {
                    Key = "required",
                    Data = new {}
                }
            },
            new
            {
                name = "Remove",
                payload = new RemoveItemRealtimeHubModel
                {
                    Key = "required"
                }
            },
            new
            {
                name = "AddChild",
                payload = new UpdateItemRealtimeHubModel
                {
                    Key = "required"
                }
            },
            new
            {
                name = "UpdateChild",
                payload = new UpdateItemRealtimeHubModel
                {
                    Key = "required",
                    ParentKey = "required"
                }
            },
            new
            {
                name = "GetChild",
                payload = new GetItemRealtimeHubModel
                {
                    Key = "required"
                }
            },
            new
            {
                name = "RemoveChild",
                payload = new RemoveItemRealtimeHubModel
                {
                    Key = "required"
                }
            }
        };
        var supportedEvents = new[]
        {
            "DataFetched",
            "DataModified",
            "DataAdded",
            "DataRemoved",
            "Connected",
            "ChildDataFetched",
            "ChildDataModified",
            "ChildDataAdded",
            "ChildDataRemoved"
        };

        var dataChangeType = new[]
        {
            "Added",
            "Modified",
            "Removed",
            "Unchange"
        };

        await Clients.Caller.SendCoreAsync("Connected", [
            new
        {
            events = supportedEvents,
            methods = supportedMethods,
            dataChangeType
        }
        ]);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }

    public override async Task OnConnectedAsync()
    {
        await InitConnection();
        //await this.Help();
        await base.OnConnectedAsync();
    }

    #region Helper Function

    private async Task<T> ParseRequest<T>(BaseRealtimeHubModel request, string originKey = "")
    {
        var key = Context.GetHttpContext()?.GetRouteValue("key") as string;
        if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(request.Key))
        {
            throw new Exception("You have to pass specific {key} to perform this action");
        }
        // use for delete child item, keep origin {key} from request
        if (!string.IsNullOrEmpty(key) && string.IsNullOrEmpty(originKey))
        {
            request.Key = key;
        }

        // use for update child item, keep origin {key} and set {parentKey} to current {key} from route
        if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(originKey))
        {
            request.ParentKey = key;
        }

        var groupName = request.GetGroupName();

        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        return mapper.Map<T>(request);
    }

    private bool IsProcessConnect(string key)
    {
        var cacheKey = $"{Context.ConnectionId}:{key}";
        return !memoryCache.TryGetValue(cacheKey, out _);
    }

    private void ProcessConnect(string key)
    {
        var cacheKey = $"{Context.ConnectionId}:{key}";
        memoryCache.Set(cacheKey, new { Context.ConnectionId, key });
    }

    private async Task SendError(Exception e)
    {
        await Clients.Caller.SendCoreAsync(RealtimeEvents.Error.ToString(), [e.Message]);
    }
    private async Task InitConnection()
    {
        var key = Context.GetHttpContext()?.GetRouteValue("key") as string;
        if (!string.IsNullOrEmpty(key))
        {
            await Subscribe(new GetItemRealtimeHubModel() { Key = key });
        }
    }

    #endregion

}