using System;

namespace PhoneDirectory.Services.Report.Models
{
    public class LocationDto
    {
        public Guid LocationId { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
    }
}
