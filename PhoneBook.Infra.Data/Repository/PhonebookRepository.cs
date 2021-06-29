using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;
using PhoneBook.Infra.Data.Interfaces;

namespace PhoneBook.Infra.Data.Repository
{
    public class PhonebookRepository : GenericRepository<Phonebook>, IPhonebookRepository
    {
        public PhonebookRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
