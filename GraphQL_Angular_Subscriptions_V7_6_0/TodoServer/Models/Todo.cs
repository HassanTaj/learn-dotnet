namespace TodoServer.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Task { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
