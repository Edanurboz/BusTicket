using Azure.Core;
using Business.Abstract;
using Business.DTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet("GetAllSeats")]
        public IActionResult GetAllSeats()
        {
            var seats = _seatService.GetAll();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public IActionResult GetSeatById(int id)
        {
            var seat = _seatService.GetById(id);
            if (seat == null)
            {
                return NotFound();
            }
            return Ok(seat);
        }

        [HttpPost("CreateSeat")]
        public IActionResult CreateSeat([FromBody] CreateSeatDTO request)
        {
            string sonuc = _seatService.Create(request);
            return Ok(sonuc);

        }

        [HttpPut("UpdateSeat")]
        public IActionResult UpdateSeat( [FromBody] UpdateSeatDTO request)
        {

            _seatService.Update(request);
            return Ok("Güncellendi.");
        }

        [HttpDelete("DeleteSeat")]
        public IActionResult DeleteSeat([FromBody] DeleteSeatDTO request)
        {
            
            _seatService.Delete(request);
            return Ok("Silindi");
        }

        [HttpPost("ReserveSeat")]
        public IActionResult ReserveSeat(int seatId)
        {
            _seatService.ReserveSeat(seatId);
            return Ok();
        }

        [HttpPost("ReleaseSeat")]
        public IActionResult ReleaseSeat(int seatId)
        {
            _seatService.ReleaseSeat(seatId);
            return Ok();
        }
    }
}
