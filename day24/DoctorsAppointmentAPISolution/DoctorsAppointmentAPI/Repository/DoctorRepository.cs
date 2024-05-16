using DoctorsAppointmentAPI.context;
using DoctorsAppointmentAPI.interfaces;
using DoctorsAppointmentAPI.models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointmentAPI.Repository
{
    public class DoctorRepository : IReposiroty<int, Doctor>
    {
        private readonly DoctorAppoinmentContext _context;
        public DoctorRepository(DoctorAppoinmentContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchDoctorException();
        }

        public Task<Doctor> Get(int key)
        {
            var employee = _context.Doctors.FirstOrDefaultAsync(e => e.Id == key);
            return employee;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var employees = await _context.Doctors.ToListAsync();
            return employees;

        }

        public async Task<Doctor> Update(Doctor item)
        {
            var employee = await Get(item.Id);
            if (employee != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchDoctorException();
        }
    }
}
