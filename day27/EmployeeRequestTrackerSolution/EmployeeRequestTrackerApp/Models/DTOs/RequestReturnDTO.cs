namespace EmployeeRequestTrackerApp.Models.DTOs
{
    public class RequestReturnDTO
    {
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }
        public int RequestRaisedBy { get; set; }
    }
}
