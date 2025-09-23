public class Workouts
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Exercises> Exercises { get; set; }
    
}