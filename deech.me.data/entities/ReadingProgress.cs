namespace deech.me.data.entities
{
    public class ReadingProgress
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Created { get; set; }
        public int Progress { get; set; }
        public string Updated { get; set; }
        public string UserId { get; set; }
    }
}