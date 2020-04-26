namespace deech.me.data.entities
{
    public class Image
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public byte [] Data { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}