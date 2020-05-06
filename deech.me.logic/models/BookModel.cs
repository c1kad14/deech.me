using System.Collections.Generic;

namespace deech.me.logic.models
{
    public class BookModel
    {
        public TitleInfoModel Title { get; set; }
        public string File { get; set; }
        public List<string> Contents { get; set; }
        public List<string> Images { get; set; }
    }
}