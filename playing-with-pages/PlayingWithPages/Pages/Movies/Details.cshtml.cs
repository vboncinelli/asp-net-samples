using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayingWithPages.Infrastructure;
using PlayingWithPages.Models;

namespace PlayingWithPages.Pages.Movies
{
    public class MovieDetailsModel : PageModel
    {
        private IFakeRepository _repository;

        public Movie Movie { get; set; } = null!;

        public MovieDetailsModel(IFakeRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var movie = await this._repository.GetMovieAsync(id);

            if (movie is null) return NotFound();

            this.Movie = movie;

            return Page();
        }
    }
}
