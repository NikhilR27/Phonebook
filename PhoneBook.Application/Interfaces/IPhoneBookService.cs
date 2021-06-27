using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Domain;

namespace PhoneBook.Application.Interfaces
{
    public interface IPhoneBookService
    {
        Task<IEnumerable<Phonebook>> GetPhonebooks();
        Task<IEnumerable<Entry>> GetPhonebookEntries();
        Task<IEnumerable<Entry>> GetPhonebookEntriesBySearchString(string searchString);
        Task InsertEntryAsync(Entry entry);
    }
}
