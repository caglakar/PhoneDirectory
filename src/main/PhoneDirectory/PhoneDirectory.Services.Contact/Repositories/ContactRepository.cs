using Microsoft.EntityFrameworkCore;
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
         
       public void DeleteContact(Entities.Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            _contactDbContext.Contacts.Remove(contact);
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
            return _contactDbContext.Contacts.Where(p=>p.IsActive==1).ToList<Entities.Contact>();
        }
        public bool Save()
        {
            return (_contactDbContext.SaveChanges() >= 0);
        }

        public void UpdateContact(Entities.Contact contact)
        {
            var entity = _contactDbContext.Contacts.Attach(contact);
            entity.State = EntityState.Modified;
        }

        public void AddContactDetail(Guid contactId, ContactDetail contactDetail)
        {
            if (contactId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            if (contactDetail == null)
            {
                throw new ArgumentNullException(nameof(contactDetail));
            }

             contactDetail.ContactId = contactId;
            _contactDbContext.ContactDetails.Add(contactDetail);
        } 
        public bool ContactExists(Guid contactId)
        {
            if (contactId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            return _contactDbContext.Contacts.Any(p => p.Id == contactId);
        } 
        public void DeleteContactDetail(ContactDetail contactDetail)
        {
            _contactDbContext.ContactDetails.Remove(contactDetail);
        }
        public ContactDetail GetContactDetail(Guid contactId, Guid contactDetailId)
        {
            if (contactId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            if (contactDetailId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(contactDetailId));
            }

            return _contactDbContext.ContactDetails.Where(p => p.ContactId == contactId && p.Id == contactDetailId).FirstOrDefault();
        }

        public IEnumerable<ContactDetail> GetContactDetails()
        {
            return _contactDbContext.ContactDetails.ToList<ContactDetail>();
        }
    }
}
