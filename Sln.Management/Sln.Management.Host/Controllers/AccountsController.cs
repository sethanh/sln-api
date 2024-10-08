using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.Accounts;
using Sln.Management.Host.Attributes;
using Sln.Management.Host.Filters;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ManagementControllerBase
{
    [HttpGet]
    [Authorize]
    [RoleAuthorize("Management")]
    public async Task<IActionResult> GetAll([FromQuery] AccountGetAllRequest request)
    {
        return await RequestAsGet<AccountGetAllRequest, AccountGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetDetail([FromRoute]AccountGetDetailRequest request)
    {
        return await RequestAsGet<AccountGetDetailRequest, AccountGetDetailResponse>(request);
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
    public async Task<IActionResult> Update(long id, [FromBody] AccountUpdateRequest requestBody)
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
