using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Services.Report.Enums;
using PhoneDirectory.Services.Report.Models;
using PhoneDirectory.Services.Report.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneDirectory.Services.Report.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : ControllerBase
    {
        private readonly IContactServices _contactServices;

        public ReportController(IContactServices contactServices)
        {
            _contactServices = contactServices ??
                throw new ArgumentNullException(nameof(contactServices));
        }

        [HttpGet("locations")]
        public ActionResult<IEnumerable<LocationDto>> GetLocations()
        {
            var locationFromRepo = _contactServices.GetContactsDetails().Where(p => p.Type == Enums.ContactDetailTypes.Location)
                .GroupBy(x => x.ContactDetailInfo)
                 .Select(g => new { Location = g.Key, Count = g.Count() })
                 .OrderBy(p => p.Count).ToList();

            return Ok(locationFromRepo);
        }

        [HttpGet("locations/contactnumber")]
        public ActionResult<IEnumerable<LocationDto>> GetContactCount([FromQuery] string locationName)
        {
            var contacts = _contactServices.GetContacts();
            var contactDetails = _contactServices.GetContactsDetails();
            var contactNum = contacts
                             .Join(contactDetails,
                                        contact => contact.Id,
                                        contactDet => contactDet.ContactId,
                                        (contact, contactDet) => new
                                                {
                                                    ContactID = contact.Id,
                                                    contact.IsActive,
                                                    Location = contactDet.ContactDetailInfo,
                                                    contactDet.Type
                                                }).Where(p=>
                                                            //p.IsActive == 1 &&
                                                                 p.Type==ContactDetailTypes.Location 
                                                                && p.Location.Trim() == locationName?.Trim())//Burada ToLower deyine İstanbul ve Istanbul aynı değerlendirildi. Ama Üstteki action'da ikisi farklı lokasyonlar olarak çıktı.
                                                    .GroupBy(p=>p.ContactID)
                                                    .Count();
           
            return Ok(contactNum);
        }

        [HttpGet("locations/phonenumber")]
        public ActionResult<IEnumerable<LocationDto>> GetPhoneNumberCount([FromQuery]  string locationName)
        {
           
            var contactDetails = _contactServices.GetContactsDetails();
            var locationResDet = contactDetails.Where(p => p.Type == ContactDetailTypes.Location && p.ContactDetailInfo.Trim() == locationName?.Trim());
            var phoneNum = locationResDet
                             .Join(contactDetails,
                                        contactDet1 => contactDet1.ContactId,
                                        contactDet2 => contactDet2.ContactId,
                                        (contactDet1, contactDet2) => new
                                        {
                                           contactDet2.ContactId,
                                            contactDet2.Type,
                                            contactDet2.ContactDetailInfo
                                        }).Where(p =>  p.Type == ContactDetailTypes.PhoneNumber)
                                                    .GroupBy(p => p.ContactDetailInfo)
                                                    .Count();

            return Ok(phoneNum);
        }
    }
}
