using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Person : IReadEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}