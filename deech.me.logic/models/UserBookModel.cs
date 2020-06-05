using System.Collections.Generic;

namespace deech.me.logic.models
{
    public class UserBookModel : BookModel
    {
        public List<BookmarkModel> Bookmarks { get; set; }
        public List<CitationModel> Citations { get; set; }
        public List<NoteModel> Notes { get; set; }
        public int Progress { get; set; }
    }
}