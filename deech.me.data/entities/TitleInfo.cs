namespace deech.me.data.entities
{
    public class TitleInfo
    {
        public int Id { get; set; }
        public string Annotation { get; set; }
        public Person Author { get; set; } = new Person();
        public string Cover { get; set; }
        public string Date { get; set; }
        public Genre Genre { get; set; } = new Genre();
        public Language Language { get; set; } = new Language();
        public Language SourceLanguage { get; set; } = new Language();
        public string Title { get; set; }
        public Person Translator { get; set; } = new Person();
    }
}