using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;
using PhoneBook.Infra.Data.Repository;

namespace PhoneBook.Application
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IRepositoryBase<Phonebook> _phonebookRepository;
        private readonly IRepositoryBase<Entry> _phonebookEntryRepository;

        public PhoneBookService(
            IRepositoryBase<Phonebook> phonebookRepository,
            IRepositoryBase<Entry> phonebookEntryRepository)
        {
            _phonebookRepository = phonebookRepository;
            _phonebookEntryRepository = phonebookEntryRepository;
        }

        public async Task<IEnumerable<Phonebook>> GetPhonebooks()
        {
            return await _phonebookRepository.GetAllAsync(new string[] { "Entries" });
        }

        public async Task<IEnumerable<Entry>> GetPhonebookEntries()
        {
            return await _phonebookEntryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Entry>> GetPhonebookEntriesBySearchString(string searchString)
        {
            return await _phonebookEntryRepository.GetByConditionAsync(x => x.Name.Contains(searchString) || x.Number.Contains(searchString));
        }

        public async Task InsertEntryAsync(Entry entry)
        {
            await _phonebookEntryRepository.CreateAsync(entry);
        }
    }
}
