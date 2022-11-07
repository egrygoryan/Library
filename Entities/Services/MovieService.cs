using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Entities.Services {
    public class MovieService : IMovieService {
        private readonly ApplicationContext _context;
        public MovieService(ApplicationContext context) {
            _context = context;
        }

        public List<Movie> GetAllMovies() =>
            _context.Movies.ToList();
    }
}