using HospitalDALLibrary;
using HospitalDALLibrary.Model;
namespace HospitalBLLibrary
{
    public class DoctorBL 
    {
        readonly IRepository<int, Doctor> _repository;
        public DoctorBL(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }



        public Doctor Add(Doctor doctor)
        {
            try
            {
                return _repository.Add(doctor);
            }
            catch (DuplicateDoctorDetailsException)
            {
                throw new DuplicateDoctorDetailsException();
            }
        }
        public Doctor Get(int id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch (DoctorIdNotFoundException)
            {
                throw new DoctorIdNotFoundException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException("Doctor");
            }
        }

        public List<Doctor> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException("Doctor");
            }
        }

        public Doctor Update(Doctor doctor)
        {
            try
            {
                return _repository.Update(doctor);
            }
            catch (DoctorIdNotFoundException)
            {
                throw new DoctorIdNotFoundException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException("Doctor");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (DoctorIdNotFoundException)
            {
                throw new DoctorIdNotFoundException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException("Doctor");
            }
        }
    }
}
