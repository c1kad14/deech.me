using System.ComponentModel.DataAnnotations;

namespace deech.me.data.entities
{
    public class Genre
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}