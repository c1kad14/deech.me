using System.ComponentModel.DataAnnotations.Schema;

namespace deech.me.data.entities
{
    public class CustomInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}