using Business.Abstract;
using Business.DTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public IActionResult GetAllTrips()
        {
            var trips = _tripService.GetAllTrips();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public IActionResult GetTripById(int id)
        {
            var trip = _tripService.GetTripById(id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        [HttpPost("CreateTrip")]
        public IActionResult CreateTrip([FromBody] CreateTripDTO request)
        {
            request.date_ = request.date_.Date;
            var response = new
            {
                departure_city = request.departure_city,
                arrival_city = request.arrival_city,
                date_ = request.date_.ToString("yyyy-MM-dd")
            };
            _tripService.Create(request);
            return Ok();
        }

        [HttpPut("UpdateTrip")]
        public IActionResult UpdateTrip([FromBody] UpdateTripDTO request)
        {
            _tripService.UpdateTrip(request);
            return Ok();
        }

        [HttpDelete("DeleteTrip")]
        public IActionResult DeleteTrip([FromBody] DeleteTripDTO request)
        {
            _tripService.DeleteTrip(request);
            return Ok();
        }
    }
}
