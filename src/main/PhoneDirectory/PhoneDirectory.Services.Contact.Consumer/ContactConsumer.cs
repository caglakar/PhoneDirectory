using MassTransit;
using PhoneDirectory.Services.Contact.Consumer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Consumer
{
    public class ContactConsumer : IConsumer<Models.Contact>
    {
        private readonly IContactServices _contactServices;

        public ContactConsumer(IContactServices contactServices)
        {
            _contactServices = contactServices ??
                throw new ArgumentNullException(nameof(contactServices));
        }
        public async Task Consume(ConsumeContext<Models.Contact> context)
        {
            var data = context.Message;
            _contactServices.CreateContact(data);
            await Task.CompletedTask;
        }
    }
}
