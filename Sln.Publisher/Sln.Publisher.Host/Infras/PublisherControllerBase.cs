using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sln.Publisher.Host.Infras;

[ApiController]
public abstract class PublisherControllerBase : Controller
{
    protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected async Task<IActionResult> RequestAsGet<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    protected async Task<IActionResult> RequestAsCreate<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await Mediator.Send(request);
        return Created("", response);
    }

    protected async Task<IActionResult> RequestAsUpdate<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await Mediator.Send(request);
        return Ok(response);
    }

    protected async Task<IActionResult> RequestAsDelete<TRequest>(TRequest request) where TRequest : IRequest
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await Mediator.Send(request);
        return Ok();
    }
    protected async Task<IActionResult> RequestAsDelete<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await Mediator.Send(request);
        return Ok();
    }

    protected async Task<IActionResult> RequestAsAction<TRequest>(TRequest request) where TRequest : IRequest
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await Mediator.Send(request);
        return Ok();
    }
}