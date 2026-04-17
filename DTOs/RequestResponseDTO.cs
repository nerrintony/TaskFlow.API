namespace TaskFlow.API.DTOs
{
    public class RequestResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string CreatedByUserName { get; set; } = string.Empty;
    }
}
