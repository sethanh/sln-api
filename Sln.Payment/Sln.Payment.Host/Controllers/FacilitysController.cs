using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Sales;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class FacilitysController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] FacilityGetAllRequest request)
    {
        return await RequestAsGet<FacilityGetAllRequest, FacilityGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(FacilityGetDetailRequest request)
    {
        return await RequestAsGet<FacilityGetDetailRequest, FacilityGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FacilityCreateRequest requestBody)
    {
        return await RequestAsCreate<FacilityCreateRequest, FacilityCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] FacilityUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<FacilityUpdateRequest, FacilityUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(FacilityDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}