using System.ComponentModel.DataAnnotations;

namespace Entities.Model {
    public class BookModel {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Published")]
        public int Year { get; set; }
    }
}
