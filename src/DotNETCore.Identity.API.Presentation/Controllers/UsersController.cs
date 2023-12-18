using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNETCore.Identity.API.Presentation.Controllers;

/// <summary>
/// Represents the User
/// </summary>
public class TestUser
{
    /// <summary>
    /// UserName of User
    /// </summary>
    /// <example>pedrooctaviocruvinel</example>
    [Required]
    public string UserName { get; set; }

    /// <summary>
    /// Email of User
    /// </summary>
    /// <example>pedrooctaviocruvinel@gmail.com</example>
    [Required]
    public string Email { get; set; }
}

/// <summary>
/// Contains the API endpoints related to User
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    /// <summary>
    /// Retrieve User by Id
    /// </summary>
    /// <returns>User</returns>
    /// <response code="200">Returns User</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<TestUser>), StatusCodes.Status200OK)]
    public async Task<IActionResult> RetrieveById([FromRoute] string id) =>
        Ok();
}
