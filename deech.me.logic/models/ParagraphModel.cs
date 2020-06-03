namespace deech.me.logic.models
{
    public class ParagraphModel
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int Comments { get; set; }
        public BookmarkModel Bookmark { get; set; }
        public CitationModel Citation { get; set; }
        public NoteModel Note { get; set; }
    }
}