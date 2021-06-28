using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;
using PhoneBook.Infra.Data.Interfaces;

namespace PhoneBook.Infra.Data.Repository
{
    public class PhonebookEntryRepository : GenericRepository<Entry>, IPhonebookEntryRepository
    {
        public PhonebookEntryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        // Lets keep the Services clean - EF functions should remain in the Repository layer
        public async Task<IEnumerable<Entry>> GetByPhonebookEntryBySearchStringAsync(int id, string searchString)
        {
            IQueryable<Entry> result = DbContext.Set<Entry>().Where(x => x.Id == id && (EF.Functions.ILike(x.Name, $"%{searchString}%") || EF.Functions.ILike(x.Number, $"%{searchString}%"))).AsNoTracking().AsQueryable();
            return await result.ToListAsync();
        }
    }
}
