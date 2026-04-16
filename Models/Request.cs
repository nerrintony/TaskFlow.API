namespace TaskFlow.API.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Draft";
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
    }
}
