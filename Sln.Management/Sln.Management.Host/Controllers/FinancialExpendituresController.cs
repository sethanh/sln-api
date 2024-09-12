using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.FinancialManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class FinancialExpendituresController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] FinancialExpenditureGetAllRequest request)
    {
        return await RequestAsGet<FinancialExpenditureGetAllRequest, FinancialExpenditureGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(FinancialExpenditureGetDetailRequest request)
    {
        return await RequestAsGet<FinancialExpenditureGetDetailRequest, FinancialExpenditureGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FinancialExpenditureCreateRequest requestBody)
    {
        return await RequestAsCreate<FinancialExpenditureCreateRequest, FinancialExpenditureCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] FinancialExpenditureUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<FinancialExpenditureUpdateRequest, FinancialExpenditureUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(FinancialExpenditureDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}