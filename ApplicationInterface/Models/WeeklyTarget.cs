public class WeeklyTarget
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int TargetWorkoutsPerWeek { get; set; }
    public int CompletedWorkoutsThisWeek { get; set; }
    public DateTime WeekStartDate { get; set; }
    public DateTime WeekEndDate { get; set; }
}