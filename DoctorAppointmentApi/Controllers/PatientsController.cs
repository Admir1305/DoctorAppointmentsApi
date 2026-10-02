using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Repository;
using DoctorAppointmentApi.Repository.implements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _patientRepository.Get();
            return Ok(results);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await _patientRepository.GetById(id);
            return Ok(results);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await _patientRepository.Delete(id);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Patients patient)
        {
            var results = await _patientRepository.Post(patient);
            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Patients patient)
        {
            var results = await _patientRepository.Put(id,patient);
            return Ok(results);
        }




    }


}
