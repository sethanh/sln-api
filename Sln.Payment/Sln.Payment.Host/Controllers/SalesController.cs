using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Sales;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class SalesController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SaleGetAllRequest request)
    {
        return await RequestAsGet<SaleGetAllRequest, SaleGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(SaleGetDetailRequest request)
    {
        return await RequestAsGet<SaleGetDetailRequest, SaleGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SaleCreateRequest requestBody)
    {
        return await RequestAsCreate<SaleCreateRequest, SaleCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SaleUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<SaleUpdateRequest, SaleUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(SaleDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}