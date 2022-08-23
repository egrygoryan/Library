using Entities.Model;
using Entities.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Pages {
    [Authorize]
    public class BookModel : PageModel
    {
        private readonly ILogger<BookModel> _logger;
        private readonly IBookService BookService;
        public List<Entities.Model.BookModel> Books { get; set; }
        public BookModel(ILogger<BookModel> logger, IBookService bookService) {
            _logger = logger;
            BookService = bookService;
        }
        public void OnGet()
        {
            Books = BookService.GetAllBooks();
        }
    }
}
