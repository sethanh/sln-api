using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Messages;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ChatMessagesController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ChatMessageGetAllRequest request)
    {
        return await RequestAsGet<ChatMessageGetAllRequest, ChatMessageGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(ChatMessageGetDetailRequest request)
    {
        return await RequestAsGet<ChatMessageGetDetailRequest, ChatMessageGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ChatMessageCreateRequest requestBody)
    {
        return await RequestAsCreate<ChatMessageCreateRequest, ChatMessageCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ChatMessageUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<ChatMessageUpdateRequest, ChatMessageUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ChatMessageDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}