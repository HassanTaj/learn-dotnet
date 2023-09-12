namespace TodoServer.Models
{
    public class Todo:IdentityModel
    {
        public string? Task { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
