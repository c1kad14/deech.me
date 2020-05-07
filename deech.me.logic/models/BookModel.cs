using System.Collections.Generic;

namespace deech.me.logic.models
{
    public class BookModel
    {
        public TitleInfoModel Title { get; set; }
        public string File { get; set; }
        public List<ParagraphModel> Paragraphs { get; set; } = new List<ParagraphModel>();
    }
}