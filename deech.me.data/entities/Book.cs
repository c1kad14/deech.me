using System.Collections.Generic;
using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Book : IReadEntity
    {
        public int Id { get; set; }
        public List<BookContent> Contents { get; set; } = new List<BookContent>();
        public CustomInfo CustomInfo { get; set; }
        public string File { get; set; }
        public PublishInfo PublishInfo { get; set; }
        public TitleInfo TitleInfo { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }
}