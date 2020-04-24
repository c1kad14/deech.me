namespace deech.me.data.entities
{
    public class Book
    {
        public int Id { get; set; }
        public virtual BookContent Content { get; set; } = new BookContent();
        public CustomInfo CustomInfo { get; set; }
        public string File { get; set; }
        public virtual PublishInfo Publish { get; set; } = new PublishInfo();
        public virtual TitleInfo Title { get; set; } = new TitleInfo();
    }
}