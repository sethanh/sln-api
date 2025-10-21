using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.WorkManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class FrequencyTasksController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] FrequencyTaskGetAllRequest request)
    {
        return await RequestAsGet<FrequencyTaskGetAllRequest, FrequencyTaskGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(FrequencyTaskGetDetailRequest request)
    {
        return await RequestAsGet<FrequencyTaskGetDetailRequest, FrequencyTaskGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FrequencyTaskCreateRequest requestBody)
    {
        return await RequestAsCreate<FrequencyTaskCreateRequest, FrequencyTaskCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] FrequencyTaskUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<FrequencyTaskUpdateRequest, FrequencyTaskUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(FrequencyTaskDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}