using HospitalDALLibrary.Model;
using System.Diagnostics.CodeAnalysis;
namespace HospitalDALLibrary
{
    /// <summary>
    ///  Doctor Repository
    /// </summary>
    public class DoctorRepository : IRepository<int, Model.Doctor>
    {
        readonly dbHospitalContext dbHospitalContext;
        public DoctorRepository()
        {
            dbHospitalContext = new dbHospitalContext();
        }

        /// <summary>
        /// Add a new doctor
        /// </summary>
        /// <param name="item"> Doctor Details </param>
        /// <returns></returns>
        public Doctor Add(Doctor item)
        {
            if (item == null)
                throw new System.ArgumentNullException();
            if (dbHospitalContext.Doctors.Any(d => d.DoctorName == item.DoctorName && d.DoctorSpecialization == item.DoctorSpecialization))
                throw new DuplicateDoctorDetailsException();
            dbHospitalContext.Doctors.Add(item);
            dbHospitalContext.SaveChanges();
            return item;
        }

        /// <summary>
        /// Get the doctor by ID
        /// </summary>
        /// <param name="key"> Docter Id </param>
        /// <returns>return Docter details</returns>
        public Doctor Get(int id)
        {
            if (dbHospitalContext.Doctors.Count() == 0)
                throw new EmptyDataBaseException("Doctor");
            var item = dbHospitalContext.Doctors.Where(d => d.DoctorId == id).FirstOrDefault();
            if (item == null)
                throw new DoctorIdNotFoundException(id);
            return item;
        }
        /// <summary>
        /// Get all the doctors
        /// </summary>
        /// <returns> Docters details return in list </returns>

        public System.Collections.Generic.List<Doctor> GetAll()
        {
            if (dbHospitalContext.Doctors.Count() == 0)
                throw new EmptyDataBaseException("Doctor");
            return dbHospitalContext.Doctors.ToList();
        }

        /// <summary>
        /// Update the doctor details
        /// </summary>
        /// <param name="item">new Details</param>
        /// <returns> return update details </returns>
        public Doctor Update(Doctor item)
        {
            Console.WriteLine("Update method is under maintenance");
            return item;
        }
        /// <summary>
        /// Delete the doctor details by ID
        /// </summary>
        /// <param name="key"> ID </param>
        /// <returns>return deleted Status</returns>
        public bool Delete(int id)
        {
            if (dbHospitalContext.Doctors.Count() == 0)
                throw new EmptyDataBaseException("Doctor");
            var item = dbHospitalContext.Doctors.Where(d => d.DoctorId == id).FirstOrDefault();
            if (item == null)
                throw new DoctorIdNotFoundException(id);
            dbHospitalContext.Doctors.Remove(item);
            dbHospitalContext.SaveChanges();
            return true;
        }
    }
}
