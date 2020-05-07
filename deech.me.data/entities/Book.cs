using System.Collections.Generic;
using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Book : IReadEntity
    {
        public int Id { get; set; }
        public List<Paragraph> Paragraphs { get; set; } = new List<Paragraph>();
        public CustomInfo CustomInfo { get; set; }
        public string File { get; set; }
        public PublishInfo PublishInfo { get; set; }
        public TitleInfo TitleInfo { get; set; }
    }
}