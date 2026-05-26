using Microsoft.AspNetCore.Mvc;
using Users.Api.Dtos;
using Users.Api.Services;

namespace Users.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await userService.GetAllAsync(cancellationToken);
        return Ok(users);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var users = await userService.GetByIdAsync(id, cancellationToken);
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto request, CancellationToken cancellation)
    {
        var result = await userService.CreateAsync(request, cancellation);
        return Ok(new
        {
            Result = result
        });
    }
    [HttpPost("{id}")]
    public async Task<IActionResult> Delete(Guid id,CancellationToken cancellation)
    {
        var result = await userService.DeleteByIdAsync(id, cancellation);
        return Ok(new
        {
            Result = result
        });
    }

}
