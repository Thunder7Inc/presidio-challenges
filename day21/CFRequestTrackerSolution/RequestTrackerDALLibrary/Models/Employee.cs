namespace RequestTrackerDALLibrary.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Request>? RequestsRaised { get; set; }
        public ICollection<Request>? RequestsClosed { get; set; }

    }
}