using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/controller")]
public class WorkoutLogsController : ControllerBase
{
    private readonly IWorkoutLogsRepository _repo;

    public WorkoutLogsController(IWorkoutLogsRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<List<WorkoutLogs>>> Get() =>
        Ok(await _repo.GetAllWorkoutLogsAsync());

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<WorkoutLogs>> Get(string id)
    {
        var log = await _repo.GetWorkoutLogByIdAsync(id);
        return log is null ? NotFound() : Ok(log);
    }

    [HttpPost]
    [Authorize] // require JWT to create
    public async Task<ActionResult> Create(WorkoutLogs p)
    {
        await _repo.CreateWorkoutLogAsync(p);
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, WorkoutLogs updated)
    {
        var log = await _repo.GetWorkoutLogByIdAsync(id);
        if (log is null) return NotFound();
        updated.Id = log.Id;
        await _repo.UpdateWorkoutLogAsync(id, updated);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var log = await _repo.GetWorkoutLogByIdAsync(id);
        if (log is null) return NotFound();
        await _repo.DeleteWorkoutLogAsync(id);
        return NoContent();
    }
}
