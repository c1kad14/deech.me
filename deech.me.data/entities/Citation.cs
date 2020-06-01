using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Citation : IWriteEntity
    {
        public string Created { get; set; }
        public int Id { get; set; }
        public int ParagraphId { get; set; }
        public Paragraph Paragraph { get; set; }
        public string UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
        public string Value { get; set; }
    }
}