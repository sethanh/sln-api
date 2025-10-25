using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Accounts;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AccountNotificationsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] AccountNotificationGetAllRequest request)
    {
        return await RequestAsGet<AccountNotificationGetAllRequest, AccountNotificationGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(AccountNotificationGetDetailRequest request)
    {
        return await RequestAsGet<AccountNotificationGetDetailRequest, AccountNotificationGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AccountNotificationCreateRequest requestBody)
    {
        return await RequestAsCreate<AccountNotificationCreateRequest, AccountNotificationCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] AccountNotificationUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<AccountNotificationUpdateRequest, AccountNotificationUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(AccountNotificationDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}