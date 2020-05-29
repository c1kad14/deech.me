using System;

using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Comment : IWriteEntity
    {
        public int? AssociatedId { get; set; }
        public virtual Comment Associated { get; set; }
        public string Created { get; set; }
        public int Id { get; set; }
        public Paragraph Paragraph { get; set; }
        public int ParagraphId { get; set; }
        public string Value { get; set; }
        public string UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
        public string Username { get; set; }
    }
}