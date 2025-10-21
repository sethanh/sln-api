using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Payments;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentQrSettingsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaymentQrSettingGetAllRequest request)
    {
        return await RequestAsGet<PaymentQrSettingGetAllRequest, PaymentQrSettingGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(PaymentQrSettingGetDetailRequest request)
    {
        return await RequestAsGet<PaymentQrSettingGetDetailRequest, PaymentQrSettingGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PaymentQrSettingCreateRequest requestBody)
    {
        return await RequestAsCreate<PaymentQrSettingCreateRequest, PaymentQrSettingCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PaymentQrSettingUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<PaymentQrSettingUpdateRequest, PaymentQrSettingUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(PaymentQrSettingDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}