using System.Collections.Generic;

namespace deech.me.data.entities
{
    public class Book
    {
        public int Id { get; set; }
        public virtual List<BookContent> Contents { get; set; } = new List<BookContent>();
        public CustomInfo CustomInfo { get; set; } = new CustomInfo();
        public string File { get; set; }
        public virtual PublishInfo PublishInfo { get; set; } = new PublishInfo();
        public virtual TitleInfo TitleInfo { get; set; } = new TitleInfo();
        public virtual List<Image> Images { get; set; } = new List<Image>();
    }
}