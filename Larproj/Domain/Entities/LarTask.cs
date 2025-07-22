namespace Larproj.Domain.Entities;

public class LarTask
{
    public int Id { get; set; }
    public List<int> TaskAttribuition = new List<int>();
    public string Title { get; set; }
    public string? Description { get; set; }
    //public DateTime? CreateDate { get; set; }
    public DateTime? Deadline { get; set; }
    public DateTime? ConclusionDate { get; set; }

    public LarTask(string title, string description, DateTime? deadline)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
    }
}
