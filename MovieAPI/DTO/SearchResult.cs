using System.Text.Json.Serialization;

namespace MovieAPI.DTO {
    public class SearchResult {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
