using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class WeeklyTargetController : ControllerBase
{
    private readonly IWeeklyTargetRepository _repo;

    public WeeklyTargetController(IWeeklyTargetRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<List<WeeklyTarget>>> Get() =>
        Ok(await _repo.GetAllWeeklyTargetsAsync());

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<WeeklyTarget>> Get(string id)
    {
        var target = await _repo.GetWeeklyTargetByIdAsync(id);
        return target is null ? NotFound() : Ok(target);
    }

    [HttpPost]
    [Authorize] // require JWT to create
    public async Task<ActionResult> Create(WeeklyTarget p)
    {
        await _repo.CreateWeeklyTargetAsync(p);
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, WeeklyTarget updated)
    {
        var target = await _repo.GetWeeklyTargetByIdAsync(id);
        if (target is null) return NotFound();
        updated.Id = target.Id;
        await _repo.UpdateWeeklyTargetAsync(id, updated);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var target = await _repo.GetWeeklyTargetByIdAsync(id);
        if (target is null) return NotFound();
        await _repo.DeleteWeeklyTargetAsync(id);
        return NoContent();
    }
}