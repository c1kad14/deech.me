namespace deech.me.data.entities
{
    public class Book
    {
        public int Id { get; set; }
        public virtual BookContent Content { get; set; }
        public virtual PublishInfo Publish { get; set; }
        public virtual TitleInfo Title { get; set; }
    }
}