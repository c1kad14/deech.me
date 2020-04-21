namespace deech.me.data.entities
{
    public class TitleInfo
    {
        public int Id { get; set; }
        public string Annotation { get; set; }
        public Person Author { get; set; }
        public string Cover { get; set; }
        public string Date { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }
        public Language SourceLanguage { get; set; }
        public string Title { get; set; }
        public Person Translator { get; set; }
    }
}