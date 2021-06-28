using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
