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

    [HttpGet("workout/{workoutId}/user/{userId}")]
    public async Task<ActionResult<List<Exercises>>> GetExercisesByWorkoutIdAsync(string workoutId, string userId)
    {
        var exercises = await _repo.GetExercisesByWorkoutIdAsync(workoutId, userId);
        return exercises is null ? NotFound() : Ok(exercises);
    }

    [HttpPost]
    // [Authorize] // require JWT to create
    public async Task<ActionResult> Create(Exercises p)
    {
        await _repo.CreateExerciseAsync(p);
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Update(string id, Exercises exercise)
    {
        var existingExercise = await _repo.GetExerciseByIdAsync(id);
        if (existingExercise is null) return NotFound();
        exercise.Id = existingExercise.Id; // Ensure the ID from the URL is used, not from the body
        await _repo.UpdateExerciseAsync(id, exercise);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var exercise = await _repo.GetExerciseByIdAsync(id);
        if (exercise is null) return NotFound();
        await _repo.DeleteExerciseAsync(id);
        return NoContent();
    }
}
