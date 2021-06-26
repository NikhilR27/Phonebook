using System;
namespace PhoneBook.Domain
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; private set; }
    }
}
