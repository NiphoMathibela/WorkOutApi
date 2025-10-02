using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WeightGoalController : ControllerBase
{
    private readonly IWeightGoalRepository _repo;

    public WeightGoalController(IWeightGoalRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<List<WeightGoal>>> Get() =>
        Ok(await _repo.GetAllWeightGoalsAsync());

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<WeightGoal>> Get(string id)
    {
        var goal = await _repo.GetWeightGoalByIdAsync(id);
        return goal is null ? NotFound() : Ok(goal);
    }

    [HttpPost]
    [Authorize] // require JWT to create
    public async Task<ActionResult> Create(WeightGoal p)
    {
        await _repo.CreateWeightGoalAsync(p);
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, WeightGoal updated)
    {
        var goal = await _repo.GetWeightGoalByIdAsync(id);
        if (goal is null) return NotFound();
        updated.Id = goal.Id;
        await _repo.UpdateWeightGoalAsync(id, updated);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var goal = await _repo.GetWeightGoalByIdAsync(id);
        if (goal is null) return NotFound();
        await _repo.DeleteWeightGoalAsync(id);
        return NoContent();
    }
}