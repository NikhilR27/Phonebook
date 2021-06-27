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
            this._phonebookRepository = phonebookRepository;
            this._phonebookEntryRepository = phonebookEntryRepository;
        }

        public Task<IEnumerable<Phonebook>> GetPhonebooks() => this._phonebookRepository.GetAllAsync();

        public async Task<IEnumerable<Entry>> GetPhonebookEntries()
        {
            IEnumerable<Entry> allAsync = await this._phonebookEntryRepository.GetAllAsync();
            return allAsync;
        }

        public async Task<IEnumerable<Entry>> GetPhonebookEntriesBySearchString(
            string searchString)
        {
            IEnumerable<Entry> byConditionAsync = await this._phonebookEntryRepository.GetByConditionAsync((Expression<Func<Entry, bool>>)(x => x.Name.Contains(searchString) || x.Number.Contains(searchString)));
            return byConditionAsync;
        }

        public Task InsertEntryAsync(Entry entry) => this._phonebookEntryRepository.CreateAsync(entry);
    }
}
