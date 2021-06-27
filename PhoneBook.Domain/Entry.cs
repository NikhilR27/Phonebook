namespace PhoneBook.Domain
{
    public class Entry : BaseEntity
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public int PhonebookId { get; set; }

        public virtual Phonebook Phonebook { get; set; }
    }
}