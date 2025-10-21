using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.WorkManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class SectionTasksController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SectionTaskGetAllRequest request)
    {
        return await RequestAsGet<SectionTaskGetAllRequest, SectionTaskGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(SectionTaskGetDetailRequest request)
    {
        return await RequestAsGet<SectionTaskGetDetailRequest, SectionTaskGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SectionTaskCreateRequest requestBody)
    {
        return await RequestAsCreate<SectionTaskCreateRequest, SectionTaskCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SectionTaskUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<SectionTaskUpdateRequest, SectionTaskUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(SectionTaskDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}