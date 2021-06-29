using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Domain;

namespace PhoneBook.Application.Interfaces
{
    public interface IPhoneBookService
    {
        Task InsertPhonebooksAsync(Phonebook phonebook);
        Task<IEnumerable<Phonebook>> GetPhonebooksAsync();
        Task InsertPhonebookEntryAsync(Entry entry);
        Task<IEnumerable<Entry>> GetPhonebookEntriesAsync(int id);
        Task<IEnumerable<Entry>> GetPhonebookEntriesBySearchStringAsync(int id, string searchString);
    }
}
