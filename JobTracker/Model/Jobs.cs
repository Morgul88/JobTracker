namespace JobTracker.Model
{
    public class Jobs
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Company { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        
        public string? Notes { get; set; }
        public string? Contact { get; set; }
        public string Status { get; set; } = "Applied";
    }

    
}
