namespace deech.me.data.entities
{
    public class TitleInfoAuthor
    {
        public int Id { get; set; }
        public int TitleInfoId { get; set; }
        public TitleInfo TitleInfo { get; set; }
        public int AuthorId { get; set; }
        public Person Author { get; set; }
    }
}