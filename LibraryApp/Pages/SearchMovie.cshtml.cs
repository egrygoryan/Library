using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAPI.Controllers;
using MovieAPI.DTO;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Pages
{
    public class SearchMovieModel : PageModel
    {
        public SearchData? MovieList { get; set; }
        public void OnGet()
        {
        }
    }
}
