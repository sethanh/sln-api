using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ConversationsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ConversationGetAllRequest request)
    {
        return await RequestAsGet<ConversationGetAllRequest, ConversationGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(ConversationGetDetailRequest request)
    {
        return await RequestAsGet<ConversationGetDetailRequest, ConversationGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ConversationCreateRequest requestBody)
    {
        return await RequestAsCreate<ConversationCreateRequest, ConversationCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ConversationUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<ConversationUpdateRequest, ConversationUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ConversationDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}