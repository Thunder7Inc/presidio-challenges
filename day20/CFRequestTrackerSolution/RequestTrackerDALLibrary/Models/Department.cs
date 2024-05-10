using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Department_Head { get; set; }
        public override bool Equals(object? obj)
        {
            return this.Name.Equals((obj as Department).Name);
        }
        public override string ToString()
        {
            return Id+" "+Name+" "+Department_Head;
        }
        public Department()
        {
            Id = 0;
            Name = string.Empty;
            Department_Head = 0;
        }
        public Department(int id, string name, int department_Head)
        {
            Id = id;
            Name = name;
            Department_Head = department_Head;
        }
        public void BuildDepartmentFromConsole()
        {
            Console.Write("Enter Department Name : ");
            Name = Console.ReadLine();
            Console.Write("Enter Department Head : ");
            Department_Head = Convert.ToInt32(Console.ReadLine());
        }
        public static int GetDepartmentIdFromConsole()
        {
            Console.Write("Enter Department Id : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Enter valid Department Id : ");
            }
            return id;
        }
        public static string GetDepartmentNameFromConsole()
        {
            Console.Write("Enter Department Name : ");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.Write("Enter valid Department Name : ");
                name = Console.ReadLine();
            }
            return name;
        }
    }
}
