using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.WorkManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class PriorityTasksController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PriorityTaskGetAllRequest request)
    {
        return await RequestAsGet<PriorityTaskGetAllRequest, PriorityTaskGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(PriorityTaskGetDetailRequest request)
    {
        return await RequestAsGet<PriorityTaskGetDetailRequest, PriorityTaskGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PriorityTaskCreateRequest requestBody)
    {
        return await RequestAsCreate<PriorityTaskCreateRequest, PriorityTaskCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] PriorityTaskUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<PriorityTaskUpdateRequest, PriorityTaskUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(PriorityTaskDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}