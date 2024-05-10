using HospitalDALLibrary;
using HospitalDALLibrary.Model;
namespace HospitalBLLibrary
{
    public class AppointmentBL
    {
        readonly IRepository<int, Appointment> _repository;
        public AppointmentBL(IRepository<int, Appointment> repository)
        {
            _repository = repository;
        }
        public Appointment Add(Appointment appointment)
        {
            try
            {
                return _repository.Add(appointment);
            }
            catch (DuplicateAppointmentDetailsException)
            {
                throw new DuplicateAppointmentDetailsException();
            }
        }
        public Appointment Get(int id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch (AppointmentIdNotFoundException)
            {
                throw new AppointmentIdNotFoundException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException("Appointment");
            }
        }
        public List<Appointment> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException("Appointment");
            }
        }
        public Appointment Update(Appointment appointment)
        {
            try
            {
                return _repository.Update(appointment);
            }
            catch (AppointmentIdNotFoundException)
            {
                throw new AppointmentIdNotFoundException();
            }
        }
    }
}
