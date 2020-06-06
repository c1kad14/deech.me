using System.Collections.Generic;

namespace deech.me.logic.models
{
    public class BookModel
    {
        public int Id { get; set; }
        public List<ParagraphModel> Paragraphs { get; set; } = new List<ParagraphModel>();
    }
}