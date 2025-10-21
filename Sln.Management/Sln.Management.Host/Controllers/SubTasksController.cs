using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.WorkManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class SubTasksController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SubTaskGetAllRequest request)
    {
        return await RequestAsGet<SubTaskGetAllRequest, SubTaskGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(SubTaskGetDetailRequest request)
    {
        return await RequestAsGet<SubTaskGetDetailRequest, SubTaskGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SubTaskCreateRequest requestBody)
    {
        return await RequestAsCreate<SubTaskCreateRequest, SubTaskCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SubTaskUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<SubTaskUpdateRequest, SubTaskUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(SubTaskDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}