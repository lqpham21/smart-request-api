namespace SmartRequest.Models
{
    public class Request
    {
        public int Id { get; set; }                     // Primary key
        public required string  Title { get; set; }               // Request title
        public required string  Description { get; set; }         // Description of request
        public required string  Category { get; set; }            // E.g., IT, HR, etc.
        public required string  Status { get; set; }              // Open, In Progress, Closed
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
