using System.Runtime.Serialization;

namespace EmployeeRequestTrackerApp.Exceptions
{
    public class NoEmployeesFoundException : Exception
    {
        string msg;
        public NoEmployeesFoundException()
        {
            msg = "There is not any Employee present";
        }
        public override string Message => msg;
    }
}