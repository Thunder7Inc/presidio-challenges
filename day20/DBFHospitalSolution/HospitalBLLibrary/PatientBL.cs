using HospitalDALLibrary;
using HospitalDALLibrary.Model;

namespace HospitalBLLibrary
{
    public class PatientBL
    {
        readonly IRepository<int, Patient> _repository;

        public PatientBL(IRepository<int, Patient> repository)
        {
            _repository = repository;
        }

        public Patient Add(Patient patient)
        {
            try
            {
                return _repository.Add(patient);
            }
            catch (DuplicatePatientDetailsException)
            {
                throw new DuplicatePatientDetailsException();
            }
        }

        public Patient Get(int id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch (PatientIdNotFoundException)
            {
                throw new PatientIdNotFoundException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException("Patient");
            }
        }

        public List<Patient> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException("Patient");
            }
        }


        public Patient Update(Patient patient)
        {
            try
            {
                return _repository.Update(patient);
            }
            catch (PatientIdNotFoundException)
            {
                throw new PatientIdNotFoundException();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (PatientIdNotFoundException)
            {
                throw new PatientIdNotFoundException();
            }
        }
    }
}
