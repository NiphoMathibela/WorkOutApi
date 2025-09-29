using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _repo;

    public UsersController(IUsersRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<List<Users>>> Get() =>
        Ok(await _repo.GetAllUsersAsync());

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Users>> Get(string id)
    {
        var user = await _repo.GetUserByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    [Authorize] // require JWT to create
    public async Task<ActionResult> Create(Users p)
    {
        await _repo.CreateUserAsync(p);
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, Users updated)
    {
        var user = await _repo.GetUserByIdAsync(id);
        if (user is null) return NotFound();
        updated.Id = user.Id;
        await _repo.UpdateUserAsync(id, updated);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _repo.GetUserByIdAsync(id);
        if (user is null) return NotFound();
        await _repo.DeleteUserAsync(id);
        return NoContent();
    }
}
