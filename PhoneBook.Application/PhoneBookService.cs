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

        public PhoneBookService(IRepositoryBase<Phonebook> phonebookRepository, IRepositoryBase<Entry> phonebookEntryRepository)
        {
            _phonebookRepository = phonebookRepository;
            _phonebookEntryRepository = phonebookEntryRepository;
        }

        public Task<IEnumerable<Phonebook>> GetPhoneBookEntriesAsync()
        {
            return _phonebookRepository.GetAllAsync();
        }

        public Task InsertEntryAsync(Entry entry)
        {
            return _phonebookEntryRepository.CreateAsync(entry);
        }
    }
}
