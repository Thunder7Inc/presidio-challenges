using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalDALLibrary.Model;

namespace HospitalDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        dbHospitalContext dbHospitalContext; 
        public AppointmentRepository()
        {
            dbHospitalContext = new dbHospitalContext();
        }

        public Appointment Add(Appointment item)
        {
            if (item == null)
                throw new ArgumentNullException();
            // check if appointment already exists  by doctor id and patient id and appointment date
            if (dbHospitalContext.Appointments.Any(a => a.DoctorId == item.DoctorId && a.PatientId == item.PatientId && a.AppointmentDate == item.AppointmentDate))
                throw new DuplicateAppointmentDetailsException();
            try
            {
                dbHospitalContext.Appointments.Add(item);
                dbHospitalContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return item;
        }

        public List<Appointment> GetAll()
        {
            if (dbHospitalContext.Appointments.Count() == 0)
                throw new EmptyDataBaseException("Appointment");

            return dbHospitalContext.Appointments.ToList();
        }

        public Appointment Get(int key)
        {
            if (dbHospitalContext.Appointments.Count() == 0)
                throw new EmptyDataBaseException("Appointment");
            var item = dbHospitalContext.Appointments.Where(a => a.AppointmentId == key).FirstOrDefault();
            if (item == null)
                throw new AppointmentIdNotFoundException(key);
            return item;
        }

        public Appointment Update(Appointment item)
        {
            // 
            Console.WriteLine("Update method is under maintenance");
            return item;
        }

        public bool Delete(int key)
        {
            if (dbHospitalContext.Appointments.Count() == 0)
                throw new EmptyDataBaseException("Appointment");
            var item = dbHospitalContext.Appointments.Where(a => a.AppointmentId == key).FirstOrDefault();
            if (item == null)
                throw new AppointmentIdNotFoundException(key);
            dbHospitalContext.Appointments.Remove(item);
            dbHospitalContext.SaveChanges();
            return true;
        }
    }
}
