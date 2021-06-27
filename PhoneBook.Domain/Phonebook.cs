using System;
using System.Collections.Generic;

namespace PhoneBook.Domain
{
    public class Phonebook : BaseEntity
    {
        public Phonebook() => this.Entries = (ICollection<Entry>)new HashSet<Entry>();

        public string Name { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
