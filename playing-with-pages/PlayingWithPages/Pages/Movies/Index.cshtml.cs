using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayingWithPages.Infrastructure;
using PlayingWithPages.Models;

namespace PlayingWithPages.Pages.Movies
{
    public class MoviesPageModel : PageModel
    {
        private readonly IFakeRepository _repository;

        private readonly List<Movie> _movies = new();

        public List<Movie> Movies => _movies;

        public MoviesPageModel(IFakeRepository repository)
        {
            this._repository = repository;
        }

        public async Task OnGet()
        {
            var movies = await this._repository.GetAllMoviesAsync();
            this._movies.AddRange(movies);
        }
    }
}
