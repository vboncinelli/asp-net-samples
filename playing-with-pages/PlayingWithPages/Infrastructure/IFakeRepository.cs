using PlayingWithPages.Models;

namespace PlayingWithPages.Infrastructure
{
    public interface IFakeRepository
    {
        Task CreateAsync(Movie movie);

        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<Movie?> GetMovieAsync(int id);
    }
}