using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Publisher.Controllers
{
    [ApiController]
    [Route("api/publisher")]
    public class ContactController : ControllerBase
    {
        private readonly IBus _bus;
        public ContactController(IBus bus)
        {
            _bus = bus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(Models.Contact contact)
        {
            if (contact != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/contactQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(contact);
                return Ok();
            }
            return BadRequest();
        }
    }
}
