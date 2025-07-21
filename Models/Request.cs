namespace SmartRequest.Models
{
    public class Request
    {
        public int Id { get; set; }                     // Primary key
        public string Title { get; set; }               // Request title
        public string Description { get; set; }         // Description of request
        public string Category { get; set; }            // E.g., IT, HR, etc.
        public string Status { get; set; }              // Open, In Progress, Closed
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
