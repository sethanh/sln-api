using Microsoft.AspNetCore.Mvc;
using Sln.Management.Contract.Requests.WorkManagements;

namespace Sln.Management.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardTasksController : ManagementControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] BoardTaskGetAllRequest request)
    {
        return await RequestAsGet<BoardTaskGetAllRequest, BoardTaskGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(BoardTaskGetDetailRequest request)
    {
        return await RequestAsGet<BoardTaskGetDetailRequest, BoardTaskGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BoardTaskCreateRequest requestBody)
    {
        return await RequestAsCreate<BoardTaskCreateRequest, BoardTaskCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] BoardTaskUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<BoardTaskUpdateRequest, BoardTaskUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(BoardTaskDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}