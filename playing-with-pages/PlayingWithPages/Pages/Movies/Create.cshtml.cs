using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayingWithPages.Infrastructure;
using PlayingWithPages.Models;

namespace PlayingWithPages.Pages.Movies
{
    public class CreateViewModel : PageModel
    {
        private readonly IFakeRepository _fakeRepository;

        public Movie Movie = null!;

        public CreateViewModel(IFakeRepository repository)
        {
            this._fakeRepository = repository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync([FromForm] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await this._fakeRepository.CreateAsync(movie);

            return RedirectToPage("Index");
        }
    }
}
