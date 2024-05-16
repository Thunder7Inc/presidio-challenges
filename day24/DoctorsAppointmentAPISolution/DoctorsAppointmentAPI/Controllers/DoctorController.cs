using Microsoft.AspNetCore.Mvc;
using DoctorsAppointmentAPI.models;
using DoctorsAppointmentAPI.context;
using DoctorsAppointmentAPI.interfaces;
using DoctorsAppointmentAPI.Repository;

namespace DoctorsAppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet]
        public async Task<IList<Doctor>> Get()
        {
            var doctors = await _doctorService.GetDoctors();
            return doctors.ToList();
        }
        [HttpPut]
        public async Task<ActionResult<Doctor>> Put(int id, int Experiance)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperiance(id, Experiance);
                return Ok(doctor);
            }
            catch (NoSuchDoctorException nsee)
            {
                return NotFound(nsee.Message);
            }
        }
        [HttpGet("{specialization}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorsBySpecialization(string specialization)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsBySpecialization(specialization);
                return Ok(doctors);
            }
            catch (NoDoctorsFoundException ndfe)
            {
                return NotFound(ndfe.Message);
            }
        }
    }
}
