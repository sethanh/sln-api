using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Accounts;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : PaymentControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] AccountGetAllRequest request)
    {
        return await RequestAsGet<AccountGetAllRequest, AccountGetAllResponse>(request);
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentAccount([FromRoute]CurrentAccountGetDetailRequest request)
    {
        return await RequestAsGet<CurrentAccountGetDetailRequest, AccountGetDetailResponse>(request);
    }


    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetDetail([FromRoute]AccountGetDetailRequest request)
    {
        return await RequestAsGet<AccountGetDetailRequest, AccountGetDetailResponse>(request);
    }

    [HttpPost("google-verify")]
    public async Task<IActionResult> Verify([FromBody] AccountGoogleVerifyRequest requestBody)
    {
        return await RequestAsCreate<AccountGoogleVerifyRequest, AccountLoginResponse>(requestBody);
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> LoginWithGoogle([FromBody] AccountGoogleLoginRequest requestBody)
    {
        return await RequestAsCreate<AccountGoogleLoginRequest, AccountLoginResponse>(requestBody);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AccountLoginRequest requestBody)
    {
        return await RequestAsCreate<AccountLoginRequest, AccountLoginResponse>(requestBody);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AccountCreateRequest requestBody)
    {
        return await RequestAsCreate<AccountCreateRequest, AccountCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] AccountUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<AccountUpdateRequest, AccountUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(AccountDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}
