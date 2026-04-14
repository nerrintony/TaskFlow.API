namespace TaskFlow.API.DTOs
{
    public class CreateRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
    }
}
