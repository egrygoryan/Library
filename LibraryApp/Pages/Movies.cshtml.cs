using Entities.Model;
using Entities.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Pages {
    //[Authorize]
    public class MoviesModel : PageModel
    {
        private readonly IMovieService _movieService;
        public List<Movie> Movies { get; set; }
        public MoviesModel(IMovieService movieService) {
            _movieService = movieService;
        }
        public void OnGet()
        {
            Movies = _movieService.GetAllMovies();
        }
    }
}
