using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Genre : IReadEntity
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}