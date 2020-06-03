using System.Collections.Generic;
using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Paragraph : IReadEntity
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public int Sequence { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public List<Citation> Citations { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Note> Notes { get; set; }
    }
}