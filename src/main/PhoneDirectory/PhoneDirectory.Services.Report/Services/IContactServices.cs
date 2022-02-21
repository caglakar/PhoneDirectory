using PhoneDirectory.Services.Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Report.Services
{
    public interface IContactServices
    {
       IEnumerable<ContactDetailDto> GetContactsDetails();
        IEnumerable<ContactsDto> GetContacts();
    }

}
