using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Payments;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PaymentQrsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaymentQrGetAllRequest request)
    {
        return await RequestAsGet<PaymentQrGetAllRequest, PaymentQrGetAllResponse>(request);
    }
    [AllowAnonymous]
    [HttpGet("banks")]
    public async Task<IActionResult> GetAllBank([FromQuery] PaymentQrGetAllBankRequest request)
    {
        return await RequestAsGet<PaymentQrGetAllBankRequest, PaymentQrGetAllBankResponse>(request);
    }
    [AllowAnonymous]
    [HttpGet("qr")]
    public async Task<IActionResult> GetQr([FromQuery] PaymentQrGetQrRequest request)
    {
        return await RequestAsGet<PaymentQrGetQrRequest, PaymentQrGetQrResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(PaymentQrGetDetailRequest request)
    {
        return await RequestAsGet<PaymentQrGetDetailRequest, PaymentQrGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PaymentQrCreateRequest requestBody)
    {
        return await RequestAsCreate<PaymentQrCreateRequest, PaymentQrCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PaymentQrUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<PaymentQrUpdateRequest, PaymentQrUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(PaymentQrDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}