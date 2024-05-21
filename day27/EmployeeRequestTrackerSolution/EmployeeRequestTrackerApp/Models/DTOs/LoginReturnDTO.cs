namespace EmployeeRequestTrackerApp.Models.DTOs
{
    public class LoginReturnDTO
    {
        public int EmployeeId { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }

    }
}
