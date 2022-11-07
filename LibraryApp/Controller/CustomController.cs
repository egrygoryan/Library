using Entities;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTO;
using System.Text.Json;

namespace LibraryApp.Controller {
    [ApiController]
    [Route("api/[controller]")]
    public class CustomController : ControllerBase {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly JsonSerializerOptions _options;
        private readonly ApplicationContext _ctx;

        static CustomController() {
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _httpClient.BaseAddress = new Uri("https://imdb-api.com/en/API/SearchMovie/k_ckr31is6/");

        }
        public CustomController(ApplicationContext context) {

            _ctx = context;
        }


        [HttpPost]
        public async Task<ActionResult> AddMovieToDB(SearchData movies) {
            if(movies.Results == null) {
                return BadRequest("Object array must be specified");
            }
            foreach (var movie in movies.Results) {
                _ctx.Movies.AddRange(new Entities.Model.Movie { Title = movie.Title });
            }
            _ctx.SaveChanges();
            return Ok();
        }
    }
}
