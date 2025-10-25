using Microsoft.AspNetCore.Mvc;
using Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;
using Sln.Publisher.Host.Infras;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Sln.Publisher.Host.Controllers;

[Route("realtime-items")]
public class RealtimeItemsController : PublisherControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]RealtimeItemGetAllRequest request)
    {
        return await RequestAsGet<RealtimeItemGetAllRequest, RealtimeItemGetAllResponse>(request);
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> GetDetail(RealtimeItemGetDetailRequest request)
    {
        return await RequestAsGet<RealtimeItemGetDetailRequest, RealtimeItemGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RealtimeItemCreateRequest requestBody)
    {
        return await RequestAsCreate<RealtimeItemCreateRequest, RealtimeItemCreateResponse>(requestBody);
    }

    [HttpPatch("{key}")]
    public async Task<IActionResult> Update(string key, [FromBody] RealtimeItemUpdateRequest requestBody)
    {
        if (key != requestBody.Key)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<RealtimeItemUpdateRequest, RealtimeItemUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(RealtimeItemDeleteRequest request)
    {
        return await RequestAsDelete<RealtimeItemDeleteRequest, RealtimeItemRemoveResponse>(request);
    }
}