using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalDALLibrary.Model;

namespace HospitalDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly dbHospitalContext dbHospitalContext;
        
        public PatientRepository()
        {
            dbHospitalContext = new dbHospitalContext();
        }
        /// <summary>
        ///  Add a new patient
        /// </summary>
        /// <param name="item"> Patient Details </param>
        /// <returns></returns>
        public Patient Add(Model.Patient item)
        {
            if (item == null)
                throw new ArgumentNullException();
            // check if patient already exists by patient name and patient phone number
            if (dbHospitalContext.Patients.Any(p => p.PatientName == item.PatientName && p.PatientPhoneNumber == item.PatientPhoneNumber))
                throw new DuplicatePatientDetailsException();
            dbHospitalContext.Patients.Add(item);
            dbHospitalContext.SaveChanges();
            return item;
        }
        
        public Patient Get(int id)
        {
            if (dbHospitalContext.Patients.Count() == 0)
                throw new EmptyDataBaseException("Patient");
            var item = dbHospitalContext.Patients.Where(p => p.PatientId == id).FirstOrDefault();
            if (item == null)
                throw new PatientIdNotFoundException(id);
            return item;
        }
        public List<Patient> GetAll()
        {
            if (dbHospitalContext.Patients.Count() == 0)
                throw new EmptyDataBaseException("Patient");
            return dbHospitalContext.Patients.ToList();
        }

        public Patient Update(Patient item)
        {
            // under maintenance
            Console.WriteLine("Update method is under maintenance");
            return item;
        }

        public bool Delete(int id)
        {
            if (dbHospitalContext.Patients.Count() == 0)
                throw new EmptyDataBaseException("Patient");
            var item = dbHospitalContext.Patients.Where(p => p.PatientId == id).FirstOrDefault();
            if (item == null)
                throw new PatientIdNotFoundException(id);
            dbHospitalContext.Patients.Remove(item);
            dbHospitalContext.SaveChanges();
            return true;
        }
    }
}
