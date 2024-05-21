using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerApp.Models
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; } = "Open";
        public int RequestRaisedBy { get; set; }

        [ForeignKey("RequestRaisedBy")]
        public Employee RaisedByEmployee { get; set; }
        public int? RequestClosedBy { get; set; }


        [ForeignKey("RequestClosedBy")]
        public Employee RequestClosedByEmployee { get; set; }

        public Request(string requestMessage, int requestRaisedBy)
        {
            RequestMessage = requestMessage;
            RequestRaisedBy = requestRaisedBy;
        }
        public override string ToString()
        {
            return $"\n************************************* \n" +
                $"Request Details are\n" +
                $"Request Number: {RequestNumber}\n" +
                $"Message: {RequestMessage}\n" +
                $"Request Date: {RequestDate}\n" +
                $"Request RaisedBy: {RequestRaisedBy}\n" +
                $"Status: {RequestStatus}\n" +
                $"*****************************************\n";
        }


    }
}
