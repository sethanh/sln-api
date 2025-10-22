using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Sales;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class SaleDetailsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SaleDetailGetAllRequest request)
    {
        return await RequestAsGet<SaleDetailGetAllRequest, SaleDetailGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(SaleDetailGetDetailRequest request)
    {
        return await RequestAsGet<SaleDetailGetDetailRequest, SaleDetailGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SaleDetailCreateRequest requestBody)
    {
        return await RequestAsCreate<SaleDetailCreateRequest, SaleDetailCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SaleDetailUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<SaleDetailUpdateRequest, SaleDetailUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(SaleDetailDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}