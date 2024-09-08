using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.WorkManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class RangeTasksController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] RangeTaskGetAllRequest request)
    {
        return await RequestAsGet<RangeTaskGetAllRequest, RangeTaskGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(RangeTaskGetDetailRequest request)
    {
        return await RequestAsGet<RangeTaskGetDetailRequest, RangeTaskGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RangeTaskCreateRequest requestBody)
    {
        return await RequestAsCreate<RangeTaskCreateRequest, RangeTaskCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] RangeTaskUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<RangeTaskUpdateRequest, RangeTaskUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(RangeTaskDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}