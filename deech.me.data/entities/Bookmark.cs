using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Bookmark : IWriteEntity
    {
        public string Created { get; set; }
        public Paragraph Paragraph { get; set; }
        public int ParagraphId { get; set; }
        public UserBook UserBook { get; set; }
        public int UserBookId { get; set; }
    }
}