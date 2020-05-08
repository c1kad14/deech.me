using System.ComponentModel.DataAnnotations.Schema;

namespace deech.me.data.entities
{
    public class PublishInfo
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string City { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
    }
}