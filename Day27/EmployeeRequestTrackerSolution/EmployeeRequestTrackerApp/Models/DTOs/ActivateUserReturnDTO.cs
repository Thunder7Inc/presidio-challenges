namespace EmployeeRequestTrackerApp.Models.DTOs
{
    public class ActivateUserReturnDTO
    {
        public int EmployeeId { get; set; }
        public string Status { get; set; } = "Disabled";
    }
}
