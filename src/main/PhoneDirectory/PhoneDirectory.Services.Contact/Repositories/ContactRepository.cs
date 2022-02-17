using PhoneDirectory.Services.Contact.DbContexts;
using PhoneDirectory.Services.Contact.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneDirectory.Services.Contact.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbDontext _contactDbContext;

        public ContactRepository(ContactDbDontext contactDbContext)
        {
            _contactDbContext = contactDbContext ?? throw new ArgumentNullException(nameof(contactDbContext));
        }
        public void AddContact(Entities.Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            _contactDbContext.Contacts.Add(contact);
        }
        public Entities.Contact GetContact(Guid contactId)
        {
            if (contactId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            return _contactDbContext.Contacts.FirstOrDefault(a => a.Id == contactId);
        }

        public IEnumerable<Entities.Contact> GetContacts()
        {
            return _contactDbContext.Contacts.ToList<Entities.Contact>();
        }
        public bool Save()
        {
            return (_contactDbContext.SaveChanges() >= 0);
        }

    }
}
