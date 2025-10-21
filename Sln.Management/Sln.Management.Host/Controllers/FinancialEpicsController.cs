using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.FinancialManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class FinancialEpicsController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] FinancialEpicGetAllRequest request)
    {
        return await RequestAsGet<FinancialEpicGetAllRequest, FinancialEpicGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(FinancialEpicGetDetailRequest request)
    {
        return await RequestAsGet<FinancialEpicGetDetailRequest, FinancialEpicGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FinancialEpicCreateRequest requestBody)
    {
        return await RequestAsCreate<FinancialEpicCreateRequest, FinancialEpicCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] FinancialEpicUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<FinancialEpicUpdateRequest, FinancialEpicUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(FinancialEpicDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}