using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTO;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using Entities;
using Entities.Model;

namespace MovieAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly JsonSerializerOptions _options;
        private readonly ApplicationContext _ctx;
        private static readonly string _apiKey;

        static MovieController() {
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _apiKey = "k_ckr31is6";
            _httpClient.BaseAddress = new Uri("https://imdb-api.com/en/API/");

        }
        public MovieController(ApplicationContext context) {

            _ctx = context;
        }

        [HttpGet]
        public async Task<ActionResult<SearchData>> GetMovies(string movieTitle) {
            if (string.IsNullOrWhiteSpace(movieTitle)) {
                return new BadRequestResult();
            }
            var uri = Path.Combine("SearchMovie", _apiKey, movieTitle);

            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<SearchData>(_options);
            if (content.Results == null) {
                return new NoContentResult();
            }

            return content;
        }

        [HttpPost]
        public async Task<ActionResult> AddMovieToDb(MoviesList chosenMoviesIds) { 
            if (chosenMoviesIds == null || !chosenMoviesIds.moviesIdsList.Any()) {
                return BadRequest();
            }

            foreach (var movie in chosenMoviesIds.moviesIdsList) {
                var uri = Path.Combine("Title", _apiKey, movie.ToString());
                
                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<TitleData> (_options);

                if(content == null) {
                    continue;
                }

                _ctx.Movies.Add(
                    new Movie {
                    Title = content.Title,
                    Genre = content.Genres,
                    Year = int.Parse(content.Year),
                    Image = content.Image
                });
            }

            _ctx.SaveChanges();
            return Ok();
        }
    }
}