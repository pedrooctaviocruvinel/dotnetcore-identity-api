using Microsoft.AspNetCore.Mvc;

namespace DotNETCore.Identity.API.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> RetrieveById([FromRoute] string id) =>
        Ok();
}
