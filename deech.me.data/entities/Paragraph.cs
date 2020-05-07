namespace deech.me.data.entities
{
    public class Paragraph
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public int Sequence { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}