using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Capturess;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PostLikesController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PostLikeGetAllRequest request)
    {
        return await RequestAsGet<PostLikeGetAllRequest, PostLikeGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(PostLikeGetDetailRequest request)
    {
        return await RequestAsGet<PostLikeGetDetailRequest, PostLikeGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostLikeCreateRequest requestBody)
    {
        return await RequestAsCreate<PostLikeCreateRequest, PostLikeCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PostLikeUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<PostLikeUpdateRequest, PostLikeUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(PostLikeDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}