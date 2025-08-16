using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Base controller that provides common API configuration attributes.
/// Inherits from ControllerBase and applies [ApiController] and route prefix.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    private IMediator? _mediator;    

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
                                                  ?? throw new InvalidOperationException("Mediator service not found.");
}