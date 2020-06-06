using System.Collections.Generic;

namespace deech.me.logic.models
{
    public class UserBookModel
    {
        public List<BookmarkModel> Bookmarks { get; set; }
        public List<CitationModel> Citations { get; set; }
        public List<NoteModel> Notes { get; set; }
        public List<ParagraphModel> Paragraphs { get; set; } = new List<ParagraphModel>();
        public int Progress { get; set; }
        public int UserBookId { get; set; }
    }
}