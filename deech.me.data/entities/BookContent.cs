namespace deech.me.data.entities
{
    public class BookContent
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public byte[] Data { get; set; }
    }
}