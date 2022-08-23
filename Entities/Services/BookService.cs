using Entities.Model;

namespace Entities.Services {
    public class BookService :IBookService {
        private readonly ApplicationContext _context;
        public BookService(ApplicationContext context) {
            _context = context;
        }

        public List<BookModel> GetAllBooks() => _context.Books.ToList();
    }
    public interface IBookService {
        List<BookModel> GetAllBooks();
    }
}
