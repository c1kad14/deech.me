namespace deech.me.data.entities
{
    public class Book
    {
        public int Id { get; set; }
        public virtual BookContent Content { get; set; } = new BookContent();
        public virtual PublishInfo Publish { get; set; } = new PublishInfo();
        public virtual TitleInfo Title { get; set; } = new TitleInfo();
    }
}