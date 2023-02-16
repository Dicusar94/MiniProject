using Microsoft.AspNetCore.Mvc;

namespace Mag.Api.Controllers;

[Route("/error")]
[ApiExplorerSettings(IgnoreApi=true)]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {
        return Problem();
    }
}