using Entities.Model;

namespace Entities.Services {
    public interface IMovieService {
        List<Movie> GetAllMovies();
    }
}