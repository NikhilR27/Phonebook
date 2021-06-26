using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Domain;

namespace PhoneBook.Application.Interfaces
{
    public interface IPhoneBookService
    {
        Task<IEnumerable<Phonebook>> GetPhoneBookEntriesAsync();
        Task InsertEntryAsync(Entry entry);  
    }
}
