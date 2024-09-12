using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.FinancialManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class FinancialOverviewsController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] FinancialOverviewGetAllRequest request)
    {
        return await RequestAsGet<FinancialOverviewGetAllRequest, FinancialOverviewGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(FinancialOverviewGetDetailRequest request)
    {
        return await RequestAsGet<FinancialOverviewGetDetailRequest, FinancialOverviewGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FinancialOverviewCreateRequest requestBody)
    {
        return await RequestAsCreate<FinancialOverviewCreateRequest, FinancialOverviewCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] FinancialOverviewUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<FinancialOverviewUpdateRequest, FinancialOverviewUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(FinancialOverviewDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}