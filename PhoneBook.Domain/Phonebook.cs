using System.Collections.Generic;

namespace PhoneBook.Domain
{
    public class Phonebook : BaseEntity
    {
        public Phonebook() => Entries = new HashSet<Entry>();

        public string Name { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
