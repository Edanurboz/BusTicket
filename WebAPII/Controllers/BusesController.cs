using Business.Abstract;
using Business.DTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        IBusService _busService;
        public BusesController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpGet]
        public IActionResult GetAllBuses() { 

            var buses=_busService.GetAll();
            return Ok(buses);
        }
        [HttpPost("CreateBus")]
        public IActionResult CreateBus([FromBody] CreateBusDTO request)
        {
            string sonuc = _busService.Create(request);
            return Ok(sonuc);
        }

        [HttpDelete("DeleteBus")]
        public IActionResult DeleteBus([FromBody] DeleteBusDTO request) {

            _busService.Delete(request);
            return Ok();
        }
        [HttpPut("UpdateBus")]
        public IActionResult UpdateBus([FromBody] UpdateBusDTO request)
        {
            _busService.Update(request);
            return Ok();
        }
        [HttpGet("GetBusById")]
        public IActionResult GetBusById(int id)
        {
            var bus = _busService.GetBusById(id);
            if (bus == null)
            {
                return Ok("Kullanıcı bulunamadı.");
            }
            return Ok(bus);
        }
    }
}
