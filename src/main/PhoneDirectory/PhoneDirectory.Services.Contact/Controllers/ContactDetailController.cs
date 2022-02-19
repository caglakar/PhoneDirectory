using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Services.Contact.Entities;
using PhoneDirectory.Services.Contact.ModelBinders;
using PhoneDirectory.Services.Contact.Models;
using PhoneDirectory.Services.Contact.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Controllers
{
    [ApiController]
    [Route("api/contacts/{contactId}/detail")]
    public class ContactDetailController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public ContactDetailController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository ??
                throw new ArgumentNullException(nameof(contactRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{contactDetailId}", Name = "GetContactDetail")]
        public IActionResult GetContactDetail(Guid contactId, Guid contactDetailId)
        {
            if (!_contactRepository.ContactExists(contactId))
            {
                return NotFound();
            }

            var contactDetFromRepo = _contactRepository.GetContactDetail(contactId, contactDetailId);
            if (contactDetFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ContactDetailDto>(contactDetFromRepo));
        }

        [HttpPost]
        public ActionResult<ContactDetailDto> CreateContactDetail(Guid contactId,ContactDetailCreateDto detailCreateDto)
        {
           
            if (!_contactRepository.ContactExists(contactId))
            {
                return NotFound();
            }
            var contactDet = _mapper.Map<ContactDetail>(detailCreateDto);

            _contactRepository.AddContactDetail(contactId, contactDet);
            _contactRepository.Save();

            var contactDetailDto = _mapper.Map<ContactDetailDto>(contactDet);

            return CreatedAtRoute("GetContactDetail", new { contactId, contactDetailId = contactDetailDto.Id }, contactDetailDto);
        }

        [HttpDelete("{contactDetailId}")]
        public ActionResult DeleteContactDetail( Guid contactId, Guid contactDetailId)
        {
            if (!_contactRepository.ContactExists(contactId))
            {
                return NotFound();
            }

            var contactDetFromRepo = _contactRepository.GetContactDetail(contactId, contactDetailId);
            if(contactDetFromRepo == null)
            {
                return NotFound();
            }

            _contactRepository.DeleteContactDetail(contactDetFromRepo);
            _contactRepository.Save();

            return NoContent();
        }
    }
}
