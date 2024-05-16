using DoctorsAppointmentAPI.models;
namespace DoctorsAppointmentAPI.interfaces
{
    public interface IDoctorService
    {
        public Task<Doctor> GetDoctorByPhone(string phoneNumber);
        public Task<Doctor> UpdateDoctorExperiance(int id, int Experiance);
        public Task<IEnumerable<Doctor>> GetDoctors();

        Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization);

    }
}
