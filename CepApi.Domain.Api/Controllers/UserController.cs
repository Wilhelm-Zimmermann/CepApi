using CepApi.Domain.Api.Utils;
using CepApi.Domain.Commands;
using CepApi.Domain.Entities;
using CepApi.Domain.Handlers;
using CepApi.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CepApi.Domain.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{

    [HttpGet("{id}")]
    public async Task<ActionResult<GenericCommandResult>> GetUserById(Guid id, [FromServices] IUserRepository userRepository)
    {
        var user = await userRepository.GetUserById(id);
        if (user != null)
        {
            return Ok(new GenericCommandResult("User found", user, true));
        }

        return NotFound(new GenericCommandResult("User not found", null, false));
    }

    [HttpPost]
    public async Task<ActionResult<GenericCommandResult>> CreateUser([FromBody] CreateUserCommand command, [FromServices] UserHandler handler)
    {
        var result = await handler.HandleAsync(command);

        if (result.Success)
        {
            return CreatedAtAction(nameof(CreateUser), result);
        }

        return BadRequest(result);
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<GenericCommandResult>> LoginUser([FromBody] LoginUserCommand command, [FromServices] UserHandler handler)
    {
        var result = await handler.HandleAsync(command);

        if (result.Success)
        {
            var token = JwtTokenServices.GenerateToken((User)result.Data);
            var userRole = JwtTokenServices.GetUserRole(token);

            return Ok(new GenericCommandResult("User logged successfully", new
            {
                Token = token
            }, true));
        }

        return BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GenericCommandResult>> UpdateUser(Guid id, [FromBody] UpdateUserCommand command, [FromServices] UserHandler handler)
    {
        command.Id = id;
        var result = await handler.HandleAsync(command);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GenericCommandResult>> DeleteUser(Guid id, [FromServices] IUserRepository userRepository)
    {
        await userRepository.DeleteUser(id);

        return Ok(new GenericCommandResult("User deleted", null, true));
    }
}