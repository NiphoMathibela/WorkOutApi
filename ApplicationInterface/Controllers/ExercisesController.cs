using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly IExercisesRepository _repo;

    public ExercisesController(IExercisesRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<List<Exercises>>> Get() =>
        Ok(await _repo.GetAllExercisesAsync());

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Exercises>> Get(string id)
    {
        var exercise = await _repo.GetExerciseByIdAsync(id);
        return exercise is null ? NotFound() : Ok(exercise);
    }

    [HttpPost]
    // [Authorize] // require JWT to create
    public async Task<ActionResult> Create(Exercises p)
    {
        await _repo.CreateExerciseAsync(p);
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, Exercises exercise)
    {
        await _repo.UpdateExerciseAsync(id, exercise);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var exercise = await _repo.GetExerciseByIdAsync(id);
        if (exercise is null) return NotFound();
        await _repo.DeleteExerciseAsync(id);
        return NoContent();
    }
}
