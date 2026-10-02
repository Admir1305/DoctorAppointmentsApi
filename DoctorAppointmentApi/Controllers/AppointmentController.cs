using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _appointmentRepository.Get();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await _appointmentRepository.GetById(id);
            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _appointmentRepository.Delete(id);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Appointments createDto)
        {
            var results = await _appointmentRepository.Post(createDto);
            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Appointments updateDto)
        {
            var results = await _appointmentRepository.Put(id, updateDto);
            return Ok(results);
        }
    }
}
