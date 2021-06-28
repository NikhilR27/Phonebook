using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Domain;
using PhoneBook.Infra.Data.Repository;

namespace PhoneBook.Infra.Data.Interfaces
{
    public interface IPhonebookEntryRepository : IGenericRepository<Entry>
    {
        Task<IEnumerable<Entry>> GetByPhonebookEntryBySearchStringAsync(int id, string searchString);
    }
}
