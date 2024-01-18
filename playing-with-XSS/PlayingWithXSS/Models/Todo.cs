namespace PlayingWithXSS.Models
{
    public class Todo
    {
        public int? Id { get; set; }

        public string? Description { get; set; }

        public DateOnly? DueDate { get; set; }
    }
}
