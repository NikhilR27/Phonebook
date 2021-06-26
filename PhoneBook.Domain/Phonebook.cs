using System;
using System.Collections.Generic;

namespace PhoneBook.Domain
{
    public class Phonebook : BaseEntity
    {
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }


    }
}
