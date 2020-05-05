namespace deech.me.data.entities
{
    public class Image
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public string Path { get; set; }
    }
}