using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrakerModelLibrary
{
    public class Request : IEquatable<Request>
    {
        public int Id { get; set; }
        public string RequestText { get; set; }
        public DateTime RaisedDate;
        public DateTime? ClosedDate;
        int _raised_ID;
        int _closed_ID;
        public string Status;
        public int Raised_By { 
            get{
                return _raised_ID;
            }
            set {
                _raised_ID = value;
                RaisedDate = DateTime.Now;
                Status = "Open";
            } 
        }
        public int Closed_By
        {
            get
            {
                return _closed_ID;
            }
            set
            {
                _closed_ID = value;
                ClosedDate = DateTime.Now;
                Status = "Closed";
            }
        }

        public bool Equals(Request? other)
        {
            return Id.Equals(other.Id);
        }
        //public bool Equals(Request? other) => Id.Equals(other.Id);

        public override string ToString()
        {
            return $"Id : {Id}, Request : {RequestText}, Raised By : {Raised_By}, Status : {Status}, Raised Date : {RaisedDate}, Closed By : {Closed_By}, Closed Date : {ClosedDate}";
        }

        public Request()
        {
            Id = 0;
            RequestText = string.Empty;
            Raised_By = 0;
            Status = string.Empty;
            RaisedDate = DateTime.Now;
            Closed_By = 0;
            ClosedDate = null;
        }


        public Request(int id, string requestText, int raised_By, string status, DateTime raisedDate)
        {
            Id = id;
            RequestText = requestText;
            Raised_By = raised_By;
            Status = status;
            RaisedDate = raisedDate;
        }

        public void BuildRequest()
        {
            Console.Write("Enter Request Text : ");
            RequestText = Console.ReadLine();
            Console.Write("Enter Raised By : ");
            Raised_By = Convert.ToInt32(Console.ReadLine());
        }

        public static int GetRequestIdFromConsole()
        {
            Console.Write("Enter Request Id : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Enter valid Request Id : ");
            }
            return id;
        }

        public static string GetRequestTextFromConsole()
        {
            Console.Write("Enter Request Text : ");
            string requestText = Console.ReadLine();
            while (string.IsNullOrEmpty(requestText))
            {
                Console.Write("Enter valid Request Text : ");
                requestText = Console.ReadLine();
            }
            return requestText;
        }

        public static int GetRaisedByFromConsole()
        {
            Console.Write("Enter Raised By : ");
            int raisedBy;
            while (!int.TryParse(Console.ReadLine(), out raisedBy))
            {
                Console.Write("Enter valid Raised By : ");
            }
            return raisedBy;
        }
        public static int ClosedByFromConsole()
        {
            Console.Write("Enter Closer ID : ");
            int closedBy;
            while (!int.TryParse(Console.ReadLine(), out closedBy))
            {
                Console.Write("Enter valid Closer ID : ");
            }
            return closedBy;
        }

        public static string GetStatusFromConsole()
        {
            Console.Write("Enter Status : ");
            string status = Console.ReadLine();
            while (string.IsNullOrEmpty(status))
            {
                Console.Write("Enter valid Status : ");
                status = Console.ReadLine();
            }
            return status;
        }

        public static int GetClosedByFromConsole()
        {
            Console.Write("Enter Closed By : ");
            int closedBy;
            while (!int.TryParse(Console.ReadLine(), out closedBy))
            {
                Console.Write("Enter valid Closed By : ");
            }
            return closedBy;
        }


    }
}
