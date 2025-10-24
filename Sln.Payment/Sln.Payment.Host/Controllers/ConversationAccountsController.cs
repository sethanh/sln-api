using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ConversationAccountsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ConversationAccountGetAllRequest request)
    {
        return await RequestAsGet<ConversationAccountGetAllRequest, ConversationAccountGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(ConversationAccountGetDetailRequest request)
    {
        return await RequestAsGet<ConversationAccountGetDetailRequest, ConversationAccountGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ConversationAccountCreateRequest requestBody)
    {
        return await RequestAsCreate<ConversationAccountCreateRequest, ConversationAccountCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ConversationAccountUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<ConversationAccountUpdateRequest, ConversationAccountUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ConversationAccountDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}