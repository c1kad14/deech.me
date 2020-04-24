using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace deech.me.data.entities
{
    public class Genre
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public List<TitleInfoGenre> TitleInfos { get; set; } = new List<TitleInfoGenre>();
    }
}