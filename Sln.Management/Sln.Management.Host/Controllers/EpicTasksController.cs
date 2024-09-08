using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.WorkManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class EpicTasksController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] EpicTaskGetAllRequest request)
    {
        return await RequestAsGet<EpicTaskGetAllRequest, EpicTaskGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(EpicTaskGetDetailRequest request)
    {
        return await RequestAsGet<EpicTaskGetDetailRequest, EpicTaskGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EpicTaskCreateRequest requestBody)
    {
        return await RequestAsCreate<EpicTaskCreateRequest, EpicTaskCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] EpicTaskUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<EpicTaskUpdateRequest, EpicTaskUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(EpicTaskDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}