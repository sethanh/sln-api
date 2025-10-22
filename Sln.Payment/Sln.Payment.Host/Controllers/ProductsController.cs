using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Sales;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProductGetAllRequest request)
    {
        return await RequestAsGet<ProductGetAllRequest, ProductGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(ProductGetDetailRequest request)
    {
        return await RequestAsGet<ProductGetDetailRequest, ProductGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCreateRequest requestBody)
    {
        return await RequestAsCreate<ProductCreateRequest, ProductCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<ProductUpdateRequest, ProductUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ProductDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}