using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;
using PhoneBook.Infra.Data.Interfaces;
using PhoneBook.Infra.Data.Repository;

namespace PhoneBook.Application
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhonebookRepository _phonebookRepository;
        private readonly IPhonebookEntryRepository _phonebookEntryRepository;

        public PhoneBookService(IPhonebookRepository phonebookRepository, IPhonebookEntryRepository phonebookEntryRepository)
        {
            _phonebookRepository = phonebookRepository;
            _phonebookEntryRepository = phonebookEntryRepository;
        }

        public async Task InsertPhonebooksAsync(Phonebook phonebook)
        {
            await _phonebookRepository.CreateAsync(phonebook);
        }

        public async Task<IEnumerable<Phonebook>> GetPhonebooksAsync()
        {
            return await _phonebookRepository.GetAllAsync(new string[] { "Entries" });
        }

        public async Task InsertPhonebookEntryAsync(Entry entry)
        {
            await _phonebookEntryRepository.CreateAsync(entry);
        }

        public async Task<IEnumerable<Entry>> GetPhonebookEntriesAsync(int id)
        {
            return await _phonebookEntryRepository.GetByConditionAsync(x => x.PhonebookId == id);
        }

        public async Task<IEnumerable<Entry>> GetPhonebookEntriesBySearchStringAsync(int id, string searchString)
        {
            return await _phonebookEntryRepository.GetByPhonebookEntryBySearchStringAsync(id, searchString);
        }
    }
}
