
using RequestTrakerModelLibrary;
using RequestTrackerBLLibrary;
using System.Collections;
using System.Globalization;
using RequestTrackerDALLibrary;
using System.Data.SqlClient;

namespace RequestTrackerApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            new Program().Run();
        }

        readonly DepartmentBL departmentBL;
        readonly EmployeeBL employeeBL;
        readonly RequestBL requestBL;
       
        public Program()
        {
            DepartmentRepository departmentRepository = new DepartmentRepository();
            departmentBL = new DepartmentBL(departmentRepository);
            employeeBL = new EmployeeBL();
            requestBL = new RequestBL();
        }

        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Get All Employees");
            Console.WriteLine("3. Get Employee By Id");
            Console.WriteLine("4. Update Employee By Id");
            Console.WriteLine("5. Delete Employee By Id");
            Console.WriteLine("6. Add Department");
            Console.WriteLine("7. Get All Departments");
            Console.WriteLine("8. Get Department By Id");
            Console.WriteLine("9. Update Department By Id");
            Console.WriteLine("10. Delete Department By ID");
            Console.WriteLine("11. New Request");
            Console.WriteLine("12. Get All Requests");
            Console.WriteLine("13. Get Request By Id");
            Console.WriteLine("14. Close Request By Id");
            Console.WriteLine("15. Delete Request By ID");
            Console.WriteLine("0. Exit");
        }

        void AddDepartment()
        {
            
            try
            {
                departmentBL.AddDepartment();
            }
            catch (DuplicateDepartmentNameException)
            {
                Console.WriteLine("Department Name already exists");
            }
        }
        public void AddEmployee()
        {
            try
            {
                employeeBL.AddEmployee();
            }
            catch (DuplicateEmployeeDetailsException)
            {
                Console.WriteLine("Employee already exists");
            }
        }
        public void GetDepartment()
        {
            try
            {
                Department department = departmentBL.GetDepartment();
                Console.WriteLine(department);
            }
            catch (DepartmentNotFoundException)
            {
                Console.WriteLine("Department not found");
            }
        }

        public void GetEmployee()
        {
            try
            {
                Employee employee = employeeBL.GetEmployee();
                Console.WriteLine(employee);
            }
            catch (EmployeeNotFoundException)
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void GetAllDepartments()
        {
            try
            {
                List<Department> departments = departmentBL.GetAllDepartments();
                foreach (var department in departments)
                {
                    Console.WriteLine(department);
                }
            }
            catch (EmptyDBException)
            {
                Console.WriteLine("No Departments found");
            }
        }

        public void GetAllEmployees()
        {
            try
            {
                List<Employee> employees = employeeBL.GetAllEmployees();
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
            catch (EmptyDBException)
            {
                Console.WriteLine("No Employees found");
            }
        }


        public void UpdateDepartment()
        {
            try
            {
                departmentBL.UpdateDepartment();
            }
            catch (DepartmentNotFoundException)
            {
                Console.WriteLine("Department not found");
            }
        }

        public void UpdateEmployee()
        {
            try
            {
                employeeBL.UpdateEmployee();
            }
            catch (EmployeeNotFoundException)
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void DeleteDepartment()
        {
            try
            {
                departmentBL.RemoveDepartment();
            }
            catch (DepartmentNotFoundException)
            {
                Console.WriteLine("Department not found");
            }
        }


        public void DeleteEmployee()
        {
            try
            {
                employeeBL.RemoveEmployee();
            }
            catch (EmployeeNotFoundException)
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void NewRequest()
        {
            try
            {
                requestBL.AddRequest();
            }
            catch (DuplicateRequestException)
            {
                Console.WriteLine("Request already exists");
            }
        }
        public void DeleteRequest()
        {
               try
            {
                requestBL.RemoveRequest();
            }
            catch (RequestIDNotFoundException)
            {
                Console.WriteLine("Request ID not found");
            }
        }
        public void CloseRequest()
        {
            try
            {
                requestBL.CloseRequest();
            }
            catch (RequestIDNotFoundException)
            {
                Console.WriteLine("Request ID not found");
            }
        }
        public void GetRequest()
        {
            try
            {
                Request request = requestBL.GetRequest();
                Console.WriteLine(request);
            }
            catch (RequestIDNotFoundException)
            {
                Console.WriteLine("Request ID not found");
            }
        }

        public void GetAllRequests()
        {
            try
            {
                List<Request> requests = requestBL.GetAllRequests();
                foreach (var request in requests)
                {
                    Console.WriteLine(request);
                }
            }
            catch (EmptyDBException)
            {
                Console.WriteLine("No Requests found");
            }
        }

        public void Run()
        {
            while (true)
            {
                PrintMenu();
                Console.Write("Enter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add Employee");
                        AddEmployee();
                        break;
                    case 2:
                        Console.WriteLine("Get All Employees");
                        GetAllEmployees();
                        break;
                    case 3:
                        Console.WriteLine("Get Employee By Id");
                        GetEmployee();
                        break;
                    case 4:
                        Console.WriteLine("Update Employee By Id");
                        UpdateEmployee();
                        break;
                    case 5:
                        Console.WriteLine("Delete Employee By Id");
                        DeleteEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Add Department");
                        AddDepartment();
                        break;
                    case 7:
                        Console.WriteLine("Get All Departments");
                        GetAllDepartments();
                        break;
                    case 8:
                        Console.WriteLine("Get Department By Id");
                        GetDepartment();
                        break;
                    case 9:
                        Console.WriteLine("Update Department By Id");
                        UpdateDepartment();
                        break;
                    case 10:
                        Console.WriteLine("Delete Department By ID");
                        DeleteDepartment();
                        break;
                    case 11:
                        Console.WriteLine("New Request");
                        NewRequest();
                        break;
                    case 12:
                        Console.WriteLine("Get All Requests");
                        GetAllRequests();
                        break;
                    case 13:
                        Console.WriteLine("Get Request By Id");
                        GetRequest();
                        break;
                    case 14:
                        Console.WriteLine("Close Request By Id");
                        CloseRequest();
                        break;
                    case 15:
                        Console.WriteLine("Delete Request By ID");
                        DeleteRequest();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

    }
}
