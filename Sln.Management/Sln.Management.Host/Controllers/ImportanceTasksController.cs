using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.WorkManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class ImportanceTasksController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ImportanceTaskGetAllRequest request)
    {
        return await RequestAsGet<ImportanceTaskGetAllRequest, ImportanceTaskGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(ImportanceTaskGetDetailRequest request)
    {
        return await RequestAsGet<ImportanceTaskGetDetailRequest, ImportanceTaskGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ImportanceTaskCreateRequest requestBody)
    {
        return await RequestAsCreate<ImportanceTaskCreateRequest, ImportanceTaskCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ImportanceTaskUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<ImportanceTaskUpdateRequest, ImportanceTaskUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ImportanceTaskDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}