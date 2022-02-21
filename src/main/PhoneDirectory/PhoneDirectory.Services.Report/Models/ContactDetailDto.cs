using PhoneDirectory.Services.Report.Enums;
using System;

namespace PhoneDirectory.Services.Report.Models
{
    public class ContactDetailDto
    {
        public Guid Id { get; set; }
        public ContactDetailTypes Type { get; set; }
        public string ContactDetailInfo { get; set; }

        public Guid ContactId { get; set; }
    }
}
