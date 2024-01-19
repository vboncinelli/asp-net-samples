using PlayingWithPages.Models;

namespace PlayingWithPages.Infrastructure
{
    public class FakeRepository : IFakeRepository
    {
        private List<Movie> _movies = new();

        public FakeRepository()
        {
            _movies.Add(new Movie(1, "Ghostbuster", "Action comedy", "Who are you gonna call?"));
            _movies.Add(new Movie(2, "Titanic", "Drama", "Who let the iceberg out?"));
            _movies.Add(new Movie(3, "Big trouble in Little China", "Action comedy", "It's all in the reflexes"));
        }

        public async Task<Movie?> GetMovieAsync(int id)
        {
            var movie = this._movies.FirstOrDefault(x => x.Id == id);

            // simula una chiamata asincrona
            await Task.CompletedTask;

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            // simula una chiamata asincrona
            await Task.CompletedTask;

            return _movies;
        }

        public async Task CreateAsync(Movie movie)
        {
            this._movies.Add(movie);

            await Task.CompletedTask;
        }
    }
}
