using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Uploads;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PhotosController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PhotoGetAllRequest request)
    {
        return await RequestAsGet<PhotoGetAllRequest, PhotoGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(PhotoGetDetailRequest request)
    {
        return await RequestAsGet<PhotoGetDetailRequest, PhotoGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] PhotoCreateRequest requestBody)
    {
        return await RequestAsCreate<PhotoCreateRequest, PhotoCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] PhotoUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<PhotoUpdateRequest, PhotoUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(PhotoDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
    
}