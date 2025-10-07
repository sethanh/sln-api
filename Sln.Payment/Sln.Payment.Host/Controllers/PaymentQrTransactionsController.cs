using Microsoft.AspNetCore.Mvc;
using Sln.Payment.Contract.Requests.Payments;

namespace Sln.Payment.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentQrTransactionsController : PaymentControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaymentQrTransactionGetAllRequest request)
    {
        return await RequestAsGet<PaymentQrTransactionGetAllRequest, PaymentQrTransactionGetAllResponse>(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(PaymentQrTransactionGetDetailRequest request)
    {
        return await RequestAsGet<PaymentQrTransactionGetDetailRequest, PaymentQrTransactionGetDetailResponse>(request);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PaymentQrTransactionCreateRequest requestBody)
    {
        return await RequestAsCreate<PaymentQrTransactionCreateRequest, PaymentQrTransactionCreateResponse>(requestBody);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] PaymentQrTransactionUpdateRequest requestBody)
    {
        if (id != requestBody.Id)
        {
            return BadRequest("RESOURCE_ID_MISMATCH");
        }

        return await RequestAsUpdate<PaymentQrTransactionUpdateRequest, PaymentQrTransactionUpdateResponse>(requestBody);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(PaymentQrTransactionDeleteRequest request)
    {
        return await RequestAsDelete(request);
    }
}