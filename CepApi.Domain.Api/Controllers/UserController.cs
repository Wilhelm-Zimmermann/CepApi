using Microsoft.AspNetCore.Mvc;

namespace CepApi.Domain.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<string>> GetUserById()
    {
        return Ok("helo world");
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateUser()
    {
        return Ok("Created");
    }
}