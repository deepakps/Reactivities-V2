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
    
}