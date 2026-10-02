using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository _doctorsRepository;
        public DoctorsController(IDoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _doctorsRepository.Get();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await _doctorsRepository.GetById(id);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Doctors createDto)
        {
            var results = await _doctorsRepository.Post(createDto);
            return Ok(results);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _doctorsRepository.Delete(id);
            return Ok(results);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, Doctors updateDto)
        {
            var results = await _doctorsRepository.Put(id,updateDto);
            return Ok(results);
        }
    }
}
