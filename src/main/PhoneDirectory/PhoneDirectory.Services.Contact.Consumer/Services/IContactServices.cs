using PhoneDirectory.Models;
using System.Collections.Generic; 

namespace PhoneDirectory.Services.Contact.Consumer.Services
{
    public interface IContactServices
    {
        ContactDto CreateContact(Models.Contact contact);
    }

}
