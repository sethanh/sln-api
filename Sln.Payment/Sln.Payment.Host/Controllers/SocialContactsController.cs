using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.CardHolders;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class SocialContactsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SocialContactGetAllRequest request)
    {
        return await RequestAsGet<SocialContactGetAllRequest, SocialContactGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(SocialContactGetDetailRequest request)
    {
        return await RequestAsGet<SocialContactGetDetailRequest, SocialContactGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SocialContactCreateRequest requestBody)
    {
        return await RequestAsCreate<SocialContactCreateRequest, SocialContactCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] SocialContactUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<SocialContactUpdateRequest, SocialContactUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(SocialContactDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}