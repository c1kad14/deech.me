namespace deech.me.data.models
{
    public class TitleInfo
    {
        public string Annotation { get; set; }
        public Person Author { get; set; }
        public string Cover { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public Person Translator { get; set; }
    }
}