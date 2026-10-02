using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtiesRepository _specialtiesRepository;

        public SpecialtiesController(ISpecialtiesRepository specialtiesRepository)
        {
            _specialtiesRepository = specialtiesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _specialtiesRepository.Get();

            return Ok(results);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await _specialtiesRepository.GetById(id);

            return Ok(results);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _specialtiesRepository.Delete(id);

            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Spectialties spec)
        {
            var results = await _specialtiesRepository.Put(id, spec);
            return Ok(results);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Spectialties spec)
        {
            var results = await _specialtiesRepository.Post(spec);

            return Ok(results);
        }
    }
}
