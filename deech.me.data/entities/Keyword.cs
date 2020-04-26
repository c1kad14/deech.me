using System.ComponentModel.DataAnnotations;

namespace deech.me.data.entities
{
    public class Keyword
    {
        [Key]
        public string Code { get; set; }
    }
}