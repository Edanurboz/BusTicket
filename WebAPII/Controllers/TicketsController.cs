using Business.Abstract;
using Business.DTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetAllTickets()
        {
            var tickets = _ticketService.GetAllTickets();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public IActionResult GetTicketById(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpPost("CreateTicket")]
        public IActionResult CreateTicket([FromBody] CreateTicketDTO request)
        {
            //if (string.IsNullOrWhiteSpace(request.Status))
            //{
            //    request.Status = "Aktif"; // Varsayılan değeri kontrol edin ve atayın
            //}

            _ticketService.CreateTicket(request);
            return Ok();
        }

        [HttpPut("UpdateTicket")]
        public IActionResult UpdateTicket( [FromBody] UpdateTicketDTO request)
        {

            _ticketService.UpdateTicket(request);
            return Ok();
        }

        [HttpDelete("DeleteTicket")]
        public IActionResult DeleteTicket([FromBody] DeleteTicketDTO request)
        {
            
            _ticketService.DeleteTicket(request);
            return Ok();
        }

        [HttpPost("CancelTicket")]
        public IActionResult CancelTicket(int ticketId)
        {
            _ticketService.CancelTicket(ticketId);
            return Ok();
        }
    }
}
