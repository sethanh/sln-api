using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.CardHolders;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ContactsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ContactGetAllRequest request)
    {
        return await RequestAsGet<ContactGetAllRequest, ContactGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(ContactGetDetailRequest request)
    {
        return await RequestAsGet<ContactGetDetailRequest, ContactGetDetailResponse>(request);
    }

    [AllowAnonymous]
    [HttpGet("by-profile-name")]
    public async Task<IActionResult> GetByProfileName([FromQuery]ContactGetByProfileNameRequest request)
    {
        return await RequestAsGet<ContactGetByProfileNameRequest, ContactGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ContactCreateRequest requestBody)
    {
        return await RequestAsCreate<ContactCreateRequest, ContactCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] ContactUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<ContactUpdateRequest, ContactUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ContactDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}