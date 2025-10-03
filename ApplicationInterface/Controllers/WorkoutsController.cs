using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/controller")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkouts _repo;

    public WorkoutController(IWorkouts repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<List<Workouts>>> Get() =>
        Ok(await _repo.GetAllWorkoutsAsync());

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Workouts>> Get(string id)
    {
        var workout = await _repo.GetWorkoutByIdAsync(id);
        return workout is null ? NotFound() : Ok(workout);
    }

    [HttpPost]
    // [Authorize] // require JWT to create
    public async Task<ActionResult> Create(Workouts p)
    {
        await _repo.CreateWorkoutAsync(p);
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, Workouts updated)
    {
        var workout = await _repo.GetWorkoutByIdAsync(id);
        if (workout is null) return NotFound();
        updated.Id = workout.Id;
        await _repo.UpdateWorkoutAsync(id, updated);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var workout = await _repo.GetWorkoutByIdAsync(id);
        if (workout is null) return NotFound();
        await _repo.DeleteWorkoutAsync(id);
        return NoContent();
    }
}