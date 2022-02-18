using PhoneDirectory.Services.Contact.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Repositories
{
   public interface IContactRepository
    {
        IEnumerable<Entities.Contact> GetContacts();
        Entities.Contact GetContact(Guid contactId);

        void AddContact(Entities.Contact contact);

        void DeleteContact(Entities.Contact contact);
        void UpdateContact(Entities.Contact contact);
        bool Save();

    }
}
