using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Sales;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductCategorysController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProductCategoryGetAllRequest request)
    {
        return await RequestAsGet<ProductCategoryGetAllRequest, ProductCategoryGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(ProductCategoryGetDetailRequest request)
    {
        return await RequestAsGet<ProductCategoryGetDetailRequest, ProductCategoryGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCategoryCreateRequest requestBody)
    {
        return await RequestAsCreate<ProductCategoryCreateRequest, ProductCategoryCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductCategoryUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<ProductCategoryUpdateRequest, ProductCategoryUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ProductCategoryDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}