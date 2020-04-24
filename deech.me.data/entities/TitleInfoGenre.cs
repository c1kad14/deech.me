namespace deech.me.data.entities
{
    public class TitleInfoGenre
    {
        public int TitleInfoId { get; set; }
        public TitleInfo TitleInfo { get; set; }
        public string GenreCode { get; set; }
        public Genre Genre { get; set; }
    }
}