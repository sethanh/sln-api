using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.WorkManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskManagementsController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] TaskManagementGetAllRequest request)
    {
        return await RequestAsGet<TaskManagementGetAllRequest, TaskManagementGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(TaskManagementGetDetailRequest request)
    {
        return await RequestAsGet<TaskManagementGetDetailRequest, TaskManagementGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskManagementCreateRequest requestBody)
    {
        return await RequestAsCreate<TaskManagementCreateRequest, TaskManagementCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] TaskManagementUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<TaskManagementUpdateRequest, TaskManagementUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(TaskManagementDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}