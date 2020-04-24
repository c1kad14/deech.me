namespace deech.me.data.entities
{
    public class TitleInfoKeyword
    {
        public int TitleInfoId { get; set; }
        public TitleInfo TitleInfo { get; set; }
        public string KeywordCode { get; set; }
        public Keyword Keyword { get; set; }
    }
}