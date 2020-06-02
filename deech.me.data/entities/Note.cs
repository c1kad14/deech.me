using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Note : IWriteEntity
    {
        public string Created { get; set; }
        public int ParagraphId { get; set; }
        public Paragraph Paragraph { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
    }
}