namespace TaskTracker.Models
{
    public class ProjectRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int ProjectLeadId { get; set; }

        public int ProjectManagerId { get; set; }
    }
}
