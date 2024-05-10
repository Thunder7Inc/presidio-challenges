using System.ComponentModel.DataAnnotations.Schema;

namespace RequestTrackerDALLibrary.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string RequestMsg { get; set; }
        public DateTime RaisedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int RaisedBy { get; set; }
        public Employee RaisedByEmployee { get; set; }

        public int? ClosedBy { get; set; }
        public Employee? ClosedByEmployee { get; set; }


    }
}