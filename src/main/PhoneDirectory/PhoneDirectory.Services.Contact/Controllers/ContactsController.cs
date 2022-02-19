using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Services.Contact.Models;
using PhoneDirectory.Services.Contact.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public ContactsController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository ??
                throw new ArgumentNullException(nameof(contactRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContactsDto>> GetContacts()
        {
            var contactsFromRepo = _contactRepository.GetContacts();
            return Ok(_mapper.Map<IEnumerable<ContactsDto>>(contactsFromRepo));
        }


        [HttpGet("{contactId}", Name = "GetContact")]
        public IActionResult GetContact(Guid contactId)
        {
            var contactFromRepo = _contactRepository.GetContact(contactId);

            if (contactFromRepo == null)
            {
                return NotFound();
            }
         
            return Ok(_mapper.Map<ContactDto>(contactFromRepo));
        }

        [HttpPost]
        public ActionResult<ContactDto> CreateContact(ContactCreationDto contact)
        {
            var contactEntity = _mapper.Map<Entities.Contact>(contact);
            _contactRepository.AddContact(contactEntity);
            _contactRepository.Save();

            var contactToReturn = _mapper.Map<ContactDto>(contactEntity);
            return CreatedAtRoute("GetContact",
                new { contactId = contactToReturn.Id },
               contactToReturn);
        }

        [HttpPut("{contactId}")]
        public IActionResult UpdateContact(Guid contactId,ContactUpdateDto contactUpdateDto )
        {
            var contactFromRepo = _contactRepository.GetContact(contactId);
            if (contactFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(contactUpdateDto, contactFromRepo);

            _contactRepository.UpdateContact(contactFromRepo);
            _contactRepository.Save();

            return NoContent();
        }

        [HttpDelete("{contactId}")]
        public ActionResult DeleteContact(Guid contactId)
        {
            var contactFromRepo = _contactRepository.GetContact(contactId);

            if (contactFromRepo == null)
            {
                return NotFound();
            }
            _contactRepository.DeleteContact(contactFromRepo);
            _contactRepository.Save();

            return NoContent();
        }
    }
}
