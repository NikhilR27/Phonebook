namespace PhoneBook.Domain
{
    public class Entry : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public int PhoneBookId { get; set; }
        public Phonebook Phonebook { get; set; }
    }
}