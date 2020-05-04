using deech.me.data.abstractions;

namespace deech.me.data.entities
{
    public class Person : IReadEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Nickname { get; set; }


        public override string ToString()
        {
            if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName))
            {
                if (!string.IsNullOrEmpty(MiddleName))
                {
                    return $"{FirstName} {MiddleName} {LastName}".Trim();
                }
                else
                {
                    return $"{FirstName} {LastName}".Trim();
                }
            }
            else if (!string.IsNullOrEmpty(Nickname))
            {
                return Nickname;
            }
            else
            {
                return "unknown author";
            }
        }
    }
}