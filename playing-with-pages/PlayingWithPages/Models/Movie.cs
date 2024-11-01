namespace PlayingWithPages.Models
{
    public class Movie
    {
        public Movie()
        {

        }

        public Movie(int id, string title, string genre, string? description)
        {
            this.Id = id;
            this.Title = title;
            this.Genre = genre;
            this.Description = description;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string? Description { get; set; }
    }
}
