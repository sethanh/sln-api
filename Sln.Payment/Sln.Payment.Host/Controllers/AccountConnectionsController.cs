using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AccountConnectionsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] AccountConnectionGetAllRequest request)
    {
        return await RequestAsGet<AccountConnectionGetAllRequest, AccountConnectionGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(Guid id)
    {
        var request = new AccountConnectionGetDetailRequest { Id = id };
        return await RequestAsGet<AccountConnectionGetDetailRequest, AccountConnectionGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AccountConnectionCreateRequest requestBody)
    {
        return await RequestAsCreate<AccountConnectionCreateRequest, AccountConnectionCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] AccountConnectionUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<AccountConnectionUpdateRequest, AccountConnectionUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(AccountConnectionDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}