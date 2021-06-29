using PhoneBook.Domain;
using PhoneBook.Infra.Data.Repository;

namespace PhoneBook.Infra.Data.Interfaces
{
    public interface IPhonebookRepository : IGenericRepository<Phonebook>
    {
    }
}
