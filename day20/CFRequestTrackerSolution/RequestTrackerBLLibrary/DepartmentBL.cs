using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _repository;
        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            //_repository = new DepartmentRepository();//Tight coupling
            _repository = departmentRepository;//Loose coupling
        }
        public Department AddDepartment()
        {
            try
            {
                Department department = new Department();
                department.BuildDepartmentFromConsole();
                return _repository.Add(department);
            }
            catch (DuplicateDepartmentNameException)
            {
                throw new DuplicateDepartmentNameException();
            }
        }

        public int AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAllDepartments()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (EmptyDBException)
            {
                throw new EmptyDBException();
            }
        }
        public Department GetDepartment()
        {
            try
            {
                int id = Department.GetDepartmentIdFromConsole();
                return _repository.Get(id);
            }
            catch (DepartmentNotFoundException)
            {
                throw new DepartmentNotFoundException();
            }
        }

        public Department GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var departments = _repository.GetAll();
            for (int i = 0; i < departments.Count; i++)
                if (departments[i].Name == departmentName)
                    return departments[i];
            throw new DepartmentNotFoundException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Department RemoveDepartment()
        {
            try
            {
                int id = Department.GetDepartmentIdFromConsole();
                return _repository.Delete(id);
            }
            catch (DepartmentNotFoundException)
            {
                throw new DepartmentNotFoundException();
            }
        }

        public Department UpdateDepartment()
        {
            try
            {
                Department department = new Department();
                department.BuildDepartmentFromConsole();
                return _repository.Update(department);
            }
            catch (DepartmentNotFoundException)
            {
                throw new DepartmentNotFoundException();
            }
        }
        

    }
}
