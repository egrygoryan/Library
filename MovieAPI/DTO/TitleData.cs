namespace MovieAPI.DTO {
    public class TitleData {
        public string Title { set; get; }
        public string Year { set; get; }
        public string Plot { set; get; } // IMDb Plot allways en, TMDb Plot translate
        public string Image { get; set; }
        public string Genres { set; get; }
        public List<KeyValuePair<string, string>> GenreList { get; set; }

        public string IMDbRating { get; set; }
        public string MetacriticRating { set; get; }
    }
}
