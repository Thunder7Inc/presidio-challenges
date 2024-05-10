using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class DuplicateDepartmentNameException : Exception
    {
        string msg;
        public DuplicateDepartmentNameException()
        {
            msg = "Department name already exists";
        }
        public override string Message => msg;
    }
    public class DepartmentNotFoundException : Exception
    {
        string msg;
        public DepartmentNotFoundException()
        {
            msg = "Department not found";
        }
        public override string Message => msg;
    }
    public class EmptyDBException : Exception
    {
        string msg;
        public EmptyDBException()
        {
            msg = "Database is empty";
        }
        public override string Message => msg;
    }
    public class DuplicateEmployeeDetailsException : Exception
    {
        string msg;
        public DuplicateEmployeeDetailsException()
        {
            msg = "Employee Details already exists";
        }
        public override string Message => msg;
    }

    public class EmployeeNotFoundException : Exception
    {
        string msg;
        public EmployeeNotFoundException()
        {
            msg = "Employee not found";
        }
        public override string Message => msg;
    }
    public class DuplicateRequestException : Exception
    {
        string msg;
        public DuplicateRequestException()
        {
            msg = "Request already exists";
        }
        public override string Message => msg;
    }

    public class RequestIDNotFoundException : Exception
    {
        string msg;
        public RequestIDNotFoundException( )
        {
            msg = "Request ID not found";
        }
        public override string Message => msg;
    }


}
