using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Book : IReadEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public CustomInfo CustomInfo { get; set; }
        public List<Paragraph> Paragraphs { get; set; } = new List<Paragraph>();
        public PublishInfo PublishInfo { get; set; }
        public TitleInfo TitleInfo { get; set; }
    }
}