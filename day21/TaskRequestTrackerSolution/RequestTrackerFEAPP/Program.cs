using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password,Id=username };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            var result = await employeeLoginBL.Login(employee);
            if (result)
            {
                await Console.Out.WriteLineAsync("Login Success");
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }
        async Task GetLoginDeatils()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id,password);
        }
        static async Task Main(string[] args)
        {
            //await new Program().GetLoginDeatils();

            // get all employees
            
            RequestBL requestBL = new RequestBL();

            var newRequest = await requestBL.Add(106, "Please approve my leave");
            if (newRequest != null)
            {

                await Console.Out.WriteLineAsync($"{newRequest.RequestNumber}Request added successfully");
            }
            else
            {
                await Console.Out.WriteLineAsync("Request not added");
            }

            //var requests = await requestBL.GetAll();
            //foreach (var request in requests)
            //{
            //    await Console.Out.WriteLineAsync($"{request.RequestNumber} {request.RequestMessage} , {request.RaisedByEmployee}");
            //}
        }
    }
}
