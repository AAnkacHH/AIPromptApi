using Microsoft.AspNetCore.Mvc;
using PromptAPI.Model.Request;
using PromptAPI.Service;

namespace PromptAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var user = await userService.CreateUserAsync(request);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest request)
    {
        var user = await userService.FindUserByIdAsync(id);
        if (user == null) return NotFound();
        await userService.UpdateUserAsync(user, request);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await userService.FindUserByIdAsync(id);
        if (user == null) return NotFound();
        await userService.DeleteUserAsync(user);
        return NoContent();
    }
}