using HospitalDALLibrary;
using HospitalDALLibrary.Model;
namespace HospitalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert doctor details");
            DoctorRepository doctorRepository = new DoctorRepository();
            Doctor doctor = new Doctor("John Doe", "General Physician");    
            //doctorRepository.Add(doctor);
            //var doctors = doctorRepository.GetAll();
            //doctors.ForEach(Console.WriteLine);

            //Console.WriteLine("Insert patient details");
            PatientRepository patientRepository = new PatientRepository();
            Patient patient = new Patient("Kali",22,"male","1234 Main St","1234567890");

            //patientRepository.Add(patient);
            //var patients = patientRepository.GetAll();
            //patients.ForEach(Console.WriteLine);

            Console.WriteLine("Insert appointment details");
            AppointmentRepository appointmentRepository = new AppointmentRepository();
            Appointment appointment = new Appointment(100, 1 , DateTime.Now, DateTime.Now);
            
            appointmentRepository.Add(appointment);
            var appointments = appointmentRepository.GetAll();
            appointments.ForEach(Console.WriteLine);
        }
    }
}
