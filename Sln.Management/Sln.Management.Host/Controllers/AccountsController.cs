using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.Accounts;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] AccountGetAllRequest request)
    {
        return await RequestAsGet<AccountGetAllRequest, AccountGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(AccountGetDetailRequest request)
    {
        return await RequestAsGet<AccountGetDetailRequest, AccountGetDetailResponse>(request);
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