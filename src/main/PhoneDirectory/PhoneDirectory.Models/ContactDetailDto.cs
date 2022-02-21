using System;

namespace PhoneDirectory.Models { 
    public  class ContactDetailDto
    {
        public Guid Id { get; set; }
        public ContactDetailTypes Type { get; set; }
        public string ContactDetailInfo { get; set; }

    }
}
