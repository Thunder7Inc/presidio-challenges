namespace RequestTrakerModelLibrary
{
    public class Employee 
    {
        public Department EmployeeDepartment { get; set; }
        int age;
        DateTime dob;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public double Salary { get; set; }
        public string Role { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            Role = "Employee";
        }
        public Employee(int id, string name, DateTime dateOfBirth,string role)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Role = role;
        }

        public override string ToString()
        {
            return"\nEmployee Id : " + Id
                + "\nEmployee Name " + Name
                + "\nDate of birth : " + DateOfBirth
                + "\nEmployee Age : " + Age
                +"\nEmployee Role "+Role;
        }
        public override bool Equals(object? obj)
        {
            Employee e1, e2;
            e1 = this;
            //e2 = (Employee)obj;//Casting
            e2 = obj as Employee;//Casting in a more symanctic way
            return e1.Id.Equals(e2.Id);
        }
        public static bool operator==(Employee a, Employee b)
        {
            return a.Id == b.Id;

        }
        public static bool operator !=(Employee a, Employee b)
        {
            return a.Id != b.Id;
        }

        public void BuildEmployee()
        {
            Console.Write("Enter Employee Name : ");
            Name = Console.ReadLine();
            Console.Write("Enter Employee Date of Birth : ");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Employee Salary : ");
            Salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Employee Role : ");
            Role = Console.ReadLine();
        }
        public static int GetEmployeeIdFromConsole()
        {
            Console.Write("Enter Employee Id : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid Id, Please enter a valid Id");
                Console.Write("Enter Employee Id : ");
            }
            return id;
        }
    }
}
