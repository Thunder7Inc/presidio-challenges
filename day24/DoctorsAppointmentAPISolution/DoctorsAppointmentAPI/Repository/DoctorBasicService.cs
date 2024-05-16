using DoctorsAppointmentAPI.interfaces;
using DoctorsAppointmentAPI.models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointmentAPI.Repository
{
    public class DoctorBasicService : IDoctorService
    {
        private readonly IReposiroty<int, Doctor> _repository;

        public DoctorBasicService(IReposiroty<int, Doctor> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<Doctor> GetDoctorByPhone(string phoneNumber)
        {
            var doctor = (await _repository.Get()).FirstOrDefault(e => e.phonenumber == phoneNumber);
            if (doctor == null)
                throw new NoSuchDoctorException();
            return doctor;

        }


        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _repository.Get();
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<Doctor> UpdateDoctorExperiance(int id,int experiance)
        {
            var doctor = await _repository.Get(id);
            if (doctor == null)
                throw new NoSuchDoctorException();
            doctor.Experiance = experiance;
            doctor = await _repository.Update(doctor);
            return doctor;
        }
        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization)
        {
            var doctors = await _repository.Get();
            return doctors.Where(d => d.Specialization == specialization);
        }


    }
}
